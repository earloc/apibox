using ApiBox.PingPong;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBox.Net.AspNetCore.OData
{
    public class PingsController : ODataController
    {
        [EnableQuery]
        [HttpGet]
        public IQueryable<Pong> Get([FromServices]IPingPong pingPong)
        {
            var pongs = pingPong.GetAsync().GetAwaiter().GetResult();
            return pongs.AsQueryable();
        }
    }
}
