using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lilminirpg
{
    public class DataLists
    {
        // Lists for menus; a bit outdated and probably should be replaced
        public static string[,] MenuMain =
        {
                    {"Play Game"},
                    {"Make New Character"},
                    {"Show Character Info"},
                    {"Edit Character & Equipment"},
                    {"How to Play"},
                    {"Exit"},
                    {"Debug Menu"}
        };

        public static string[,] MenuTest =
        {
                    {"InitStageArray"},
                    //{"Check Players Status"},
                    {"PrintCharacterInfo"},
                    {"PrintColorList"},
                    {"Exit to Main Menu"}
        };

        public static string[,] MenuEdit =
        {   
                    {"Change Character Name"},
                    {"Change Job"},
                    {"Change Weapon"},
                    {"Change Accessory"},
                    {"Exit to Main Menu"}
        };


        public class Clothing
        {
            // coming soon
        }
        public static void HowToPlay()
        {
            Console.WriteLine("\tHello, and welcome to:");
            Console.WriteLine("");
            UI.UIHeaderGeneric();
            Console.WriteLine("");
            Console.WriteLine("- lil mini rpg is an idle game with RPG elements.");
            Console.WriteLine("- To play, all you need to do is:");
            Console.WriteLine("  * Make a character");
            Console.WriteLine("  * Give them a Job, a Weapon, and an Accessory");
            Console.WriteLine("  * And then you're ready to start questing!");
            Console.WriteLine("");
            Console.WriteLine("- Once you select the \"Play Game\" option, your character will begin moving through a \"Stage\" populated with enemies.");
            Console.WriteLine("- Each Stage has a minimum of 16 tiles for your character to move through, before they reach the next Stage.");
            Console.WriteLine("- Your character - and the enemies - all attack and move on a set timer, as determined by your MOV SPD and ATK SPD.");
            Console.WriteLine("- Normal enemies cannot move, but watch out! If one hits you, you'll be knocked back by one space on the stage!");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
            UI.UIHeaderGeneric();
            Console.WriteLine("");
            Console.WriteLine("\tJobs:");
            Console.WriteLine("");
            Console.WriteLine("- A \"Job\" is your character's class, and determines many things.");
            Console.WriteLine("First, your stats - each job has its own growth (more on that later), meaning each job is better at different things as they gain levels.");
            Console.WriteLine("Secondly, each Job has its own (coming soon!) unique set of perks, that change how your character progresses through the game.");
            Console.WriteLine("And also, certain combinations of Weapons and Accessories with specific jobs may unlock hidden, secret bonuses - it pays to experiment!");
            Console.WriteLine("");
            Console.WriteLine("\tWeapons:");
            Console.WriteLine("");
            Console.WriteLine("- A weapon is what your character attacks with.");
            Console.WriteLine("- Each weapon has its own unique Damage Type (Slashing, Bashing, Piercing, Ranged or Magical), and may or may not have an Elemental type.");
            Console.WriteLine("- Certain Jobs have better proficiency in weapons with certain Damage or Elemental types, so it can be worth experimenting with different combinations.");
            Console.WriteLine("- Weapons also provide additional stats to the player, and can convey unique perk abilities as well.");
            Console.WriteLine("");
            Console.WriteLine("\tAccessories:");
            Console.WriteLine("");
            Console.WriteLine("- Accessories, like weapons, provide both stats and unique perks to the player.");
            Console.WriteLine("- Unlike weapons, there are no accessory proficiencies, making them move viable for a wider range of jobs.");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
            UI.UIHeaderGeneric();
            Console.WriteLine("");
            Console.WriteLine("\tAttacking:");
            Console.WriteLine("");
            Console.WriteLine("- When your character attacks, the damage they do is determined by both your stats and the weapon you carry.");
            Console.WriteLine("- As an example:");
            Console.WriteLine("");
            Console.WriteLine("  * Bob the Knight has the following stats: 30 STR / 10 INT / 15 DEX / 15 LUK, and is carrying a Sword.");
            Console.WriteLine("  * The Sword does damage based on STR (65%) and DEX (35%).");
            Console.WriteLine("  * When Bob hits an enemy with the Sword, it does (19.5 + 5.25 =) 25 [rounded up] damage.");
            Console.WriteLine("  * This damage is then slightly modified, and may even result in a critical hit - or failure!");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\tLeveling Up");
            Console.WriteLine("");
            Console.WriteLine("- Defeat enemies to gain XP and Gold - gain enough XP and you'll level up!");
            Console.WriteLine("- When you level up, you gain stats equal to your Job Growth stats. Using Bob as our example again:");
            Console.WriteLine("  * If Bob has 30 STR at level 5, and a growth of 5 STR, at level 6 Bob will have 35 STR; at level 7, 40 STR.");
            Console.WriteLine("- Each Job has its own set of growth stats, making some jobs better at certain stats than others.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
            UI.UIHeaderGeneric();
            Console.WriteLine("");
            Console.WriteLine("\tChanging Jobs & Making Money:");
            Console.WriteLine("");
            Console.WriteLine("- Changing Jobs will reset your character's level to 1 and your XP to 0.");
            Console.WriteLine("- However, when you change your job you also recieve Gold in exchange for the XP you are losing.");
            Console.WriteLine("- Changing jobs can be a great way to make a lot of cash!");
            Console.WriteLine("- Money does not do anything at the moment but it hopefully will some day!");
            Console.WriteLine("- This will also be the fastest way to unlock additional character perks - again, Coming Soon (tm)");
            Console.WriteLine("");
            Console.WriteLine("\t *** And that's about it! Have fun playing! ***");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to return the main menu.");
        }
        public async static Task PrintCharacterInfo(Player currentPlayer)
        {
            Console.WriteLine($"{currentPlayer.Name} the Level {currentPlayer.CurrentLevel} {currentPlayer.PlayerJob.Name}");
            Console.WriteLine($"Maximum HP: {currentPlayer.HealthPointsMax}");
            Console.WriteLine($"Current XP: {currentPlayer.XPCurrent} - XP to Level: {currentPlayer.XPToLevel - currentPlayer.XPCurrent} - Banked XP {currentPlayer.XPBanked}");
            Console.WriteLine($"Total GP: {currentPlayer.GoldCurrent} - Current Stage: {currentPlayer.CurrentStage} - Highest Stage Reached: {currentPlayer.MaximumStage}");
            Console.WriteLine("");
            Console.WriteLine($"Total STR: {currentPlayer.StatStrength} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.StatStrength} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.StatStrength} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.StatStrength + currentPlayer.WornWeapon.StatStrength + currentPlayer.WornAccessory.StatStrength} (total)");
            Console.WriteLine($"Total DEX: {currentPlayer.StatDexterity} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.StatDexterity} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.StatDexterity} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.StatDexterity + currentPlayer.WornWeapon.StatDexterity + currentPlayer.WornAccessory.StatDexterity} (total)");
            Console.WriteLine($"Total INT: {currentPlayer.StatIntelligence} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.StatIntelligence} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.StatIntelligence} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.StatIntelligence + currentPlayer.WornWeapon.StatIntelligence + currentPlayer.WornAccessory.StatIntelligence} (total)");
            Console.WriteLine($"Total LUK: {currentPlayer.StatLuck} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.StatLuck} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.StatLuck} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.StatLuck + currentPlayer.WornWeapon.StatLuck + currentPlayer.WornAccessory.StatLuck} (total)");
            Console.WriteLine($"Growth: {currentPlayer.PlayerJob.StrengthGrowth} STR - {currentPlayer.PlayerJob.DexterityGrowth} DEX - {currentPlayer.PlayerJob.IntelligenceGrowth} INT - {currentPlayer.PlayerJob.LuckGrowth} LUK");
            Console.WriteLine("");
            Console.WriteLine($"MOV SPD: {currentPlayer.PlayerJob.MoveSpeed} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.MoveSpeed} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.MoveSpeed} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.PlayerJob.MoveSpeed + currentPlayer.WornWeapon.MoveSpeed + currentPlayer.WornAccessory.MoveSpeed} (total) - (remember lower speed is better!)");
            Console.WriteLine($"ATK SPD: {currentPlayer.PlayerJob.AttackSpeed} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.AttackSpeed} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.AttackSpeed} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.PlayerJob.AttackSpeed + currentPlayer.WornWeapon.AttackSpeed + currentPlayer.WornAccessory.AttackSpeed} (total) - (remember lower speed is better!)");
            Console.WriteLine("");
            Console.WriteLine($"Weapon: {currentPlayer.WornWeapon.Name} - Attack Type: {currentPlayer.WornWeapon.AttackType} damage - Elemental Type: {currentPlayer.WornWeapon.ElementType} - Attacks with {currentPlayer.WornWeapon.AttackStat1}/{currentPlayer.WornWeapon.AttackPercent1}% & {currentPlayer.WornWeapon.AttackStat2}/{currentPlayer.WornWeapon.AttackPercent2}% - Perk: Not Yet Implemented!");
            Console.WriteLine("");
            Console.WriteLine($"Accessory: {currentPlayer.WornAccessory.Name} - Perk: Not Yet Implemented");
        }
    }
}
