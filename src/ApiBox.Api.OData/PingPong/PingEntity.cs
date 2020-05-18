using ApiBox.PingPong;

namespace ApiBox.Api.OData.PingPong
{
    public class PingEntity
    {
        public string? Message { get; set; }

        internal static PingEntity MapFrom(Ping source) => new PingEntity()
        {
            Message = source.Message
        };
    }
}
