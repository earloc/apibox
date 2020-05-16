using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiBox.PingPong
{
    public class InMemoryPingPongStore : IPingPongStore
    {
        private static readonly Lazy<IDictionary<string, Pong>> pongs = new Lazy<IDictionary<string, Pong>>(() => Seed(100), LazyThreadSafetyMode.ExecutionAndPublication);

        private static IDictionary<string, Pong> Seed(int count = 1000000)
        {
            var start = DateTimeOffset.Now;

            var dict = new Dictionary<string, Pong>(count);

            for (var i = 0; i < count; i++)
            {
                var pong = new Pong(new Ping(Guid.NewGuid().ToString()));
                pong.Created.At = start.AddMinutes(-i);

                dict.Add(Guid.NewGuid().ToString(), pong);
            }

            return dict;
        }

        public Task<IEnumerable<Pong>> GetAsync()
        {
            return Task.FromResult(pongs.Value.Values.AsEnumerable());
        }

        public Task<Pong> InsertAsync(Ping ping)
        {
            var pong = new Pong(ping);
            pongs.Value.Add(pong.Id, pong);
            return Task.FromResult(pong);
        }

        public static void BeginWarmup()
        {
            Task.Run(() => Console.WriteLine(pongs.Value.Count()));
        }

        public async Task<Pong?> GetSingleAsync(string id)
        {
            await Task.CompletedTask.ConfigureAwait(false);

            if (pongs.Value.ContainsKey(id))
                return pongs.Value[id];

            return default;
        }
    }
}
