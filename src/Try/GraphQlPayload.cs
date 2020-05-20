using System.Text.Json;
namespace Try
{
    public class GraphQlPayload
    {

        public string operationName { get; set; } = null;
        public object variables { get; set; } = new object();
        public string query { get; set; } = null;

        public string ToJson() => JsonSerializer.Serialize(this);
    }
}