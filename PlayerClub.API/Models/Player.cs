using System;

namespace PlayerClub.API.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string PlaceOfBirth { get; set; }
        public Team Team { get; set; }
        public string TeamName { get; set; }
    }
}