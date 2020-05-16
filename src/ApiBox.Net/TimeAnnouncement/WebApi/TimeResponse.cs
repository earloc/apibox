using System;

namespace ApiBox.Net.TimeAnnouncement.WebApi
{
    public class TimeResponse
    {
        public DateTimeOffset Value { get; set; } = DateTimeOffset.Now;

        internal static TimeResponse MapFrom(TimeAnnouncment.Time source) => new TimeResponse() { Value = source.Value };
    }
}
