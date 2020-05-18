using ApiBox.Greeter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiBox.Api.WebApi.Greeter
{
    [Route("api/Greeting")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<GreetingResponse>> GetSingle(string name, [FromServices] IGreeter greeter)
        {
            var result = greeter.SayHello(name);

            return Ok(GreetingResponse.MapFrom(result));
        }
    }
}