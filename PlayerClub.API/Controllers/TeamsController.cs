using System;
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
            teamForRegisterDto.Name = teamForRegisterDto.Name.ToLower();

            if (await _repo.TeamExists(teamForRegisterDto.Name))
                return BadRequest("Team already exists. Pick a new team name.");

            var teamToCreate = _mapper.Map<Team>(teamForRegisterDto);

            var createdTeam = await _repo.RegisterTeam(teamToCreate);

            if (await _repo.SaveAll())
                return CreatedAtRoute("GetTeam", new {name = createdTeam.Id}, createdTeam);
            
            throw new Exception("Registration of team failed on save");
        }

        [HttpGet("{name}", Name = "GetTeam")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _repo.GetTeam(id);

            if (team == null)
                return BadRequest("Team doesn't exist.");

            return Ok(team);
        }

        [HttpGet()]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _repo.GetTeams();

            if (teams == null)
                return BadRequest("There are no teams in the system");

            return Ok(teams);
        }
    }
}