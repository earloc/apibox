using ApiBox.PingPong;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBox.Net.PingPong.WebApi
{
    [ControllerName("PingPong")]
    [Route("api")]
    [ApiController]
    public class PingPongController : ControllerBase
    {
        [HttpGet("pongs")]
        public async Task<ActionResult<IEnumerable<PongResponse>>> GetAll([FromServices] IPingPongStore pingPong)
        {
            var query = await pingPong.GetAsync();
            var result = query.ToArray();

            return Ok(PongResponse.MapFrom(result));
        }

        [HttpPost("ping")]
        public async Task<ActionResult<PongResponse>> InsertSingle(string message, [FromServices] IPingPongStore pingPong)
        {
            var result = await pingPong.InsertAsync(new Ping(message));
            return Ok(PongResponse.MapFrom(result));
        }
    }
}