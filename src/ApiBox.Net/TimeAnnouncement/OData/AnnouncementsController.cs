using ApiBox.TimeAnnouncment;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace ApiBox.Net.TimeAnnouncement.OData
{

    public class AnnouncementsController : ODataController
    {
        [EnableQuery]
        [ODataRoute]
        public TimeEntity? Get([FromServices]ITimeAnnouncer announcer)
        {
            var result = announcer.GetValue();
            return TimeEntity.Map(result);
        }
    }
}
