using Grpc.Net.Client;
using static ApiBox.Api.gRPC.Greeter;

namespace ApiBox.Api.Tests
{
    public class ApiBoxFixture
    {
        internal SystemUnderTest<OData.Startup> OData() => new SystemUnderTest<OData.Startup>("/apibox/odata/");

        internal SystemUnderTest<GraphQLDotNet.GraphTypesFirst.Startup> GraphQL() => new SystemUnderTest<GraphQLDotNet.GraphTypesFirst.Startup>("/apibox/gqlnet_gtf/");

        internal SystemUnderTest<WebApi.Startup> WebApi() => new SystemUnderTest<WebApi.Startup>("/apibox/webapi/");

        internal GreeterClient gRPC()
        {
            var sut = new SystemUnderTest<gRPC.Startup>("/apibox/grpc/");

            var channel = GrpcChannel.ForAddress(sut.HttpClient.BaseAddress, new GrpcChannelOptions()
            {
                HttpClient = sut.HttpClient
            });

            var client = new GreeterClient(channel);

            return client;
        }
    }
}