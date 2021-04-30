using System.Collections.Generic;
using System.Threading.Tasks;
using PlayerClub.API.Models;

namespace PlayerClub.API.Data
{
    public interface IPlayerClubRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<Player> RegisterPlayer(Player player);
        Task<Team> RegisterTeam(Team team);
        Task<bool> TeamExists(string teamname);
        Task<Player> GetPlayer(int id);
        Task<IEnumerable<Player>> GetPlayers();
        Task<Team> GetTeam(string name);
        Task<IEnumerable<Team>> GetTeams();
    }
}