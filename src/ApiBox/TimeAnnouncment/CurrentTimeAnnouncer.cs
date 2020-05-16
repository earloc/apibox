
namespace ApiBox.TimeAnnouncment
{
    public class CurrentTimeAnnouncer : ITimeAnnouncer
    {
        public Time GetValue()
        {
            return new Time();
        }
    }
}
