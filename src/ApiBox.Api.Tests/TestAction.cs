using MathNet.Numerics.Statistics;
using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ApiBox.Api.Tests
{
    public delegate Task<Func<Task>> TestAction();

    public static class TestActionExtensions
    {
        public static async Task<int> MeasureAsync(this TestAction testAction, ApiStack apiStack, int sampleCount, [CallerMemberName] string testName = null)
        {
            //warmup
            var warmupAssertion = await testAction();

            await warmupAssertion();

            var samples = new double[sampleCount];
            foreach (var i in Enumerable.Range(0, sampleCount))
            {
                var start = DateTimeOffset.Now;

                var assertion = await testAction();

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

            return samples.Length;
        }
    }
}