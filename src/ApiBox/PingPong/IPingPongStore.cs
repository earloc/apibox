using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBox.PingPong
{
    public interface IPingPongStore
    {
        Task<Pong> InsertAsync(Ping ping);
        Task<IEnumerable<Pong>> GetAsync();
    }
}