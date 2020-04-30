using ApiBox.PingPong;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Startup
    {
        public static IServiceCollection AddPingPong(this IServiceCollection services)
        {
            services.AddScoped<IPingPong, InMemoryPingPong>();
            return services;
        }
    }
}
