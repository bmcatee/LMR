using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static lilminirpg.DataLists;

namespace lilminirpg
{
    public class CharacterMaker
    {
        private static bool _characterCreation = false;
        public void MakeCharacter()
        {
            // Starts the full player character creation process
            _characterCreation = true;
            Player newPlayer = new Player();
            newPlayer.PlayerJob = new Job();
            newPlayer.WornWeapon = new Weapon();
            newPlayer.WornAccessory = new Accessory();
            newPlayer = SetCharacterName(newPlayer);
            newPlayer.PlayerJob = JobMethods.SetPlayerJob(newPlayer);
            newPlayer.WornWeapon = WeaponMethods.SetPlayerWeapon(newPlayer);
            newPlayer.WornAccessory = AccessoryMethods.SetPlayerAccessory(newPlayer);
            newPlayer = SetLevelOne(newPlayer);
            EndCharacterCreation(newPlayer);
        }

        // Set character name
        public static Player SetCharacterName(Player currentPlayer)
        {
            Console.Clear();
            Console.CursorVisible = true;
            UI.UIHeaderGeneric();
            if (_characterCreation == true)
            {
                Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
            }
            else
            {
                Console.WriteLine("Please type your character's name and press Enter:");
            };

            currentPlayer.Name = Console.ReadLine();
            return currentPlayer;
        }

       public Player SetLevelOne(Player currentPlayer)
        {
            currentPlayer.CurrentLevel = 1;
            currentPlayer.CurrentStage = 1;
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
        public static void EndCharacterCreation(Player newPlayer)
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
            SaveLoad.SaveGame(newPlayer);
            Console.WriteLine("");
            Console.WriteLine("Please press Enter to continue.");
            Console.ReadLine();
            Menus.MenuGeneric("MenuMain");
        }
    }
}
