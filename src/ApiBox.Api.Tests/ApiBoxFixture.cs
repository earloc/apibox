using MathNet.Numerics.Statistics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ApiBox.Api.Tests
{
    public class ApiBoxFixture : IDisposable
    {
        protected readonly HttpClient client;
        private readonly IHost host;
        private readonly TestServer server;
        public ApiBoxFixture()
        {
            var builder = new HostBuilder()
                .ConfigureWebHostDefaults(webHost => webHost
                    .UseTestServer()
                    .UseStartup<Startup>()
                )
                .UseSerilog();

            host = builder.Start();
            server = host.GetTestServer();

            // Need to set the response version to 2.0.
            // Required because of this TestServer issue - https://github.com/aspnet/AspNetCore/issues/16940
            var responseVersionHandler = new ResponseVersionHandler();
            responseVersionHandler.InnerHandler = server.CreateHandler();

            var testClient = new HttpClient(responseVersionHandler);
            testClient.BaseAddress = new Uri("http://localhost");

            this.client = testClient;
        }

        private class ResponseVersionHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var response = await base.SendAsync(request, cancellationToken);
                response.Version = request.Version;

                return response;
            }
        }

        public async Task<int> MeasureAsync(Func<Task<Func<Task>>> sut, ApiStack apiStack, int sampleCount, [CallerMemberName] string testName = null)
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

            return samples.Length;
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    client.Dispose();
                    host.Dispose();
                    server.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {

            Dispose(true);
        }

        #endregion
    }
}