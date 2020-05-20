using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApiBox.Api.Tests
{
    public class SystemUnderTest<TStartup> where TStartup : class
    {
        internal HttpClient HttpClient { get; }
        private readonly IHost host;
        private readonly TestServer server;

        public SystemUnderTest(Action<IWebHostBuilder> configure = null)
        {
            var builder = new HostBuilder()
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost
                        .UseTestServer()
                        .UseStartup<TStartup>();

                    configure?.Invoke(webHost);
                })
                .UseSerilog();

            host = builder.Start();
            server = host.GetTestServer();

            // Need to set the response version to 2.0.
            // Required because of this TestServer issue - https://github.com/aspnet/AspNetCore/issues/16940
            var responseVersionHandler = new ResponseVersionHandler();
            responseVersionHandler.InnerHandler = server.CreateHandler();

            var testClient = new HttpClient(responseVersionHandler);
            testClient.BaseAddress = new Uri("http://localhost");

            HttpClient = testClient;
        }

        public async Task<Func<Task>> HttpGet(string path)
        {
            var response = await HttpClient.GetAsync(path);
            return () => Task.FromResult(response.EnsureSuccessStatusCode());
        }

        public async Task<(Func<Task> Assertion, HttpResponseMessage Response)> GraphQLPost(HttpContent content, string path = "graphql")
        {
            var response = await HttpClient.PostAsync(path, content);
            return (async () =>
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                {
                    throw new Exception(result.ToString());
                }
            }, response);
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

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    HttpClient.Dispose();
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