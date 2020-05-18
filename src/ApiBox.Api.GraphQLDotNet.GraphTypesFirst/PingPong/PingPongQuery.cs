using ApiBox.PingPong;
using GraphQL.Types;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst.PingPong
{
    public class PingPongQuery : ObjectGraphType
    {
        public PingPongQuery(IDependency<IPingPongStore> source)
        {
            Field<PongQueryOutput>("allPongs", resolve: context => source.Instance.GetAsync());
        }
    }
}
