using ApiBox.PingPong;
using GraphQL.Types;

namespace ApiBox.Net.PingPong.GraphQL.GraphTypeFirst
{
    public class PingPongQuery : ObjectGraphType
    {
        public PingPongQuery(IDependency<IPingPongStore> source)
        {
            Field<PongQueryOutput>("allPongs", resolve: context => source.Instance.GetAsync());
        }
    }
}
