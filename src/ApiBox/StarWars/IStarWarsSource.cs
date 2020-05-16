using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.StarWars
{
    public interface IStarWarsSource
    {
        public Task<IEnumerable<Person>> GetPersonsAsync();
        public Task<Person?> GetPersonSingleAsync(string id);
    }
}
