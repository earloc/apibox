/*
using ApiBox.Api.Tests;

using GraphTypesFirstStartup = ApiBox.Api.GraphQLDotNet.GraphTypesFirst.Startup;
*/
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Try
{
    static class Program
    {
        static async Task Main(
            string region = null,
            string[]? args = null)
        {

            var query = new GraphQlPayload()
            {
                query = GetQuery()
            };

            //Console.WriteLine(query.query);

            var content = new StringContent(query.ToJson(), Encoding.Default, "application/json");

            //var (_, response) = await graph.GraphQLPost(content);

            //var result = await response.Content.ReadAsStringAsync();

            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:8003")
            };

            var response = await client.PostAsync("/graphql", content);

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }


        static string GetQuery()
        {
            return
            #region gql

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
