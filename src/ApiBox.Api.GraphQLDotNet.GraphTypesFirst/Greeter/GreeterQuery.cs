using ApiBox.Greeter;
using GraphQL;
using GraphQL.Types;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst.Greeter
{
    public class GreeterQuery : ObjectGraphType
    {
        public GreeterQuery(IDependency<IGreeter> greeter)
        {
            Field<GreetingOutput>("Greet",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "name" }
                ),

                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    return greeter.Instance.Greet(name);
                }
            );
        }
    }
}
