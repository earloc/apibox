using System;

namespace ApiBox.Api.OData
{
    public class ModificationInfoEntity
    {
        public DateTimeOffset At { get; set; } = DateTimeOffset.Now;

        internal static ModificationInfoEntity MapFrom(ModificationInfo source) => new ModificationInfoEntity()
        {
            At = source.At
        };
    }
}
