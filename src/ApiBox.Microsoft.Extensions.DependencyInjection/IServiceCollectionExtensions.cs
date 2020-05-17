using ApiBox.Greeter;
using ApiBox.PingPong;
using ApiBox.StarWars;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApiBox(this IServiceCollection services)
        {
            services.AddScoped<IPingPongStore, InMemoryPingPongStore>();
            services.AddScoped<IGreeter, StaticGreeter>();
            services.AddScoped<IStarWarsSource, InMemoryStarWarsSource>();

            return services;
        }

    }
}
