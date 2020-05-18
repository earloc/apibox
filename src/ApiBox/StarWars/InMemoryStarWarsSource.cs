using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBox.StarWars
{
    public class InMemoryStarWarsSource : IStarWarsSource
    {
        public static IEnumerable<Person> Seed()
        {
            return new[]
            {
                new Person() { Id = "AS", Name = "Anakin Skywalker", HomePlanetId = "Tattoine" },
                new Person() { Id = "LS", Name = "Luke Skywalker",   HomePlanetId = "Tattoine" },
                new Person() { Id = "CB", Name = "Chewbacca",        HomePlanetId = "Kashyyk" },
                new Person() { Id = "SP", Name = "Sheev Palpatine",  HomePlanetId = "Naboo" },
                new Person() { Id = "HS", Name = "Han Solo",         HomePlanetId = "Corellia" }
            };
        }

        private readonly IDictionary<string, Person> persons = Seed().ToDictionary(x => x.Id);

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            await Task.CompletedTask.ConfigureAwait(false);

            return persons.Values;
        }

        public async Task<Person?> GetPersonSingleAsync(string id)
        {
            await Task.CompletedTask.ConfigureAwait(false);

            if (persons.ContainsKey(id))
            {
                return persons[id];
            }

            return default;
        }
    }
}
