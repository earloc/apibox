using ApiBox.StarWars;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBox.Api.WebApi.StarWars
{
    [Route("api/Persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetAll([FromServices] IStarWarsSource starWars)
        {
            var query = await starWars.GetPersonsAsync();
            var result = query.ToArray();

            return Ok(PersonResponse.Map(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetSingle(string id, [FromServices] IStarWarsSource starWars)
        {
            var result = await starWars.GetPersonSingleAsync(id);

            return Ok(PersonResponse.Map(result));
        }
    }
}