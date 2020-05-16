using ApiBox.Greeter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiBox.Net.Greeter.WebApi
{
    [ControllerName("Greeter")]
    [Route("api/Greeting")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<GreetingResponse>> GetSingle(string name, [FromServices] IGreeter greeter)
        {
            var result = greeter.Greet(name);

            return Ok(GreetingResponse.MapFrom(result));
        }
    }
}