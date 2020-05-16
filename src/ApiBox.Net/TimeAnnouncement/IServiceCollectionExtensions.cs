using ApiBox.TimeAnnouncment;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTimeAnnouncement(this IServiceCollection services)
        {
            services.AddScoped<ITimeAnnouncer, CurrentTimeAnnouncer>();
            return services;
        }
    }
}
