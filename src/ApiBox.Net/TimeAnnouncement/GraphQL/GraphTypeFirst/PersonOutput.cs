using ApiBox.TimeAnnouncment;
using GraphQL.Types;

namespace ApiBox.Net.StarWars.GraphQL.GraphTypeFirst
{
    public class TimeOutput : ObjectGraphType<Time>
    {
        public TimeOutput()
        {
            Description = "A time-announcment";
            Field(_ => _.Value).Description("The value of the time-announcement");
        }
    }
}
