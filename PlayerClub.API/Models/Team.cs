using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayerClub.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ground { get; set; }
        public string Coach { get; set; }
        public DateTime FoundedYear { get; set; }
        public string Region { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}