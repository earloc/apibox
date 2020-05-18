using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace ApiBox.Api.OData.Greeter
{
    public class GreeterModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.EntitySet<GreetingEntity>("Greetings").EntityType
               .HasKey(_ => _.Message)
               .Select().Count();
        }

    }
}
