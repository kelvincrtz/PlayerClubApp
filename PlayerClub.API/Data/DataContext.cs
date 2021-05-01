using Microsoft.EntityFrameworkCore;
using PlayerClub.API.Models;

namespace PlayerClub.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {}
    }
}