using ApiBox.PingPong;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.Net.PingPong.OData
{
    [ControllerName("PingPong")]
    [Route("odata/Pongs")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class PongsController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<PongEntity>> GetAll([FromServices]IPingPongStore pingPong)
        {
            var pongs = await pingPong.GetAsync();
            return PongEntity.MapFrom(pongs);
        }
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<PongEntity?> GetSingle(string id, [FromServices]IPingPongStore pingPong)
        {
            var pong = await pingPong.GetSingleAsync(id);
            return PongEntity.MapFrom(pong);
        }
    }
}
