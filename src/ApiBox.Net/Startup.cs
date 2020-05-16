using ApiBox.PingPong;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Linq;

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

            services.AddGrpc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiBox.Net", Version = "v1" });
            });

            SetOutputFormatters(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.MapPingPongODataRoute();
                endpoints.MapStarWarsODataRoute();

                endpoints.MapGreeterGRPCService();
                endpoints.MapGreeterODataRoute();

            });

            app.UseGraphQL<ApiBoxSchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiBox.Net V1");
                c.RoutePrefix = "";
            });

            //hack: warmup PingPong
            InMemoryPingPongStore.BeginWarmup();
        }

        private static void SetOutputFormatters(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                var outputFormatters =
                    options.OutputFormatters.OfType<ODataOutputFormatter>()
                        .Where(foramtter => foramtter.SupportedMediaTypes.Count == 0);

                foreach (var outputFormatter in outputFormatters)
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
                }
            });
        }
    }
}
