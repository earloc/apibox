using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBox.Net.AspNetCore.Rest
{
    public static class Startup
    {
        public static IServiceCollection AddRest(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }

        public static IEndpointRouteBuilder MapRest(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();
            return endpoints;
        }
    }
}
