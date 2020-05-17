using ApiBox.StarWars;
using GraphQL.Types;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst.StarWars
{
    public class PersonOutput : ObjectGraphType<Person>
    {
        public PersonOutput()
        {
            Description = "A person from the star-wars universe";
            Field(_ => _.Id).Description("The id of the person");
            Field(_ => _.Name).Description("The name of the person");
        }
    }
}
