using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTO
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }

        public string FullName { get; set; }

        [Required]
        public DateTime DateofBirth { get; set; }

        public string Position { get; set; }
        public int TeamId { get; set; }

        public string? TeamName { get; set; }

    }
}
