using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ApiBox.Net.Tests.ApiStack;
namespace ApiBox.Net.Tests
{

    public class GraphQlPayload
    {

        public string operationName { get; set; } = null;
        public object variables { get; set; } = new object();
        public string query { get; set; } = null;

        public string ToJson() => JsonSerializer.Serialize(this);
    }

    public class TimeAnnouncementFixture : ApiBoxFixture
    {
        readonly string webApiUrl = "/api/TimeAnnouncement/Server";
        readonly string oDataUrl = "/time/Announcements";
        readonly string graphQLUrl = "/graphql";
        readonly GraphQlPayload graphQLPayload = new GraphQlPayload()
        {
            query = @"
            query {
              timeannouncements {
                server {
                  value
                }
              }
            }"
        };

        readonly HttpContent graphQLContent;
        public TimeAnnouncementFixture()
        {
            var payload = graphQLPayload.ToJson();

            graphQLContent = new StringContent(payload, Encoding.Default, "application/json");
        }

        private async Task<Func<Task>> HttpGet(string path)
        {
            var response = await api.GetAsync(path);
            return () => Task.FromResult(response.EnsureSuccessStatusCode());
        }

        private async Task<Func<Task>> GraphQlPost(string path, HttpContent payload)
        {
            var response = await api.PostAsync(path, payload).ConfigureAwait(false);
            return async () =>
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                if (result.Contains("errors"))
                {
                    throw new Exception(result.ToString());
                }
            };
        }

        internal Func<Task<Func<Task>>> GetActionFor(ApiStack apiStack)
        {
            return apiStack switch
            {
                WebApi => () => HttpGet(webApiUrl),
                OData => () => HttpGet(oDataUrl),
                GQLnet_TypesFirst => () => GraphQlPost(graphQLUrl, graphQLContent),
                _ => throw new ArgumentException($"{apiStack} is not supported")
            };
        }
    }
}