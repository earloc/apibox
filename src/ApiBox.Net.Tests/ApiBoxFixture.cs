using MathNet.Numerics.Statistics;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ApiBox.Net.Tests
{
    public class ApiBoxFixture
    {
        protected readonly HttpClient api;
        public ApiBoxFixture()
        {
            var factory = new WebApplicationFactory<Startup>();
            api = factory.CreateClient();
        }

        public async Task MeasureAsync(Func<Task<Func<Task>>> sut, ApiStack apiStack, int sampleCount, [CallerMemberName] string testName = null)
        {
            //warmup
            var warmupAssertion = await sut().ConfigureAwait(false);

            await warmupAssertion();

            var samples = new double[sampleCount];
            foreach (var i in Enumerable.Range(0, sampleCount))
            {
                var start = DateTimeOffset.Now;

                var assertion = await sut().ConfigureAwait(false);

                var end = DateTimeOffset.Now;

                await assertion();

                samples[i] = (end - start).TotalMilliseconds;
            }


            var stack = apiStack.ToString();
            var min = samples.Minimum();
            var max = samples.Maximum();
            var p50th = samples.Percentile(50);
            var p90th = samples.Percentile(90);
            var p95th = samples.Percentile(95);
            var median = samples.Median();
            var total = samples.Sum();

            var fileName = $"../../../{testName}.csv";

            if (!File.Exists(fileName))
                File.AppendAllText(fileName, "{sampleCount};{stack};{min};{max};{p50th};{p90th};{p95th};{median};{total}\n");

            File.AppendAllText(fileName, $"{sampleCount};{stack};{min};{max};{p50th};{p90th};{p95th};{median};{total}\n");
        }
    }
}