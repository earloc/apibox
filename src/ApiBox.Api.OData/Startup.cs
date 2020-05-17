using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace ApiBox.Api.OData
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiBox();

            services.AddControllers(_ => _.EnableEndpointRouting = false);
            services.AddApiVersioning(_ =>
            {
                _.ReportApiVersions = true;
                _.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddOData().EnableApiVersioning();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "ApiBox.Api.OData",
                    Version = "v1"
                });
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

            app.UseRouting();

            app.UseMvc(routes =>
            {
                var builder = new ODataConventionModelBuilder();
                builder
                    .AddPingPong()
                    .AddGreeter()
                    .AddStarWars()
                ;

                routes.MapVersionedODataRoute("odata", "odata", builder.GetEdmModel(), new ApiVersion(1, 0));
            });

            app.UseSwagger();
            app.UseSwaggerUI(swagger => {
                swagger.SwaggerEndpoint("swagger/v1/swagger.json", "ApiBox.APi.OData");
                swagger.RoutePrefix = "";
            });
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
