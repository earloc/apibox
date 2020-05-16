using ApiBox.Net.Greeter.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace Microsoft.AspNetCore.Routing
{
    public static partial class IEndpointRouteBuilderExtensions
    {
        public static void MapGreeterODataRoute(this IEndpointRouteBuilder endpoints)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<GreetingEntity>("Greetings").EntityType
               .HasKey(_ => _.Message)
               .Select().Count();

            endpoints.MapODataRoute("greetings", "odata", builder.GetEdmModel());
        }
    }
}
