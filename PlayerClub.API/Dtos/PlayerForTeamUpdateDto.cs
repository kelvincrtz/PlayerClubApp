using PlayerClub.API.Models;

namespace PlayerClub.API.Dtos
{
    public class PlayerForTeamUpdateDto
    {
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}