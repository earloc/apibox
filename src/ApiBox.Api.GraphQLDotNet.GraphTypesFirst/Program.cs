namespace ApiBox.Api.GraphQLDotNet
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
