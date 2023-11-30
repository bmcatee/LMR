using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static lilminirpg.DataLists;

namespace lilminirpg
{
    public class CharacterMaker
    {
        public static bool _characterCreation = false;
        public async static Task MakeCharacter()
        {
            Player newPlayer = SaveLoad.LoadGame();
            Console.Clear();
            if (newPlayer.PlayerJob != null || newPlayer.WornWeapon != null || newPlayer.WornAccessory != null)
            {
                Console.WriteLine($"NOTICE: You may only have one character save file at a time. Making a new character will overwrite your previously existing character!");
                Console.WriteLine($"If you wish to proceed, press Y. If you wish to return to the main menu, press any other key.");
                string input = Console.ReadKey(true).Key.ToString();
                if (input != "y" && input != "Y")
                {
                    await Menus.MenuGeneric("MenuMain");
                }
            }

            // Starts the full player character creation process
            _characterCreation = true;
            newPlayer.Name = "";
            newPlayer.PlayerJob = new Job();
            newPlayer.WornWeapon = new Weapon();
            newPlayer.WornAccessory = new Accessory();
            newPlayer = await SetCharacterName(newPlayer);
            newPlayer = await JobMethods.SetPlayerJob(newPlayer);
            newPlayer = await WeaponMethods.SetPlayerWeapon(newPlayer);
            newPlayer = await AccessoryMethods.SetPlayerAccessory(newPlayer);
            newPlayer = SetLevelOne(newPlayer);
            await EndCharacterCreation(newPlayer);
        }

        // Set character name
        public async static Task<Player> SetCharacterName(Player currentPlayer)
        {
            Console.CursorVisible = true;
            UI.UIHeaderGeneric();
            currentPlayer.Name = "";
            while (currentPlayer.Name == "")
            {
                if (_characterCreation == true)
            {
                    Console.Clear();
                    Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
            }
            else
            {
                    Console.Clear();
                    Console.WriteLine("Please type your character's name and press Enter:");
            };

                currentPlayer.Name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(currentPlayer.Name))
                {
                    currentPlayer.Name = "";
                    Console.WriteLine("Your name is invalid. Please press Enter to try again.");
                    Console.ReadLine();
                }
            }
            await SaveLoad.SaveGame(currentPlayer);
            return currentPlayer;
        }

        public static Player SetLevelOne(Player currentPlayer)
        {
            currentPlayer.CurrentLevel = 1;
            currentPlayer.CurrentStage = 1;
            currentPlayer.StageTile = 0;
            currentPlayer.XPCurrent = 0;
            currentPlayer.XPToLevel = 20;
            currentPlayer.HealthPointsMax = currentPlayer.PlayerJob.HealthPointsGrowth;
            currentPlayer.HealthPointsCurrent = currentPlayer.HealthPointsMax;
            currentPlayer.StatStrength = currentPlayer.PlayerJob.StrengthGrowth;
            currentPlayer.StatDexterity = currentPlayer.PlayerJob.DexterityGrowth;
            currentPlayer.StatIntelligence = currentPlayer.PlayerJob.IntelligenceGrowth;
            currentPlayer.StatLuck = currentPlayer.PlayerJob.LuckGrowth;
            currentPlayer.StatMoveSpeed = currentPlayer.PlayerJob.MoveSpeed;
            currentPlayer.StatAttackSpeed = currentPlayer.PlayerJob.AttackSpeed;
            return currentPlayer;
        }

        // Resets variables, prints selection, saves game, goes back to Main Menu
        public async static Task EndCharacterCreation(Player newPlayer)
        {
            _characterCreation = false;
            Console.Clear();
            UI.UIHeaderGeneric();
            Console.WriteLine("You have selected:");
            Console.WriteLine("");
            Console.WriteLine($"[*] Name: {newPlayer.Name}");
            Console.WriteLine($"[*] Class: {newPlayer.PlayerJob.Name}");
            Console.WriteLine($"[*] Weapon: {newPlayer.WornWeapon.Name}");
            Console.WriteLine($"[*] Accessory: {newPlayer.WornAccessory.Name}");
            await SaveLoad.SaveGame(newPlayer);
            Console.WriteLine("");
            Console.WriteLine("Please press Enter to continue.");
            Console.ReadLine();
            await Menus.MenuGeneric("MenuMain");
        }
        public Player LevelUpPlayer(Player currentplayer)
        {
            currentplayer.CurrentLevel = currentplayer.CurrentLevel + 1;
            currentplayer.HealthPointsMax += currentplayer.PlayerJob.HealthPointsGrowth;
            currentplayer.StatStrength += currentplayer.PlayerJob.StrengthGrowth;
            currentplayer.StatDexterity += currentplayer.PlayerJob.DexterityGrowth;
            currentplayer.StatIntelligence += currentplayer.PlayerJob.IntelligenceGrowth;
            currentplayer.StatLuck += currentplayer.PlayerJob.LuckGrowth;
            return currentplayer;
        }
    }
}
