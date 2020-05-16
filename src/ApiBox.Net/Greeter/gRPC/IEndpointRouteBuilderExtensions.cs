using ApiBox.Net.Greeter.gRPC;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Routing
{
    public static partial class IEndpointRouteBuilderExtensions
    {
        public static void MapGreeterGRPCService(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<GreeterService>();
        }
    }
}
