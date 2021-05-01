using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayerClub.API.Helpers;
using PlayerClub.API.Models;

namespace PlayerClub.API.Data
{
    public class PlayerClubRepository : IPlayerClubRepository
    {
        private readonly DataContext _context;
        public PlayerClubRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Player> GetPlayer(int id)
        {
            var player = await _context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.Id == id);

            return player;
        }

        public async Task<IEnumerable<Player>> GetPlayers(PlayerParams playerParams)
        {
            var players =  _context.Players.Include(x => x.Team).AsQueryable();

            if (playerParams.MinAge != 1 || playerParams.MaxAge != 99)
            {
                var minDob = DateTime.Today.AddYears(-playerParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-playerParams.MinAge);
                players = players.Where(x=> x.Birthdate >=minDob && x.Birthdate <= maxDob);
            }

            return await players.ToListAsync();
        }

        public async Task<Team> GetTeam(int id)
        {
            var team = await _context.Teams.Include(x => x.Players).FirstOrDefaultAsync(x => x.Id == id);

            return team;
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            var teams = await _context.Teams.Include(x => x.Players).ToListAsync();

            return teams;
        }

        public async Task<Player> RegisterPlayer(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<Team> RegisterTeam(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> TeamExists(string teamname)
        {
            if (await _context.Teams.AnyAsync(x => x.Name == teamname))
                return true;
                
            return false;
        }
    }
}