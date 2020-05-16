using ApiBox.StarWars;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.Net.StarWars.OData
{

    public class PersonsController : ODataController
    {
        [EnableQuery]
        public async Task<IEnumerable<PersonEntity>> Get([FromServices]IStarWarsSource starWars)
        {
            var query = await starWars.GetPersonsAsync();
            return PersonEntity.Map(query);
        }

        [EnableQuery]
        public async Task<PersonEntity?> Get(string id, [FromServices]IStarWarsSource starWars)
        {
            var query = await starWars.GetPersonSingleAsync(id);
            return PersonEntity.Map(query);
        }
    }
}
