using ApiBox.PingPong;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ApiBox.Net
{
    public class Startup
    {
        public const string GraphQLNet_GraphTypesFirst = "/gqlnet";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddPingPong();
            services.AddStarWars();
            services.AddTimeAnnouncement();

            services.AddControllers();
            services.AddOData();

            services.AddHttpContextAccessor();
            services
                .AddSingleton(typeof(IDependency<>), typeof(HttpContextDependency<>))
                .AddSingleton<ApiBoxSchema>()
                .AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
                .AddSystemTextJson()
                .AddGraphTypes(typeof(ApiBoxSchema))

            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSerilogRequestLogging();

            //app.Use(async (context, next) =>
            //{

            //    using var reader = new StreamReader(context.Request.Body, leaveOpen: true);

            //    var content = await reader.ReadToEndAsync();


            //    await next();
            //});


            app.UseRouting();

            app.UseEndpoints(routes =>
            {
                routes.MapControllers();
                routes.MapPingPongODataRoute();
                routes.MapStarWarsODataRoute();
                routes.MapTimeAnnouncerODataRoute();
            });

            app.UseGraphQL<ApiBoxSchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            //hack: warmup PingPong
            InMemoryPingPongStore.BeginWarmup();
        }
    }
}
