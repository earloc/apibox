using System.Text.Json;
namespace ApiBox.Api.Tests
{
    public class GraphQlPayload
    {

        public string operationName { get; set; } = null;
        public object variables { get; set; } = new object();
        public string query { get; set; } = null;

        public string ToJson() => JsonSerializer.Serialize(this);
    }
}