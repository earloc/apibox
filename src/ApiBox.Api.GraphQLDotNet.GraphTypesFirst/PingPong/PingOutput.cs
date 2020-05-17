using ApiBox.PingPong;
using GraphQL.Types;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst.PingPong
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
