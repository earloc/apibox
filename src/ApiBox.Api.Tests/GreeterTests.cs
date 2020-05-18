using ApiBox.Api.gRPC;
using FluentAssertions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiBox.Api.Tests
{
    public class GreeterTests : IClassFixture<ApiBoxFixture>
    {
        private readonly ApiBoxFixture fixture;

        public GreeterTests(ApiBoxFixture fixture)
        {
            this.fixture = fixture;
        }

        private readonly string Measure_Greeter_SayHello_Sequential = nameof(Measure_Greeter_SayHello_Sequential);

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [Trait("ApiStack", "OData")]
        [Trait("ClientStack", "HttpClient")]
        public async Task Measure_Greeter_SayHello_Sequential_OData(int numberOfsamples)
        {
            var sut = this.fixture.OData();

            TestAction act = () => sut.HttpGet("odata/Greetings/greetling?api-version=1.0");

            var samples = await act.MeasureAsync(ApiStack.OData, numberOfsamples, Measure_Greeter_SayHello_Sequential);

            samples.Should().Be(numberOfsamples);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [Trait("ApiStack", "WebApi")]
        [Trait("ClientStack", "HttpClient")]
        public async Task Measure_Greeter_SayHello_Sequential_WebApi(int numberOfsamples)
        {
            var sut = this.fixture.WebApi();

            TestAction act = () => sut.HttpGet("api/Greeting/greetling");

            var samples = await act.MeasureAsync(ApiStack.WebApi, numberOfsamples, Measure_Greeter_SayHello_Sequential);

            samples.Should().Be(numberOfsamples);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [Trait("ApiStack", "GraphQLDotNet.GraphTypesFirst")]
        [Trait("ClientStack", "HttpClient")]
        public async Task Measure_Greeter_SayHello_Sequential_GraphQLDotNet_GraphTypesFirst(int numberOfsamples)
        {
            var payload = new GraphQlPayload()
            {
                query = @"
                query {
                  greeter {
                    sayHello(name:""greetling""){
                      content
                    }
                  }
                }"
            }.ToJson();
            var content = new StringContent(payload, Encoding.Default, "application/json");

            var sut = this.fixture.GraphQL();

            TestAction act = () => sut.GraphQLPost("graphql", content);

            var samples = await act.MeasureAsync(ApiStack.GQLnet_TypesFirst, numberOfsamples, Measure_Greeter_SayHello_Sequential);

            samples.Should().Be(numberOfsamples);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [Trait("ApiStack", "gRPC")]
        [Trait("ClientStack", "HttpClient")]
        public async Task Measure_Greeter_SayHello_Sequential_GRPC(int numberOfsamples)
        {
            var sut = this.fixture.gRPC();

            var request = new GreetingRequest()
            {
                Name = "greetling"
            };

            TestAction act = async () =>
            {
                var reply = await sut.SayHelloAsync(request);
                return () => Task.FromResult(reply.Should().NotBeNull());
            };

            var samples = await act.MeasureAsync(ApiStack.GRPC, numberOfsamples, Measure_Greeter_SayHello_Sequential);

            samples.Should().Be(numberOfsamples);
        }
    }
}
