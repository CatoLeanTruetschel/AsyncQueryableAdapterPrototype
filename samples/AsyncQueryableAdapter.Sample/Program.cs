/* License
 * --------------------------------------------------------------------------------------------------------------------
 * (C) Copyright 2021 Cato Léan Trütschel and contributors 
 * (https://github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * --------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncQueryableAdapter.Sample
{
    internal static class Program
    {
        private static Repository Repository { get; } = new Repository();

#pragma warning disable CS1998, IDE0060
        private static async Task Main(string[] args)
#pragma warning restore CS1998, IDE0060
        {
            var lastNamesSync = from person in Repository.People
                                where person.Age > 25 && person.LastName != "Adams" && person.Gender != Gender.Unknown
                                select person.LastName;

            lastNamesSync = lastNamesSync.Where(p => p.Length > 6);

            Console.WriteLine("Last names: " + string.Join(", ", lastNamesSync));

            var lastNamesAsync = from person in Repository.QueryAdapter.GetAsyncQueryable<Person>()
                                 where person.Age > 25 && person.LastName != "Adams" && person.Gender != Gender.Unknown
                                 select person.LastName;

            var lastNames = await lastNamesAsync.WhereAwait(p => new ValueTask<bool>(p.Length > 6)).ToArrayAsync();

            Console.WriteLine("Last names: " + string.Join(", ", lastNames));
            Console.WriteLine("Last names count: " + await lastNamesAsync.CountAsync());
            Console.WriteLine("Last names max length: " + await lastNamesAsync.Select(p => p.Length).MaxAsync());
        }
    }

    internal sealed class Repository
    {
        private readonly List<Person> _people;
        private readonly List<Relationship> _relationships;

        public Repository()
        {
            QueryAdapter = new RepositoryQueryAdapter(this);
            (_people, _relationships) = SeedData();
        }

        private static (List<Person> people, List<Relationship> relationships) SeedData()
        {
            var relationships = new List<Relationship>();

            var christopherWagner = new Person("Christopher", "Wagner", 22, Gender.Male);
            var juanaMartinez = new Person("Juana", "Martinez", 30);
            var davidEstes = new Person("David", "Estes", 53, Gender.Male);
            var ashSapp = new Person("Ash", "Sapp", 21, Gender.Diverse);

            var jasonRandolph = new Person("Jason", "Randolph", 46, Gender.Male);
            var patriciaStone = new Person("Patricia", "Stone", 48, Gender.Female);
            relationships.Add(new Relationship(jasonRandolph, patriciaStone));

            var julieDaniels = new Person("Julie", "Daniels", 29, Gender.Female);
            var deborahFerguson = new Person("Deborah", "Ferguson", 31, Gender.Female);
            relationships.Add(new Relationship(julieDaniels, deborahFerguson));

            var lewisAdams = new Person("Lewis", "Adams", 46, Gender.Male);
            var rondaBelle = new Person("Ronda", "Belle", 41, Gender.Diverse);
            relationships.Add(new Relationship(lewisAdams, rondaBelle));

            var robertPhillips = new Person("Robert", "Phillips", 36, Gender.Male);
            var meghanPhillips = new Person("Meghan", "Phillips", 34, Gender.Female);
            relationships.Add(new Relationship(robertPhillips, meghanPhillips));

            var people = new List<Person>
            {
                christopherWagner,
                juanaMartinez,
                davidEstes,
                ashSapp,
                jasonRandolph,
                patriciaStone,
                julieDaniels,
                deborahFerguson,
                lewisAdams,
                rondaBelle,
                robertPhillips,
                meghanPhillips
            };

            return (people, relationships);
        }

        public IQueryable<Person> People => _people.AsQueryable();
        public IQueryable<Relationship> Relationships => _relationships.AsQueryable();

        public RepositoryQueryAdapter QueryAdapter { get; }
    }

    internal sealed class RepositoryQueryAdapter : QueryAdapterBase
    {
        private readonly Repository _repository;

        public RepositoryQueryAdapter(Repository repository) : base(default)
        {
            if (repository is null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        protected override IQueryable<T> GetQueryable<T>()
        {
            if (typeof(T) == typeof(Person))
            {
                return (IQueryable<T>)_repository.People;
            }

            if (typeof(T) == typeof(Relationship))
            {
                return (IQueryable<T>)_repository.Relationships;
            }

            return Enumerable.Empty<T>().AsQueryable();
        }

        protected override IAsyncEnumerable<T> EvaluateAsync<T>(
            IQueryable<T> queryable,
            CancellationToken cancellation)
        {
            return queryable.ToAsyncEnumerable();
        }
    }

    internal record Person(string FirstName, string LastName, int Age, Gender Gender = Gender.Unknown);

    internal record Relationship(Person Partner1, Person Pertner2);

    internal enum Gender
    {
        Unknown,
        Female,
        Male,
        Diverse,
        Other,
        None
    }
}
