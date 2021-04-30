using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlayerClub.API.Data;
using PlayerClub.API.Dtos;
using PlayerClub.API.Models;

namespace PlayerClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IPlayerClubRepository _repo;
        private readonly IMapper _mapper;
        public TeamsController(IPlayerClubRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] TeamForRegisterDto teamForRegisterDto)
        {
            var teamToCreate = _mapper.Map<Team>(teamForRegisterDto);

            var createdTeam = await _repo.RegisterTeam(teamToCreate);

            return CreatedAtRoute("GetTeam", new {name = createdTeam.Name}, createdTeam);
        }

        [HttpGet("{name}", Name = "GetTeam")]
        public async Task<IActionResult> GetTeam(string name)
        {
            var team = await _repo.GetTeam(name);

            return Ok(team);
        }

        [HttpGet()]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _repo.GetTeams();

            return Ok(teams);
        }
    }
}