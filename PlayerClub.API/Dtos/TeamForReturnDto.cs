using System;

namespace PlayerClub.API.Dtos
{
    public class TeamForReturnDto
    {
        public string Name { get; set; }

        public string Ground { get; set; }

        public string Coach { get; set; }

        public DateTime FoundedYear { get; set; }
        
        public string Region { get; set; }
    }
}