using ApiBox.PingPong;
using GraphQL.Types;

namespace ApiBox.Net.PingPong.GraphQL.GraphTypeFirst
{
    public class PingOutput : ObjectGraphType<Ping>
    {
        public PingOutput()
        {
            Description = "A ping";
            Field(_ => _.Message).Description("The ping-message");
        }
    }
}
