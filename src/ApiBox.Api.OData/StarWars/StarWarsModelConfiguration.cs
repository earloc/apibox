using ApiBox.Api.OData.StarWars;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace ApiBox.Api.OData.PingPong
{
    public class StarWarsModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string? routePrefix)
        {
            builder.EntitySet<PersonEntity>("Persons").EntityType
             .HasKey(_ => _.Id)
             .Filter()
             .Page()
             .Select().Count();
        }
    }
}
