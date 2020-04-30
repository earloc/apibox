using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBox.PingPong
{
    public class InMemoryPingPong : IPingPong
    {
        private readonly IDictionary<string, Pong> pongs = new Dictionary<string, Pong>();

        public InMemoryPingPong()
        {
            for (int i = 0; i < 100; i++)
            {
                pongs.Add(Guid.NewGuid().ToString(), new Pong(new Ping(Guid.NewGuid().ToString())));
            }
        }

        public async Task<IQueryable<Pong>> GetAsync(TimeSpan? delay = null) {
            if (delay.HasValue)
            {
                await Task.Delay(delay.Value).ConfigureAwait(false);
            }
            return pongs.Values.AsQueryable();
        } 

        public async Task<Pong> PingAsync(Ping ping, TimeSpan? delay  = null)
        {
            if (delay.HasValue)
            {
                await Task.Delay(delay.Value).ConfigureAwait(false);
            }
            var pong = new Pong(ping);
            pongs.Add(pong.Id, pong);
            return pong;
        }
    }
}
