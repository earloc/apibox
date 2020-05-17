using FluentAssertions;
using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ApiBox.Net.Tests.ApiStack;
namespace ApiBox.Api.Tests
{
    public class GreeterFixture : ApiBoxFixture
    {
        readonly string webApiUrl = "api/Greeting/greetling";
        readonly string oDataUrl = "odata/Greetings/greetling";
        readonly string graphQLUrl = "graphql";
        readonly GraphQlPayload graphQLPayload = new GraphQlPayload()
        {
            query = @"
            query {
              greeter {
                greet(name:""greetling""){
                  content
                }
              }
            }"
        };

        readonly GreetingRequest grpcRequest = new GreetingRequest() { Name = "greetling" };

        readonly HttpContent graphQLContent;
        readonly Greetings.GreetingsClient grpcClient;

        public GreeterFixture()
        {
            var payload = graphQLPayload.ToJson();

            graphQLContent = new StringContent(payload, Encoding.Default, "application/json");

            var channel = GrpcChannel.ForAddress(this.client.BaseAddress, new GrpcChannelOptions()
            {
                HttpClient = this.client
            });

            grpcClient = new Greetings.GreetingsClient(channel);
        }

        private async Task<Func<Task>> HttpGet(string path)
        {
            var response = await client.GetAsync(path);
            return () => Task.FromResult(response.EnsureSuccessStatusCode());
        }

        internal async Task<Func<Task>> gRPC()
        {
            var reply = await grpcClient.GreetAsync(grpcRequest);
            return () => Task.FromResult(reply.Should().NotBeNull());
        }

        private async Task<Func<Task>> GraphQlPost(string path, HttpContent payload)
        {
            var response = await client.PostAsync(path, payload).ConfigureAwait(false);
            return async () =>
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                {
                    throw new Exception(result.ToString());
                }
            };
        }

        internal Func<Task<Func<Task>>> GetGreetingActionFor(ApiStack apiStack)
        {
            return apiStack switch
            {
                WebApi => () => HttpGet(webApiUrl),
                OData => () => HttpGet(oDataUrl),
                GQLnet_TypesFirst => () => GraphQlPost(graphQLUrl, graphQLContent),
                GRPC => () => gRPC(),
                _ => throw new ArgumentException($"{apiStack} is not supported")
            };
        }
    }
}