using ApiBox.Greeter;

namespace ApiBox.Api.WebApi.Greeter
{
    public class GreetingResponse
    {
        public string Message { get; set; } = "Hello";

        internal static GreetingResponse MapFrom(Greeting source) => new GreetingResponse() { Message = source.Content };
    }
}
