using ApiBox.StarWars;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddStarWars(this IServiceCollection services)
        {
            services.AddSingleton<IStarWarsSource, InMemoryStarWarsSource>();
            return services;
        }
    }
}
