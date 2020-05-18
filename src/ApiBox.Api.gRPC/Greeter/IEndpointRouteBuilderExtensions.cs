using ApiBox.Api.gRPC;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Routing
{
    public static partial class ODataModelBuilderExtensions
    {
        public static void MapGreeterGRPCService(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<GreeterService>();
        }
    }
}
