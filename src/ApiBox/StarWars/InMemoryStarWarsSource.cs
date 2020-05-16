using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBox.StarWars
{
    public class InMemoryStarWarsSource : IStarWarsSource
    {
        private readonly Dictionary<string, Person> persons = Person.Seed().ToDictionary(x => x.Id);

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
