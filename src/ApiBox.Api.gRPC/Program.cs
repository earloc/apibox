using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ApiBox.Api.gRPC
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
