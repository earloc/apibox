using ApiBox.Greeter;

namespace ApiBox.Api.gRPC.Greeter
{
    public partial class GreetingReply
    {
        public static GreetingReply MapFrom(Greeting source) => new GreetingReply() { Content = source.Content };
    }
}
