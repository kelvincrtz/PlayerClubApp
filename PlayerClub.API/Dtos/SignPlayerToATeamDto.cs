using PlayerClub.API.Models;

namespace PlayerClub.API.Dtos
{
    public class SignPlayerToATeamDto
    {
        public Team Team { get; set; }
        public string TeamName { get; set; }
    }
}