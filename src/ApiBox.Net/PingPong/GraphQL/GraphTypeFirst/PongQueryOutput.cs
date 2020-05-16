using ApiBox.PingPong;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace ApiBox.Net.PingPong.GraphQL.GraphTypeFirst
{
    public class PongQueryOutput : ObjectGraphType<IEnumerable<Pong>>
    {
        public PongQueryOutput()
        {
            Field<IntGraphType>("Count", resolve: context => context.Source.Count());
            Field<ListGraphType<PongOutput>>("Pongs", resolve: context => context.Source);
        }
    }
}
