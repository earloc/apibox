using ApiBox.StarWars;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.Api.OData.StarWars
{

    [Route("odata/persons")]
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

        public async Task<PersonEntity?> GetSingle(string id, ODataQueryOptions<PersonEntity> query, [FromServices]IStarWarsSource starWars)
        {
            var result = await starWars.GetPersonSingleAsync(id);
            return PersonEntity.Map(result);
        }
    }
}
