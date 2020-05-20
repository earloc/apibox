using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiBox.Api.GraphQLDotNet.GraphTypesFirst
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiBox();
            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
            })
                .AddSystemTextJson()
                .AddGraphTypes(typeof(Startup))
            ;

            services.AddSingleton<ISchema, ApiBoxSchema>();
            services.AddSingleton(typeof(IDependency<>), typeof(HttpContextDependency<>));
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground(new GraphQL.Server.Ui.Playground.GraphQLPlaygroundOptions()
            {
                Path = ""
            });
        }
    }
}
