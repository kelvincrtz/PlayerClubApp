using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlayerClub.API.Data;
using PlayerClub.API.Dtos;
using PlayerClub.API.Helpers;
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

            playerToCreate.Name = playerToCreate.Name.ToLower();

            var createdPlayer = await _repo.RegisterPlayer(playerToCreate);

            await _repo.SaveAll();

            return CreatedAtRoute("GetPlayer", new {id = createdPlayer.Id}, createdPlayer);
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _repo.GetPlayer(id);

            if (player == null)
                return BadRequest("Player doesn't exist.");

            var playerToReturn = _mapper.Map<PlayerForDetailedDto>(player);

            return Ok(playerToReturn);
        }

        [HttpGet()]
        public async Task<IActionResult> GetPlayers([FromQuery]PlayerParams playerParams)
        {
            var players = await _repo.GetPlayers(playerParams);

            if (players == null)
                return BadRequest("There are no players in the system.");

            var playersToReturn = _mapper.Map<IEnumerable<PlayerForListDto>>(players);

            return Ok(playersToReturn);
        }

        [HttpPut("playerforteam/{playerid}/{teamid}")]
        public async Task<IActionResult> UpdateUserTeam(int playerid, int teamid, PlayerForTeamUpdateDto playerForTeamUpdateDto) 
        {

            var playerFromRepo = await _repo.GetPlayer(playerid);
            var teamFromRepo = await _repo.GetTeam(teamid);

            if (playerFromRepo == null)
                return BadRequest("Player ID" + playerid + "doesn't exist in the system.");
            
            if (teamFromRepo == null)
                return BadRequest("Team ID" + teamid + "doesn't exist in the system.");

            playerForTeamUpdateDto.Team = teamFromRepo;
            playerForTeamUpdateDto.TeamId = teamFromRepo.Id;

            _mapper.Map(playerForTeamUpdateDto, playerFromRepo);

            if (await _repo.SaveAll())
                return NoContent();
            
            throw new Exception($"Updating player failed on save");
        }

    }
}