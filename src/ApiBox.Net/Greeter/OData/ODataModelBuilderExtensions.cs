using ApiBox.Net.Greeter.OData;
using Microsoft.AspNet.OData.Builder;

namespace Microsoft.AspNetCore.Routing
{
    public static partial class ODataModelBuilderExtensions
    {
        public static ODataModelBuilder AddGreeter(this ODataModelBuilder builder)
        {
            builder.EntitySet<GreetingEntity>("Greetings").EntityType
               .HasKey(_ => _.Message)
               .Select().Count();

            return builder;
        }
    }
}
