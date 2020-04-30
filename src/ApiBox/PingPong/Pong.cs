using System.Linq;

namespace ApiBox.PingPong
{
    public class Pong
    {

        public Pong(Ping ping)
        {
            Ping = ping;
            Message = new string(ping.Message.Reverse().ToArray());
        }
        public Ping Ping { get; }

        public string Message { get; }

        public MutationInfo Created { get; set; } = new MutationInfo();

    }
}