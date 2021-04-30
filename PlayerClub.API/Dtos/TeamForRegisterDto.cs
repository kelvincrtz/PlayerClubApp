using System;
using System.ComponentModel.DataAnnotations;

namespace PlayerClub.API.Dtos
{
    public class TeamForRegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Ground { get; set; }

        [Required]
        public string Coach { get; set; }

        [Required]
        public DateTime FoundedYear { get; set; }

        [Required]
        public string Region { get; set; }
        
    }
}