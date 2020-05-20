using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace ApiBox.Api.gRPC
{
    public class Program : ProgramBase<Startup>
    {
        public static int Main(string[] args)
        {
            var program = new Program();
            return program.Run(args);
        }

        protected override void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 8443, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2;
                    listenOptions.UseConnectionLogging();
                });
            });
        }
    }
}
