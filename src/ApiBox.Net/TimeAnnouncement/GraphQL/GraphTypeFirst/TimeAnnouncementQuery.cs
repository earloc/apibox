using ApiBox.TimeAnnouncment;
using GraphQL.Types;

namespace ApiBox.Net.StarWars.GraphQL.GraphTypeFirst
{
    public class TimeAnnouncementQuery : ObjectGraphType
    {
        public TimeAnnouncementQuery(IDependency<ITimeAnnouncer> announcer)
        {
            Field<TimeOutput>("server",
                resolve: context =>
                {
                    return announcer.Instance.GetValue();
                }
            );
        }
    }
}
