
namespace ApiBox.Greeter
{
    public class StaticGreeter : IGreeter
    {
        public Greeting SayHello(string name)
        {
            return new Greeting() { Content = $"Hello {name}" };
        }
    }
}
