using ApiBox.PingPong;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.Api.OData.PingPong
{
    [ApiVersion("1.0")]
    public class PongsController : ODataController
    {
        public async Task<IEnumerable<PongEntity>> Get([FromServices]IPingPongStore pingPong)
        {
            var pongs = await pingPong.GetAsync();
            return PongEntity.MapFrom(pongs);
        }
        public async Task<PongEntity?> Get(string key, [FromServices]IPingPongStore pingPong)
        {
            var pong = await pingPong.GetSingleAsync(key);
            return PongEntity.MapFrom(pong);
        }
    }
}
