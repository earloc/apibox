namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst
{
    public class Program : ProgramBase<Startup>
    {
        public static int Main(string[] args)
        {
            var program = new Program();
            return program.Run(args);
        }
    }
}
