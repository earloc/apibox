using ApiBox.PingPong;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.Net.PingPong.OData
{
    public class PingsController : ODataController
    {
        [EnableQuery]
        public async Task<IEnumerable<PongEntity>> Get([FromServices]IPingPongStore pingPong)
        {
            var pongs = await pingPong.GetAsync();
            return PongEntity.MapFrom(pongs);
        }
    }
}
