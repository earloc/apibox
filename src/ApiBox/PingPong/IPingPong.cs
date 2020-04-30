using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBox.PingPong
{
    public interface IPingPong
    {
        Task<Pong> PingAsync(Ping ping, TimeSpan? delay = null);
        Task<IQueryable<Pong>> GetAsync(TimeSpan? delay = null);
    }
}