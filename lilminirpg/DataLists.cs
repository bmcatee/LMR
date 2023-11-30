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
                    {"Load Character Info"},
                    {"Edit Character & Equipment"},
                    {"How to Play"},
                    {"Exit"},
                    {"Debug Menu"}
        };

        public static string[,] MenuTest =
        {
                    {"InitStageArray"},
                    {"Check Players Status"},
                    {"PrintLists"},
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
            Console.WriteLine("Hello, and welcome to:");
            Console.WriteLine("");
            UI.UIHeaderGeneric();
            Console.WriteLine("");
            Console.WriteLine("lil mini rpg is an idle game with RPG elements.");
            Console.WriteLine("To play, all you need to do is:");
            Console.WriteLine("* Make a character");
            Console.WriteLine("* Give them a Job, a Weapon, and an Accessory");
            Console.WriteLine("* And then you're ready to start questing!");
            Console.WriteLine("");
            Console.WriteLine("Once you select the \"Play Game\" option, your character will begin moving through a \"Stage\" populated with enemies.");
            Console.WriteLine("Each Stage has a minimum of 16 tiles for your character to move through, before they reach the next Stage.");
            Console.WriteLine("Your character - and the enemies - all attack and move on a set timer, as determined by your MOV SPD and ATK SPD.");
            Console.WriteLine("Normal enemies cannot move, but watch out! If one hits you, you'll be knocked back by one space on the stage!");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Attacking:");
            Console.WriteLine("");
            Console.WriteLine("When your character attacks, the damage they do is determined by both your stats and the weapon you carry.");
            Console.WriteLine("As an example:");
            Console.WriteLine("");
            Console.WriteLine("Bob the Knight has the following stats: 30 STR / 10 INT / 15 DEX / 15 LUK, and is carrying a Sword.");
            Console.WriteLine("The Sword does damage based on STR (65%) and DEX (35%).");
            Console.WriteLine("When Bob hits an enemy with the Sword, it does (19.5 + 5.25 =) 25 [rounded up] damage.");
            Console.WriteLine("This damage is then slightly modified, and may even result in a critical hit - or failure!");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Changing Jobs & Making Money:");
            Console.WriteLine("");
            Console.WriteLine("Changing Jobs will reset your character's level to 1 and your XP to 0.");
            Console.WriteLine("However, when you change your job you also recieve Gold in exchange for the XP you are losing.");
            Console.WriteLine("Changing jobs can be a great way to make a lot of cash!");
            Console.WriteLine("Money does not do anything at the moment but it hopefully will some day!");
            Console.WriteLine("This will also be the fastest way to unlock additional character perks - again, Coming Soon (tm)");
            Console.WriteLine("");
            Console.WriteLine("And that's about it! Have fun playing!");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to return the main menu.");


        }
    }
}
