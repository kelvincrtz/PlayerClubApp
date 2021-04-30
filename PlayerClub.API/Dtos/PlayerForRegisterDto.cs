using System;
using System.ComponentModel.DataAnnotations;

namespace PlayerClub.API.Dtos
{
    public class PlayerForRegisterDto
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