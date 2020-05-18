using ApiBox.Greeter;
using Grpc.Core;
using System.Threading.Tasks;

namespace ApiBox.Api.gRPC
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly IGreeter greeter;

        public GreeterService(IGreeter greeter)
        {
            this.greeter = greeter;
        }

        public override Task<GreetingReply> SayHello(GreetingRequest request, ServerCallContext context)
        {
            var greeting = greeter.SayHello(request.Name);
            return Task.FromResult(GreetingReply.MapFrom(greeting));
        }
    }
}
