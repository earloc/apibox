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
        public async Task<ActionResult<PingResponse>> Ping (string message, [FromServices] IPingPong pingPong) {
            var pong = await pingPong.PingAsync(new Ping(message));
            return new PingResponse(pong);
        }
    }
}