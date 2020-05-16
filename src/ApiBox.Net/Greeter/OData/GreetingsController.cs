using ApiBox.Greeter;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ApiBox.Net.Greeter.OData
{
    [ControllerName("Greeter")]
    [Route("odata/Greetings")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class GreetingsController : ODataController
    {
        [HttpGet("{name}")]
        [EnableQuery]
        public GreetingEntity? GetSingle(string name, [FromServices]IGreeter greeter)
        {
            var result = greeter.Greet(name);
            return GreetingEntity.MapFrom(result);
        }
    }
}
