using System.ComponentModel.DataAnnotations;

namespace SportBackend.DAL.Model
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string FullName {  get; set; }

        public DateTime DateofBirth { get; set; }

        public string Position { get; set; }

        public int TeamId { get; set; }

        public Team? Team { get; set; }
    }
}
