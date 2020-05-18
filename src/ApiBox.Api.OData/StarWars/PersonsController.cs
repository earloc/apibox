using ApiBox.StarWars;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.Api.OData.StarWars
{

    [ApiVersion("1.0")]
    public class PersonsController : ODataController
    {
        public async Task<IEnumerable<PersonEntity>> Get([FromServices]IStarWarsSource starWars)
        {
            var query = await starWars.GetPersonsAsync();
            return PersonEntity.Map(query);
        }

        public async Task<PersonEntity?> Get(string key, ODataQueryOptions<PersonEntity> query, [FromServices]IStarWarsSource starWars)
        {
            var result = await starWars.GetPersonSingleAsync(key);
            return PersonEntity.Map(result);
        }
    }
}
