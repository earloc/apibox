using ApiBox.StarWars;
using GraphQL;
using GraphQL.Types;

namespace ApiBox.Net.StarWars.GraphQL.GraphTypeFirst
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(IDependency<IStarWarsSource> source)
        {
            Field<PersonQueryOutput>("allPersons", resolve: context => source.Instance.GetPersonsAsync());
            Field<PersonOutput>("person",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "id" }
                ),

                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return source.Instance.GetPersonSingleAsync(id);
                }
            );
        }
    }
}
