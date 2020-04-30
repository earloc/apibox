using System;
using System.Threading.Tasks;

namespace ApiBox.PingPong
{
    public interface IPingPong
    {
        Task<Pong> PingAsync(Ping ping, TimeSpan? delay);
    }
}