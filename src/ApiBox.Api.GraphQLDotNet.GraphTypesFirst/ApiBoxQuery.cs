using ApiBox.Api.GraphQLDotNet.GraphTypesFirst.Greeter;
using ApiBox.Api.GraphQLDotNet.GraphTypesFirst.PingPong;
using ApiBox.Api.GraphQLDotNet.GraphTypesFirst.StarWars;
using GraphQL.Types;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst
{
    internal class ApiBoxQuery : ObjectGraphType<object>
    {
        public ApiBoxQuery()
        {
            Name = "Query";

            Field<PingPongQuery>("pingpong", resolve: context => new { });
            Field<StarWarsQuery>("starwars", resolve: context => new { });
            Field<GreeterQuery>("greeter", resolve: context => new { });
        }
    }
}