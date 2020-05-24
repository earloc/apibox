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
    public class GraphQLGreeterSamples : IGreeterSamples
    {
        private readonly HttpClient client;
        public GraphQLGreeterSamples(IHttpClientFactory factory)
        {
            client = factory.CreateClient("GraphQL");
        }

        public async Task SayHello()
        {
            var query = new GraphQlPayload()
            {

                query = SayHelloQuery()

            };

            var payLoad = query.ToStringContent();

            var response = await client.PostAsync("/graphql", payLoad);

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        private static string SayHelloQuery()
        {

            return
            #region Greeter_SayHello_GraphQL_Query

@"query {
    greeter {
        sayHello(name: ""greetling""){
            content
        }
    }
}"
            #endregion
            ;

        }
    }
}