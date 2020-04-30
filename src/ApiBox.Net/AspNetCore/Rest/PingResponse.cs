using ApiBox.PingPong;
using System;
using System.Threading.Tasks;

namespace ApiBox.Net.AspNetCore.Rest
{
    public class PingResponse
    {
        public PingResponse(Pong pong)
        {
            Input = pong.Ping.Message;
            Output = pong.Message;
            CreatedAt = pong.Created.At;
        }

        public string Input { get; }
        public string Output { get; set; }

        public DateTimeOffset CreatedAt { get; }
    }
}