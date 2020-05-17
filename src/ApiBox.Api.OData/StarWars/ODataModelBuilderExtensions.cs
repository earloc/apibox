using ApiBox.Api.OData.StarWars;
using Microsoft.AspNet.OData.Builder;

namespace Microsoft.AspNetCore.Routing
{
    public static partial class ODataModelBuilderExtensions
    {
        public static ODataModelBuilder AddStarWars(this ODataModelBuilder builder)
        {
            builder.EntitySet<PersonEntity>("Persons").EntityType
               .HasKey(_ => _.Id)
               .Filter()
               .Page()
               .Select().Count();

            return builder;
        }
    }
}
