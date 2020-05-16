using ApiBox.PingPong;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class PIServiceCollectionExtensionsngPongStartup
    {
        public static IServiceCollection AddPingPong(this IServiceCollection services)
        {
            services.AddSingleton<IPingPongStore, InMemoryPingPongStore>();
            return services;
        }
    }
}
