
namespace ApiBox.Greeter
{
    public class StaticGreeter : IGreeter
    {
        public Greeting Greet(string name)
        {
            return new Greeting() { Content = $"Hello {name}" };
        }
    }
}
