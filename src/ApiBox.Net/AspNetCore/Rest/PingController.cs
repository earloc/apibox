using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBox.PingPong;
using Microsoft.AspNetCore.Mvc;

namespace ApiBox.Net.AspNetCore.Rest
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PingResponse>>> Pongs ([FromServices] IPingPong pingPong)
        {
            var query = await pingPong.GetAsync();
            var result = query.ToArray();

            return Ok(result.Select(_ => new PingResponse(_)));
        }

        [HttpPost]
        public async Task<ActionResult<PingResponse>> Ping (string message, [FromServices] IPingPong pingPong) {
            var pong = await pingPong.PingAsync(new Ping(message));
            return Ok(new PingResponse(pong));
        }
    }
}