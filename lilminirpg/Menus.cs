using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Menus
    {
        int selectedoption = 0;
        string menuinput = null;
        char cursor = ' ';
        Player _player = new Player();

        public void menuName()
        {
            while (menuinput != "Escape")
            {
                Console.Clear();
                Console.WriteLine("Welcome new player! Please enter your character's name:");
            }
            _player.CharacterName = Console.ReadLine();
            Console.Clear();
        }
        public void menuClass()
        {
            selectedoption = 0;
            List<string> playerClasses = new List<string>()
                {
                    "Knight",
                    "Thief",
                    "Wizard",
                    "Adventurer",
                    "Monk"
                };

            while (menuinput != "Enter")
            {
                Console.CursorVisible = false;
                Console.WriteLine($"Hello {_player.CharacterName}! Next you will choose your class, a weapon, and an accessory.");
                Console.WriteLine("Your class choices are:");
                for (int i = 0; i < playerClasses.Count; i++)
                {
                    if (i == selectedoption)
                    {
                        cursor = '*';
                    }
                    Console.WriteLine($"[{cursor}] {playerClasses[i]}");
                }
                menuinput = Console.ReadKey(true).Key.ToString();
                if (menuinput == "UpArrow")
                {
                    Console.Clear();
                    selectedoption--;
                    if (selectedoption < 0) 
                    {
                        selectedoption = playerClasses.Count - 1;
                    }
                }
                else if (menuinput == "DownArrow")
                {
                    Console.Clear();
                    selectedoption++;
                    if (selectedoption < playerClasses.Count -1)
                    {
                        selectedoption = 0;
                    }
                }
            }
            if (selectedoption == 0) {
                _player.ClassName = playerClasses[0];
            }
            else if (selectedoption == 1)
            {
                _player.ClassName = playerClasses[1];
            }
            else if (selectedoption == 2)
            {
                _player.ClassName = playerClasses[2];
            }
            else if (selectedoption == 3)
            {
                _player.ClassName = playerClasses[3];
            }
            else if (selectedoption == 4)
            {
                _player.ClassName = playerClasses[4];
            }
            else
            {
                Console.WriteLine("You have entered an invalid selection. Please try again.");
            }
            Console.WriteLine($"You have chosen {_player.ClassName}!");
        }
        public void menuWeapon()
        {
            selectedoption = 0;
            List<string> playerWeapons = new List<string>()
                {
                    "One-Handed Sword: A good, all-around weapon.",
                    "Two-Handed Sword: Slow but packs a punch.",
                    "Knife: Fast and nimble.",
                    "Wand: Does randomized magical damage.",
                    "Staff: Excellent for defensive fighting.",
                    "Knuckle Wraps: For those that like to brawl.",
                };
            while (menuinput != "Enter")
            {
                Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine("Now please choose a weapon:");
                for (int i =0; i < playerWeapons.Count; i++)
                {
                    if (i == selectedoption)
                    {
                        cursor = '*';
                    }
                    Console.WriteLine($"[{cursor}] {playerWeapons[i]}");
                }
                menuinput = Console.ReadKey(true).Key.ToString();
                if (menuinput == "UpArrow")
                {
                    Console.Clear();
                        selectedoption--;
                    if (selectedoption < 0)
                    {
                        selectedoption = playerWeapons.Count - 1;
                    }    
                }
                else if (menuinput == "DownArrow")
                {
                    Console.Clear();
                    selectedoption++;
                    if (selectedoption < playerWeapons.Count - 1) 
                    {
                        selectedoption = 0;
                    }
                }
                if (selectedoption == 0)
                {
                    _player.WornWeapon = playerWeapons[0];
                }
                else if (selectedoption == 1)
                {
                    _player.WornWeapon = playerWeapons[1];
                }
                else if (selectedoption == 2)
                {
                    _player.WornWeapon = playerWeapons[2];
                }
                else if (selectedoption == 3)
                {
                    _player.WornWeapon = playerWeapons[3];
                }
                else if (selectedoption == 4)
                {
                    _player.WornWeapon = playerWeapons[4];
                }
                else if (selectedoption == 5)
                {
                    _player.WornWeapon = playerWeapons[5];
                }
            }
        }
        public void menuAccessory()
        {
            selectedoption = 0;
            List<string> playerAccessoriess = new List<string>()
                {
                    "Shield: A bit bulky, but keeps distance between You and Them.",
                    "Pocket Salt: May cause the enemy to become Blinded.",
                    "Dancer's Shoes: Makes it easier to dodge attacks.",
                    "Water Pendant: Has a high chance of your attack inflicting Water damage.",
                    "Fire Ring: Has a high chance of your attack inflicting Fire damage.",
                    "Lightning Brooch: Has a high chance of your attack inflicting Lightning damage."
                };
            while (menuinput != "Enter")
            {
                Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine("Now please choose an accessory.");
                for (int i = 0; i < playerAccessoriess.Count; i++) 
                {

                    if (i == selectedoption)
                    {
                        cursor = '*';
                    }
                    Console.WriteLine($"[{cursor}] {playerAccessoriess[i]}");
                }
                menuinput = Console.ReadKey(true).Key.ToString();
                if (menuinput == "UpArrow")
                {
                    Console.Clear();
                    selectedoption--;
                    if (selectedoption < 0)
                    {
                        selectedoption = playerAccessoriess.Count - 1;
                    }
                }
                else if (menuinput == "DownArrow")
                {
                    Console.Clear();
                    selectedoption++;
                    if (selectedoption < playerAccessoriess.Count - 1)
                    {
                        selectedoption = 0;
                    }
                }
                if (selectedoption == 0)
                {
                    _player.WornWeapon = playerAccessoriess[0];
                }
                else if (selectedoption == 1)
                {
                    _player.WornWeapon = playerAccessoriess[1];
                }
                else if (selectedoption == 2)
                {
                    _player.WornWeapon = playerAccessoriess[2];
                }
                else if (selectedoption == 3)
                {
                    _player.WornWeapon = playerAccessoriess[3];
                }
                else if (selectedoption == 4)
                {
                    _player.WornWeapon = playerAccessoriess[4];
                }
                else if (selectedoption == 5)
                {
                    _player.WornWeapon = playerAccessoriess[5];
                }
            }
        }
    }
}

