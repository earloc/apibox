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
    public class ODataGreeterSamples : IGreeterSamples
    {
        private readonly HttpClient client;
        public ODataGreeterSamples(IHttpClientFactory factory)
        {
            client = factory.CreateClient("OData");
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
            #region Greeter_SayHello_OData_Query
@"/odata/Greetings/greetling?api-version=1.0"
            #endregion
            ;

        }
    }
}