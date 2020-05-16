using ApiBox.Net.PingPong.GraphQL.GraphTypeFirst;
using ApiBox.Net.StarWars.GraphQL.GraphTypeFirst;
using GraphQL.Types;

namespace ApiBox.Net
{
    internal class ApiBoxQuery : ObjectGraphType<object>
    {
        public ApiBoxQuery()
        {
            Name = "Query";

            Field<PingPongQuery>("pingpong", resolve: context => new { });
            Field<StarWarsQuery>("starwars", resolve: context => new { });
            Field<TimeAnnouncementQuery>("timeannouncements", resolve: context => new { });
        }
    }
}