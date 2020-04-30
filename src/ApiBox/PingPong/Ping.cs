namespace ApiBox.PingPong
{
    public class Ping
    {
        public Ping(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}