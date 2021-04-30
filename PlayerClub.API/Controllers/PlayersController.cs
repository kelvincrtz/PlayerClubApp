using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerClub.API.Data;

namespace PlayerClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly DataContext _context;
        public PlayersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();

            return Ok(players);
        }   
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(player);
        }
    }
}