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

        public async static Task AddNewPlayerToDB()
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
        // Save game method
        public async static Task SaveGame(Player currentPlayer)
        {
            //string savedata = JsonSerializer.Serialize<Player>(newPlayer, new JsonSerializerOptions { WriteIndented = true });
            //string folder = Environment.CurrentDirectory;
            //string filename = "\\lmr_save_001.json";
            //string savepath = folder + filename;
            //File.WriteAllText(savepath, savedata);
           
            using (var ctx = new PlayerMethods.PlayerContext())
            {
                var savePlayer = ctx.Players.Single(b => b.CharacterKey == 1);
                savePlayer = currentPlayer;
                ctx.Players.AddOrUpdate(savePlayer);
                bool hasChanges = ctx.ChangeTracker.HasChanges();
                int updates = ctx.SaveChanges();
                await ctx.SaveChangesAsync();
            }

            //Console.WriteLine("");
            //Console.WriteLine($"Your data has been saved to {Path.Combine(Directory.GetCurrentDirectory())}/{filename}!");       
        }

        [STAThread]
        public static Player LoadGame()
        {
            //Player loadPlayer = new Player();
            //string loadData = JsonSerializer.Serialize<Player>(loadPlayer, new JsonSerializerOptions { WriteIndented = true });
            //string folder = Environment.CurrentDirectory;
            //string filename = "\\lmr_save_001.json";
            //string loadpath = folder + filename;

            //// Make dummy if no save exists
            //if (File.Exists(loadpath))
            //{
            //    using (StreamReader sr = new StreamReader(loadpath))
            //    {
            //        while (!sr.EndOfStream)
            //        {
            //            string json = sr.ReadToEnd();
            //            loadPlayer = JsonSerializer.Deserialize<Player>(json);
            //        }
            //    }
            //}
            using (var ctx = new PlayerMethods.PlayerContext())
            {
                var loadPlayer = ctx.Players.Single(b => b.CharacterKey == 1);
                //if (loadPlayer.Name != " ")
                //{
                //    Console.Clear();
                //    Console.WriteLine($"Player {loadPlayer.Name} loaded.");
                //    Console.WriteLine($"Press Enter to continue.");
                //    Console.ReadLine();
                //}
                return loadPlayer;
            }
        }
    }
}
