using ApiBox.Greeter;
using Grpc.Core;
using System.Threading.Tasks;

namespace ApiBox.Net.Greeter.gRPC
{
    public class GreeterService : Greetings.GreetingsBase
    {
        private readonly IGreeter greeter;

        public GreeterService(IGreeter greeter)
        {
            this.greeter = greeter;
        }

        public override Task<GreetingReply> Greet(GreetingRequest request, ServerCallContext context)
        {
            var greeting = greeter.Greet(request.Name);
            return Task.FromResult(GreetingReply.MapFrom(greeting));
        }
    }
}
