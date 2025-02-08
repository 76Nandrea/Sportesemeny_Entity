namespace SportBackend.DAL.Model
{
    public class Team
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public int Establish {  get; set; }
        public string ImageUrl { get; set; }

        public virtual List<Event> Events { get; set; }=new List<Event>();

        public virtual List<Player> Player { get; set; }=new List<Player>();
    }
}
