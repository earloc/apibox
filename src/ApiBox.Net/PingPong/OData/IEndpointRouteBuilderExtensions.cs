using ApiBox.PingPong;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace Microsoft.AspNetCore.Routing
{
    public static partial class IEndpointRouteBuilderExtensions
    {
        public static void MapPingPongODataRoute(this IEndpointRouteBuilder endpoints)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Pong>("Pongs").EntityType
                .HasKey(_ => _.Id)
                .Select().Count();

            endpoints.MapODataRoute("pingpong", "pingpong", builder.GetEdmModel());
        }
    }
}
