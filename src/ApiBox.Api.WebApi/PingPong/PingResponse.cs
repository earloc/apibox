using ApiBox.PingPong;

namespace ApiBox.Api.WebApi.PingPong
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
