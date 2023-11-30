using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static lilminirpg.DataLists;
using static System.Net.Mime.MediaTypeNames;

namespace lilminirpg
{
    public class SaveLoad
    {
        // Creates a dummy player on first startup
        public async static Task AddNewPlayerToDB()
        {
            try
            { 
            using (var ctx = new PlayerMethods.PlayerContext())
            {
                var newPlayer = new Player() { Name = "", PlayerJob = new Job(), WornAccessory = new Accessory(), WornWeapon = new Weapon() };
                ctx.Players.Add(newPlayer);
                bool hasChanges = ctx.ChangeTracker.HasChanges();
                int updates = ctx.SaveChanges();
                await ctx.SaveChangesAsync();
            }
            }
            catch (Exception ex) when (Program.LogException(ex))
            {
            }
        }
        // Save game method
        public async static Task SaveGame(Player currentPlayer)
        {
            try
            { 
            using (var ctx = new PlayerMethods.PlayerContext())
            {
                var savePlayer = ctx.Players.Single(b => b.CharacterKey == 1);
                savePlayer = currentPlayer;
                ctx.Players.AddOrUpdate(savePlayer);
                bool hasChanges = ctx.ChangeTracker.HasChanges();
                int updates = ctx.SaveChanges();
                await ctx.SaveChangesAsync();
            }
            }
            catch (Exception ex) when (Program.LogException(ex))
            {
            }
        }
        
        // Load game method
        public static Player LoadGame()
        {
            try
            { 
            using (var ctx = new PlayerMethods.PlayerContext())
            {
                var loadPlayer = ctx.Players.Single(b => b.CharacterKey == 1);
                return loadPlayer;
            }
            }
            catch (Exception ex) when (Program.LogException(ex))
            {
                return null;
            }
        }
    }
}
