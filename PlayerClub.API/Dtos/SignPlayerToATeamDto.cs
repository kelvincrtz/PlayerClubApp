using System;
using System.ComponentModel.DataAnnotations;
using PlayerClub.API.Models;

namespace PlayerClub.API.Dtos
{
    public class SignPlayerToATeamDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }
    }
}