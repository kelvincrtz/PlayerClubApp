using AutoMapper;
using PlayerClub.API.Dtos;
using PlayerClub.API.Models;

namespace PlayerClub.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PlayerForRegisterDto, Player>();
            CreateMap<TeamForRegisterDto, Team>();
            CreateMap<PlayerForTeamUpdateDto, Player>();
            CreateMap<Player, PlayerForListDto>();
            CreateMap<Team, TeamForReturnDto>();
            CreateMap<Player, PlayerForDetailedDto>();
        }
    }
}