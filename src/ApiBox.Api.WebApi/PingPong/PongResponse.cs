using ApiBox.PingPong;
using System.Collections.Generic;
using System.Linq;

namespace ApiBox.Api.WebApi.PingPong
{
    public class PongResponse
    {
        public string? Id { get; set; }

        public PingResponse? Ping { get; set; }

        public string? Message { get; set; }

        public ModificationInfoResponse Created { get; set; } = new ModificationInfoResponse();

        private static PongResponse MapCore(Pong source) => new PongResponse()
        {
            Id = source.Id,
            Message = source.Message,
            Created = ModificationInfoResponse.MapFrom(source.Created),
            Ping = PingResponse.MapFrom(source.Ping)
        };

        internal static PongResponse? MapFrom(Pong? sources) => sources switch
        {
            null => null,
            Pong source => MapCore(source)
        };

        internal static IEnumerable<PongResponse> MapFrom(IEnumerable<Pong> result) => result
                .Where(_ => _ != null)
                .Select(_ => MapCore(_));
    }
}
