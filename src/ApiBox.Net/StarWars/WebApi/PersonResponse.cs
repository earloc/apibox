using ApiBox.StarWars;
using System.Collections.Generic;
using System.Linq;

namespace ApiBox.Net.StarWars.WebApi
{
    public class PersonResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        private static PersonResponse MapCore(Person source) => new PersonResponse()
        {
            Id = source.Id,
            Name = source.Name
        };

        internal static PersonResponse? Map(Person? sources) => sources switch
        {
            null => null,
            Person source => MapCore(source)
        };

        internal static IEnumerable<PersonResponse> Map(IEnumerable<Person> result) => result
                .Where(_ => _ != null)
                .Select(_ => MapCore(_));
    }
}
