using ApiBox.TimeAnnouncment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiBox.Net.TimeAnnouncement.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeAnnouncementController : ControllerBase
    {
        [HttpGet("Server")]
        public ActionResult<IEnumerable<TimeResponse>> Get([FromServices] ITimeAnnouncer announcer)
        {
            var result = announcer.GetValue();

            return Ok(TimeResponse.MapFrom(result));
        }
    }
}