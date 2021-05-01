using System;
using System.Collections.Generic;

namespace PlayerClub.API.Dtos
{
    public class PlayerForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string PlaceOfBirth { get; set; }
        public TeamForReturnDto Team { get; set; }
    }
}