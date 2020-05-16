using System;
using System.Linq;

namespace ApiBox.PingPong
{
    public class Pong
    {
        public Pong(Ping ping)
        {
            Id = Guid.NewGuid().ToString();
            Ping = ping;
            Message = new string(ping.Message.Reverse().ToArray());
        }
        public string Id { get; }
        public Ping Ping { get; }

        public string Message { get; }

        public ModificationInfo Created { get; set; } = new ModificationInfo();

    }
}