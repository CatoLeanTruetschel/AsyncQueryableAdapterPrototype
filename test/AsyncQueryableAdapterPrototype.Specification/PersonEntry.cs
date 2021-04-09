using System;

namespace AsyncQueryableAdapterPrototype.Tests
{
    internal sealed record PersonEntry(Guid Id, string FirstName, string LastName, double Age, DateTime Birthday)
    {
        public PersonEntry(string firstName, string lastName, double age)
            : this(Guid.NewGuid(), firstName, lastName, age, DateTime.Now.AddDays(-age * 365)) { }
    }
}
