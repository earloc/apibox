using ApiBox.Greeter;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ApiBox.Api.OData.Greeter
{
    [ApiVersion("1.0")]
    public class GreetingsController : ODataController
    {
        public GreetingEntity? Get(string key, [FromServices]IGreeter greeter)
        {
            var result = greeter.SayHello(key);
            return GreetingEntity.MapFrom(result);
        }
    }
}
