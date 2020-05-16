using ApiBox.Greeter;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTimeAnnouncement(this IServiceCollection services)
        {
            services.AddScoped<IGreeter, StaticGreeter>();
            return services;
        }
    }
}
