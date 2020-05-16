using ApiBox.Net.TimeAnnouncement.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace Microsoft.AspNetCore.Routing
{
    public static partial class IEndpointRouteBuilderExtensions
    {
        public static void MapTimeAnnouncerODataRoute(this IEndpointRouteBuilder routes)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<TimeEntity>("Announcements").EntityType
               .HasKey(_ => _.Value)
               .Select().Count();

            routes.MapODataRoute("time", "time", builder.GetEdmModel());
        }
    }
}
