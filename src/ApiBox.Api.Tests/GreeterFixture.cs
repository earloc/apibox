using Grpc.Net.Client;
using static ApiBox.Api.gRPC.Greeter;

namespace ApiBox.Api.Tests
{
    public class ApiBoxFixture
    {
        internal SystemUnderTest<OData.Startup> OData() => new SystemUnderTest<OData.Startup>();

        internal SystemUnderTest<GraphQLDotNet.GraphTypesFirst.Startup> GraphQL() => new SystemUnderTest<GraphQLDotNet.GraphTypesFirst.Startup>();

        internal SystemUnderTest<WebApi.Startup> WebApi() => new SystemUnderTest<WebApi.Startup>();

        internal GreeterClient gRPC()
        {
            var sut = new SystemUnderTest<gRPC.Startup>();

            var channel = GrpcChannel.ForAddress(sut.HttpClient.BaseAddress, new GrpcChannelOptions()
            {
                HttpClient = sut.HttpClient
            });

            var client = new GreeterClient(channel);

            return client;
        }
    }
}