using System;

namespace AsyncQueryableAdapterPrototype.Tests
{
    internal sealed record RelationshipEntry(Guid Id, Guid Person1Id, Guid Person2Id)
    {
        public RelationshipEntry(Guid id, PersonEntry person1, PersonEntry person2) : this(
            id,
            person1?.Id ?? throw new ArgumentNullException(nameof(person1)),
            person2?.Id ?? throw new ArgumentNullException(nameof(person2)))
        { }

        public RelationshipEntry(PersonEntry person1, PersonEntry person2)
            : this(Guid.NewGuid(), person1, person2) { }
    }
}
