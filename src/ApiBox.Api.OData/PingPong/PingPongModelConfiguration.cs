using ApiBox.PingPong;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace ApiBox.Api.OData.PingPong
{

    public class PingPongModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            builder.EntitySet<Pong>("Pongs").EntityType
               .HasKey(_ => _.Id)
               .Select().Count();
        }

    }

}
