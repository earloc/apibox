using ApiBox.PingPong;
using GraphQL.Types;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst.PingPong
{
    public class PongOutput : ObjectGraphType<Pong>
    {
        public PongOutput()
        {
            Description = "A pong representing the result of a ping";
            Field(_ => _.Id).Description("The id of the pong");
            Field(_ => _.Message).Description("The pong-message derived from the original ping-message");
            Field(_ => _.Ping, type: typeof(PingOutput)).Description("The original ping which this pong is the response of");
        }
    }
}
