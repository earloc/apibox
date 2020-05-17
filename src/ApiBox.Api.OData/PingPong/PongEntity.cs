using ApiBox.PingPong;
using System.Collections.Generic;
using System.Linq;

namespace ApiBox.Api.OData.PingPong
{
    public class PongEntity
    {
        public string? Id { get; set; }

        public PingEntity? Ping { get; set; }

        public string? Message { get; set; }

        public ModificationInfoEntity Created { get; set; } = new ModificationInfoEntity();

        private static PongEntity MapCore(Pong source) => new PongEntity()
        {
            Id = source.Id,
            Message = source.Message,
            Created = ModificationInfoEntity.MapFrom(source.Created),
            Ping = PingEntity.MapFrom(source.Ping)
        };

        internal static PongEntity? MapFrom(Pong? source) => source switch
        {
            null => null,
            Pong pong => MapCore(pong)
        };

        internal static IEnumerable<PongEntity> MapFrom(IEnumerable<Pong> result) => result
                .Where(_ => _ != null)
                .Select(_ => MapCore(_));
    }
}
