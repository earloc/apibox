using ApiBox.PingPong;
using Microsoft.AspNet.OData.Builder;

namespace Microsoft.AspNetCore.Routing
{
    public static partial class ODataModelBuilderExtensions
    {
        public static ODataModelBuilder AddPingPong(this ODataModelBuilder builder)
        {
            builder.EntitySet<Pong>("Pongs").EntityType
                .HasKey(_ => _.Id)
                .Select().Count();

            return builder;
        }
    }
}
