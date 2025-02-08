using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTO
{
    public class EventDTO
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public List<string> Teams { get; set; }
    }
}
