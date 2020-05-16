using ApiBox.StarWars;
using System.Collections.Generic;
using System.Linq;

namespace ApiBox.Net.StarWars.OData
{
    public class PersonEntity
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        private static PersonEntity MapCore(Person person) => new PersonEntity()
        {
            Id = person.Id,
            Name = person.Name
        };

        internal static PersonEntity? Map(Person? result) => result switch
        {
            null => null,
            Person person => MapCore(person)
        };

        internal static IEnumerable<PersonEntity> Map(IEnumerable<Person> result) => result
                .Where(_ => _ != null)
                .Select(_ => MapCore(_));
    }
}
