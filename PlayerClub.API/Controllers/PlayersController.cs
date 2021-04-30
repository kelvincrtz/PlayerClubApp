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
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerClubRepository _repo;
        private readonly IMapper _mapper;
        public PlayersController(IPlayerClubRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PlayerForRegisterDto playerForRegisterDto)
        {
            var playerToCreate = _mapper.Map<Player>(playerForRegisterDto);

            var createdPlayer = await _repo.RegisterPlayer(playerToCreate);

            if (await _repo.SaveAll()) {
                return CreatedAtRoute("GetPlayer", new {id = createdPlayer.Id}, createdPlayer);
            }

            throw new Exception("Registration of player failed on save");
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _repo.GetPlayer(id);

            if (player == null)
                return BadRequest("Player doesn't exist.");

            return Ok(player);
        }

        [HttpGet()]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _repo.GetPlayers();

            if (players == null)
                return BadRequest("There are no players in the system.");

            return Ok(players);
        }

        [HttpPost("signplayertoteam/{teamname}/{playernumber}")]
        public async Task<IActionResult> PlayerTeamSignUp(string teamname, int playernumber)
        {
            var teamFromRepo = await _repo.GetTeam(teamname);
            var playerFromRepo = await _repo.GetPlayer(playernumber);

            if (teamFromRepo == null)
                return BadRequest("No team has been found.");

            if (playerFromRepo == null)
                return BadRequest("No player has been found.");

            teamFromRepo.Player.Add(playerFromRepo);

            if (await _repo.SaveAll()) {
                return CreatedAtRoute("GetPlayer", new {id = playerFromRepo.Id}, playerFromRepo);
            }
            
            throw new Exception("Creating Sign Player to a Team failed on save");
        }

    }
}