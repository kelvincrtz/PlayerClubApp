using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PlayerClub.API.Models;

namespace PlayerClub.API.Data
{
    public class Seed
    {
        public static void SeedPlayers(DataContext context)
        {
            if (!context.Players.Any())
            {
                var playerData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var players = JsonConvert.DeserializeObject<List<Player>>(playerData);
                foreach(var player in players)
                {
                    player.Name = player.Name.ToLower();
                    context.Players.Add(player);
                }

                context.SaveChanges();
            }
        }
    }
}