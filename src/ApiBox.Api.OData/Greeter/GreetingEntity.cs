using ApiBox.Greeter;

namespace ApiBox.Api.OData.Greeter
{
    public class GreetingEntity
    {

        public string Message { get; set; } = "Hello";

        internal static GreetingEntity? MapFrom(Greeting? source) => source switch
        {
            Greeting greeting => new GreetingEntity() { Message = greeting.Content },
            _ => null
        };

    }
}
