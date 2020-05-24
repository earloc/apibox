/*
using ApiBox.Api.Tests;

using GraphTypesFirstStartup = ApiBox.Api.GraphQLDotNet.GraphTypesFirst.Startup;
*/
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Try.Greeter;

namespace Try
{
    public class WebApiGreeterSamples : IGreeterSamples
    {
        private readonly HttpClient client;
        public WebApiGreeterSamples(IHttpClientFactory factory)
        {
            client = factory.CreateClient("WebApi");
        }

        public async Task SayHello()
        {

            var query = SayHelloQuery();
            var response = await client.GetAsync(query);

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        private static string SayHelloQuery()
        {

            return
            #region Greeter_SayHello_WebApi_Query
@"/api/Greeter/greetling"
            #endregion
            ;

        }
    }
}