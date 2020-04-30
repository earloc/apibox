using System;
using System.Threading.Tasks;

namespace ApiBox.PingPong
{
    public class InMemoryPingPong : IPingPong
    {
        public async Task<Pong> PingAsync(Ping ping, TimeSpan? delay  = null)
        {
            if (delay.HasValue)
            {
                await Task.Delay(delay.Value);
            }
            return new Pong(ping);
        }
    }
}
