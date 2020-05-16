using ApiBox.PingPong;

namespace ApiBox.Net.PingPong.WebApi
{
    public class PingResponse
    {
        public string? Message { get; set; }

        internal static PingResponse MapFrom(Ping ping) => new PingResponse()
        {
            Message = ping.Message
        };

    }
}
