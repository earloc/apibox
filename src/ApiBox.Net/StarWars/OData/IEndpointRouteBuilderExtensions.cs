using ApiBox.Net.StarWars.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace Microsoft.AspNetCore.Routing
{

    public static partial class IEndpointRouteBuilderExtensions
    {
        public static void MapStarWarsODataRoute(this IEndpointRouteBuilder endpoints)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<PersonEntity>("Persons").EntityType
               .HasKey(_ => _.Id)
               .Select().Count();

            endpoints.MapODataRoute("starwars", "odata", builder.GetEdmModel());
        }

    }
}
