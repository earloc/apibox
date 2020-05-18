using System;

namespace ApiBox.Api.WebApi
{
    public class ModificationInfoResponse
    {
        public DateTimeOffset At { get; set; } = DateTimeOffset.Now;

        internal static ModificationInfoResponse MapFrom(ModificationInfo source) => new ModificationInfoResponse()
        {
            At = source.At
        };
    }
}
