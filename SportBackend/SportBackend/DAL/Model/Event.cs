namespace SportBackend.DAL.Model
{
    public class Event
    {
        public int EventId {  get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public List<Team> Teams { get; set; }=new List<Team>();
    }
}
