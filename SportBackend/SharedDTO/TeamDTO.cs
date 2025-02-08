using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTO
{
    public class TeamDTO
    {
        public int TeamId { get; set; }

        public string? TeamName { get; set; }
        public string ImageUrl { get; set; }

        public int Establish { get; set; }
    }
}
