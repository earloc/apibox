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
        public async Task<ActionResult<IEnumerable<Pong>>> Pongs ([FromServices] IPingPong pingPong)
        {
            var query = await pingPong.GetAsync();
            var result = query.ToArray();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Pong>> Ping (string message, [FromServices] IPingPong pingPong) {
            var pong = await pingPong.PingAsync(new Ping(message));
            return Ok(pong);
        }
    }
}