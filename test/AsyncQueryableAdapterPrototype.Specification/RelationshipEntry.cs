﻿/* License
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
