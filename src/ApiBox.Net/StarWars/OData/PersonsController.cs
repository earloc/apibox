using ApiBox.StarWars;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.Net.StarWars.OData
{

    [ControllerName("StarWars")]
    [Route("odata/StarWars/Persons")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class PersonsController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<PersonEntity>> GetAll([FromServices]IStarWarsSource starWars)
        {
            var query = await starWars.GetPersonsAsync();
            return PersonEntity.Map(query);
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<PersonEntity?> GetSingle(string id, [FromServices]IStarWarsSource starWars)
        {
            var query = await starWars.GetPersonSingleAsync(id);
            return PersonEntity.Map(query);
        }
    }
}
