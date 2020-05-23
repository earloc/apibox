using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiBox.Api.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiBox();
            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "ApiBox.Api.WebApi",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.Map("/apibox/webapi", _ =>
            {
                if (env.IsDevelopment())
                {
                    _.UseDeveloperExceptionPage();
                }

                _.UseRouting();

                _.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                _.UseSwagger();
                _.UseSwaggerUI(swagger =>
                {
                    swagger.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
                    swagger.RoutePrefix = "";
                });
            });
            
        }
    }
}
