using ApiBox.PingPong;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Routing;
using System;

namespace ApiBox.Net.AspNetCore.OData
{
    public static class Startup
    {
        public static IEndpointRouteBuilder MapOData(this IEndpointRouteBuilder endpoints, IServiceProvider appServices)
        {
            var builder = new ODataConventionModelBuilder(appServices);
            builder.EntitySet<Pong>("Pings").EntityType.HasKey(_ => _.Id);

            endpoints.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
            endpoints.MapODataRoute("odata", "odata", builder.GetEdmModel());

            return endpoints;
        }
    }
}
