/*
using ApiBox.Api.Tests;

using GraphTypesFirstStartup = ApiBox.Api.GraphQLDotNet.GraphTypesFirst.Startup;
*/
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Try.Greeter;

namespace Try
{
    static class Program
    {
        static async Task Main(
            string region = null,
            string[]? args = null)
        {

            var parts = region.Split("_", StringSplitOptions.RemoveEmptyEntries);

            var topic = parts.First();
            var sample = parts.Skip(1).First();
            var stack = parts.Skip(2).First();

            var services = new ServiceCollection();

            services.Scan(_ => 
            {
                _.FromEntryAssembly()
                    .AddClasses()
                    .AsSelf()
                    .WithLifetime(ServiceLifetime.Scoped);
            });

            services.AddHttpClient("WebApi", client => {
                client.BaseAddress = new Uri("http://localhost:8001");
            });

            services.AddHttpClient("GraphQL", client => {
                client.BaseAddress = new Uri("http://localhost:8003");
            });


            var provider = services.BuildServiceProvider();

            using var scope = provider.CreateScope();

            ISampleProvider sampleProvider = topic switch
            {
                "Greeter" => scope.ServiceProvider.GetRequiredService<GreeterSampleProvider>(),
                _ => new NullSample()
            };

            var sampleAction = sampleProvider.Select(stack, sample);

            await sampleAction();

        }


        

    }
}
