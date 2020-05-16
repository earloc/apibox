using ApiBox.PingPong;

namespace ApiBox.Net.PingPong.OData
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
