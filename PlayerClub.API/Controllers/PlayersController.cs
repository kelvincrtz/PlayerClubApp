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

            return CreatedAtRoute("GetPlayer", new {id = createdPlayer.Id}, createdPlayer);
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _repo.GetPlayer(id);

            return Ok(player);
        }

        [HttpGet()]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _repo.GetPlayers();

            return Ok(players);
        }
    }
}