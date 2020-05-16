
using ApiBox.TimeAnnouncment;
using System;

namespace ApiBox.Net.TimeAnnouncement.OData
{
    public class TimeEntity
    {
        public DateTimeOffset Value { get; set; }

        internal static TimeEntity? Map(Time? source) => source switch
        {
            Time time => new TimeEntity() { Value = time.Value },
            _ => null
        };

    }
}
