using ApiBox.Greeter;
using GraphQL.Types;

namespace ApiBox.Net.Greeter.GraphQL.GraphTypeFirst
{
    public class GreetingOutput : ObjectGraphType<Greeting>
    {
        public GreetingOutput()
        {
            Description = "A nice greeting";
            Field(_ => _.Content).Description("The greeting´s content (maybe not so nice)");
        }
    }
}
