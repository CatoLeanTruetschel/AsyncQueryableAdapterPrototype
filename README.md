# AsyncQueryableAdapterPrototype
## Abstract
This is a prototype that enables to use the `IAsyncQueryable` type ([System.Linq.Async.Queryable](https://www.nuget.org/packages/System.Linq.Async.Queryable/)) with query providers and database drivers that do not support this natively.

## The long story: Background and the problem solved
Querying a database is a long-lasting IO-operation that shall at best be done asynchronously to prevent blocking the current thread. Today's database drivers targeting .Net implement support for the `IQueryable` type. This type allows to record database queries by calling any of the LINQ methods, like `Where`, `Select`, `OrderBy`. When the instance is casted to `IEnumerable`, the recorded database query is executed. As this cast as well as the operations on the `IEnumerable` type are inherently synchronously, the database driver has no chance, but blocking the thread, even if it only allocated a database cursor, that is wrapped to implement the `IEnumerable` type.  
Most database drivers implement custom methods to evaluate an `IQueryable` instance asynchronously, as well as some (or all) of the LINQ functions that return a scalar like `int` or `bool`. This however is highly dependent on the database driver used. This prevents to write the data access code in an independent fashion, that a database driver can be plugged into. For example EntityFramework Core implemented these functions in its [EntityFrameworkQueryableExtensions](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions), MongoDB defines its own interface that inherits from `IQueryable` and defined the mentioned functions on this interface in its type [MongoQueryable](https://mongodb.github.io/mongo-csharp-driver/2.4/apidocs/html/T_MongoDB_Driver_Linq_MongoQueryable.htm). 
This makes casts to the database driver dependent type necessary, which makes it impossible to build an independent general purpose data access API using the type `IQueryable`.

## How does this prototype solve the problem?
### The user API
The solution, as implemented here builds on top of the `IAsyncEnumerable` and `IAsyncQueryable` types. These are the asynchronous equivalents of the `IEnumerable` and `IQueryable` types, respectively. The solution provides instances of types `IAsyncQueryable` that can be accessed for a database driver. The `IAsyncQueryable` instances make it possible to record a query (via generic LINQ method calls) and execute it in an asynchronous way. Asynchronous execution is done by either casting to `IAsyncEnumerable` or calling one of the non-chainable methods. The latter are the methods that return an awaitable type resulting in a scalar, like `MaxAsync` or `AnyAsync`.  

### What is needed for a database driver to support this?
To support a database driver in this scenario, the database driver needs **at least** support for LINQ queries via the `IQueryable` type. Additionally a database provider needs specific functionality to asynchronously evaluate a query returning a results of type `IAsyncEnumerable`. For better performance, there are several other functions that the database driver can implement, like `MaxAsync` or `AnyAsync` (See section Database driver binding for further information).

### How does this work?
We provide the user a puppet instance of type `IAsyncQueryable` that LINQ methods can be called on. When the query is executed, the recorded query is translated to calls to LINQ methods on type `IQueryable` that the database driver understands and is executed via the database driver. The set of APIs defined on `IAsyncQueryable` is much broader than on type `IQueryable`. For example, it is possible to specify asynchronous predicates and selectors. It is therefore not possible to translate all possible queries. A query forms a tree of expressions, where the leafs of the tree are the raw sets of data. There may be one or multiple leaf nodes. The row sets of data are depending on the type of database and driver used. For example, they are tables for SQL database, documents for MongoDB databases. This tree is translated bottom up. When the translator is not able to translate a call, the already translated sub-tree is replaces with a special node, that performs the actual query execution on the subtree. The result of the tree is executed in-memory in an asynchronous post-processing. This can be disabled, via configuration. In this case an exception is thrown for all post-processors that are not obvious and clearly visible in the user-code, like `ToListAsync`. Methods that cannot be chained, like `MaxAsync` or `AnyAsync` need special attention and are translated in an optimized way.

## Database driver binding
To implement support for a database driver, create a class that inherits from `AsyncQueryableAdapter.QueryAdapterBase` and implement at least the methods `GetQueryable<T>` and `EvaluateAsync<T>`. For better performance, implement any of the virtual methods that the database driver has native support for. For the virtual methods, where there is no override, a specialized polyfill is used.

Say you use MongoDB with the [official C# driver](https://www.nuget.org/packages/MongoDB.Driver). You want to use the `IAsyncQueryable` to build your data-access layer in a database independent fashion. Your MongoDB specific query-adapter may look like in the following snippet.
```
internal sealed class MongoDBQueryAdapter : QueryAdapterBase
{
    private readonly IMongoDatabase _database;

    public MongoDBQueryAdapter(IMongoDatabase database, AsyncQueryableOptions options) : base(options)
    {
        if (database is null)
            throw new ArgumentNullException(nameof(database));

        _database = database;
    }

    protected override IQueryable<T> GetQueryable<T>()
    {
        return _database.GetCollection<T>(nameof(T)).AsQueryable();
    }

    protected override async IAsyncEnumerable<T> EvaluateAsync<T>(
        IQueryable<T> queryable,
        [EnumeratorCancellation] CancellationToken cancellation)
    {
        var list = await (queryable as IMongoQueryable<T>)
            .ToListAsync(cancellation)
            .ConfigureAwait(false);

        foreach(var entry in list)
        {
            yield return entry;
        }
    }
}
```

Please note that we assume here, that the collection name is the same as the type name and that the implementation of the `EvaluateAsync<T>` method is not very optimized.

As the MongoDB driver has special support for some of the virtual operations defined on `QueryAdapterBase`, we can override these for an improvement in performance. This is done in the following snippet exemplary for the `MinAsync` methods.

```
internal sealed class MongoDBQueryAdapter : QueryAdapterBase
{
    // Other (existing) members omitted for brevity.
    // [...]

    protected override ValueTask<TResult> MinAsync<TSource, TResult>(
        IQueryable<TSource> source, 
        Expression<Func<TSource, TResult>> selector, 
        CancellationToken cancellation)
    {
        return new ValueTask<TResult>(
            (source as IMongoQueryable<TSource>).MinAsync(selector, cancellation));
    }

    protected override ValueTask<TSource> MinAsync<TSource>(
        IQueryable<TSource> source, 
        CancellationToken cancellation)
    {
        return new ValueTask<TSource>(
            (source as IMongoQueryable<TSource>).MinAsync(cancellation));
    }

    // Override all the other virtual members that the database driver has special support for.
    // [...]
}
```

## How to use
When there is a query adapter for the database driver that you use, it can be used to access an instance (or multiple instances) of type `IAsyncQueryable` via a call to the method `GetAsyncQueryable<T>()`. The result can be used to perform custom queries. This is demonstrated in the following sample using the MongoDB specific implementation from above. 

```
static async Task Main() 
{
    var database = ... // Get your MongoDB database instance via the driver

    // Build the database driver-specific query adapter
    var queryAdapter = new MongoDBQueryAdapter(database, AsyncQueryableOptions.Default);

    // Create the generic data access layer
    var dal = new DataAccessLayer(queryAdapter);

    var names = dal.GetOrderedMajorPersonNamesAsync();

    await foreach(var name in names)
    {
        Console.WriteLine(name);
    }
}

sealed class DataAccessLayer
{
    private readonly QueryAdapterBase _queryAdapter;

    public DataAccessLayer(QueryAdapterBase queryAdapter)
    {
        if (queryAdapter is null)
            throw new ArgumentNullException(nameof(queryAdapter));

        _queryAdapter = queryAdapter;
    }

    private const int MAJOR_MIN_AGE = 18;

    public IAsyncEnumerable<string> GetOrderedMajorPersonNamesAsync()
    {
        // Access the async query-able from the query adapter
        var queryable = _queryAdapter.GetAsyncQueryable<Person>();

        // Record the LINQ query
        var result = from person in queryable
                     where person.Age >= MAJOR_MIN_AGE
                     select person.Name;

        // Execute query
        // Result can be cast to IAsyncEnumerable<string> implicitly
        return result;
    }
}

record Person(string Name, int Age);
```
Please note, that the data access layer is generic and does not in any way depend on the database driver used.  

# Feature roadmap

This is a prototype. It is **not** feature complete. There are currently no releases, as this is a work in progress and in no way near to feature complete. Please do **not** use in productive code.

* [x] Generic query adapter as API to the database driver
* [x] Optimized query adapter polyfills for methods with no override
* [x] Generic translation infrastructure
    * [x] Custom `IAsyncQueryable` implementation
    * [x] Expression visitor
    * [x] Translate expression leafs
    * [x] Expression node translation functionality (via base type)
    * [x] In-memory fallback for non-translatable queries
* [ ] Support and test explicit post-process operations
    * [ ] ToArrayAsync
    * [ ] ToDictionaryAsync, ToDictionaryAwaitAsync, ToDictionaryAwaitWithCancellationAsync
    * [ ] ToHashSetAsync
    * [ ] ToListAsync
    * [ ] ToLookupAsync, ToLookupAwaitAsync, ToLookupAwaitWithCancellationAsync
* [ ] Expression node translators
    * [ ] Default translator for chain-able operations
        * [x] Basic implementation
        * [x] Support for operations that accept async selectors/predicates
        * [ ] Support for operations that accept instances of type `IAsyncEnumerable`
        * [ ] Support and test
            * [ ] AsAsyncQueryable (NOP)         
            * [ ] Append
            * [ ] Cast
            * [ ] Concat
            * [ ] DefaultIfEmpty
            * [ ] Distinct
            * [ ] Except
            * [ ] GroupJoin, GroupJoinAwait, GroupJoinAwaitWithCancellation
            * [ ] Intersect
            * [ ] Join, JoinAwait, JoinAwaitWithCancellation
            * [ ] OfType
            * [ ] OrderBy, OrderByAwait, OrderByAwaitWithCancellation
            * [ ] OrderByDescending, OrderByDescendingAwait, OrderByDescendingAwaitWithCancellation
            * [ ] Prepend
            * [ ] Reverse
            * [ ] Select, SelectAwait, SelectAwaitWithCancellation
            * [ ] SelectMany, SelectManyAwait, SelectManyAwaitWithCancellation
            * [ ] Skip
            * [ ] SkipLast
            * [ ] SkipWhile, SkipWhileAwait, SkipWhileAwaitWithCancellation
            * [ ] Take
            * [ ] TakeLast
            * [ ] TakeWhile, TakeWhileAwait, TakeWhileAwaitWithCancellation
            * [ ] ThenBy, ThenByAwait, ThenByAwaitWithCancellation
            * [ ] ThenByDescending, ThenByDescendingAwait, ThenByDescendingAwaitWithCancellation
            * [ ] Union
            * [ ] Where, WhereAwait, WhereAwaitWithCancellation
            * [ ] Zip, ZipAwait, ZipAwaitWithCancellation
    * [x] Aggregate operation translator
        * [x] Basic support
        * [x] Seed support
        * [x] Support for async accumulators and resultSelectors (when translatable to sync)
        * [x] Unit-test   
    * [x] All operation translator
        * [x] Basic support
        * [x] Support for async predicates (when translatable to sync predicates)
        * [x] Unit-test
    * [x] Any operation translator
        * [x] Basic support
        * [x] Support for async predicates (when translatable to sync predicates)
        * [x] Unit-test
    * [x] Average operation translator
        * [x] Basic support
        * [x] Support for async selectors (when translatable to sync selectors)
        * [x] Unit-test
    * [x] Contains operation translator
        * [X] Basic support
        * [X] Unit-test
    * [x] Count operation translator
        * [x] Basic support
        * [x] Support for async predicates (when translatable to sync predicates)
        * [x] Unit-test
    * [x] ElementAt operation translator
        * [x] Basic support
        * [x] Support for ElementAtDefault
        * [x] Unit-test
    * [x] First operation translator
        * [x] Basic support
        * [x] Support for async predicates (when translatable to sync selectors)
        * [x] Support for FirstOrDefault
        * [x] Unit-test
    * [ ] GroupBy operation translator, GroupByAwait, GroupByAwaitWithCancellation
        * [ ] Basic support
            * [x] Translator implementation
            * [ ] Special TranslatedQueryable type for grouped sequences
                * [x] Special-case support in default translator
                * [x] Special-case support in method processor in preparation of post-processing
                * [x] Special-case support in query provider to evaluate query
                * [ ] Special-case support in all operation translators
        * [ ] Support for async predicates (when translatable to sync predicates)
        * [ ] Support for translation of known functions in chained operations
        * [ ] Unit-test
    * [x] Last operation translator
        * [x] Basic support
        * [x] Support for async predicates (when translatable to sync predicates)
        * [x] Support for LastOrDefault
        * [x] Unit-test
    * [x] LongCount operation translator
        * [x] Basic support
        * [x] Support for async predicates (when translatable to sync predicates)
        * [x] Unit-test
    * [x] Max operation translator
        * [x] Basic support
        * [x] Support for async selectors (when translatable to sync selectors)
        * [x] Unit-test
    * [x] Min operation translator
        * [x] Basic support
        * [x] Support for async selectors (when translatable to sync selectors)
        * [x] Unit-test    
    * [x] SequenceEqual operation translator
        * [x] Basic support
        * [x] Support for EqualityComparer
        * [x] Unit-test
    * [x] Single operation translator
        * [x] Basic support
        * [x] Support for async predicates (when translatable to sync selectors)
        * [x] Support for SingleOrDefault
        * [x] Unit-test
    * [x] Sum operation translator
        * [x] Basic support
        * [x] Support for async selectors (when translatable to sync selectors)
        * [x] Unit-test
* [ ] Nested-query support (f.e. A query in a predicate); Sub-queries are supported via basic support
* [ ] Support combining mulitple queryables
    * [ ] From the same query adapter
    * [ ] From the same "family" of query adapters (Needed for MongoDB support; query adapters belong to the same family if they share the same database and transaction)
    * [ ] From different query adapter
* [ ] End-2-end tests
* [ ] Generic MongoDB database driver support
* [ ] Generic EF-Core database driver support
