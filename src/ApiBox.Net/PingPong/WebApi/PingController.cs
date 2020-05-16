using ApiBox.PingPong;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBox.Net.PingPong.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<PongResponse>>> GetAll([FromServices] IPingPongStore pingPong)
        {
            var query = await pingPong.GetAsync();
            var result = query.ToArray();

            return Ok(PongResponse.MapFrom(result));
        }

        [HttpPost]
        public async Task<ActionResult<PongResponse>> InsertSingle(string message, [FromServices] IPingPongStore pingPong)
        {
            var result = await pingPong.InsertAsync(new Ping(message));
            return Ok(PongResponse.MapFrom(result));
        }
    }
}