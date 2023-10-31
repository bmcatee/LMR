namespace lilminirpg
{
    internal class Program
    {

        public static void Main()
        {
            int selectedoption = 0;
            string menuinput = null;
            string temp = "";

            while (menuinput != "Escape")
            {
                Console.Clear();
                Player _player = new Player();
                Console.WriteLine("Welcome new player! Please enter your character's name:");
                _player.CharacterName = Console.ReadLine();
                Console.Clear();
                Console.CursorVisible = false;
                while (menuinput != "Enter")
                {
                    Console.WriteLine($"Hello {_player.CharacterName}! Next you will choose your class, a weapon, and an accessory.");
                    Console.WriteLine("Your class choices are:");
                    List<string> playerclasses = new List<string>()
                {
                    "Knight",
                    "Thief",
                    "Wizard",
                    "Adventurer",
                    "Monk"
                };

                    for (int i = 0; i < playerclasses.Count; ++i)
                    {
                        char cursor = ' ';
                        if (i == selectedoption)
                        {
                            cursor = '>';
                        }
                        Console.WriteLine($"{cursor} {playerclasses[i]}");
                    }
                    menuinput = Console.ReadKey(true).Key.ToString();
                    if (menuinput == "UpArrow")
                    {
                        Console.Clear();
                        --selectedoption;
                    }
                    else if (menuinput == "DownArrow")
                    {
                        Console.Clear();
                        ++selectedoption;
                    }
                }
                temp = Console.ReadLine();
                if (temp == "Knight" || temp == "Thief" || temp == "Wizard" || temp == "Adventurer" || temp == "Monk")
                {
                    _player.ClassName = temp;
                    Console.WriteLine($"You have chosen {temp}!");
                }
                else
                {
                    Console.WriteLine("You have entered an invalid selection. Please try again.");
                }
                _player.ClassName = Console.ReadLine();

                Console.WriteLine("Now please choose a weapon:");
                List<string> playerweapons = new List<string>()
                {
                    "One-Handed Sword: A good, all-around weapon.",
                    "Two-Handed Sword: Slow but packs a punch.",
                    "Knife: Fast and nimble.",
                    "Wand: Does randomized magical damage.",
                    "Staff: Excellent for defensive fighting.",
                    "Knuckle Wraps: For those that like to brawl.",
                };
                foreach (string playerweapon in playerweapons)
                {
                    Console.WriteLine(playerweapon);
                }
                _player.WornWeapon = Console.ReadLine();
                List<string> playeraccessoriess = new List<string>()
                {
                    "Shield: A bit bulky, but keeps distance between You and Them.",
                    "Pocket Salt: May cause the enemy to become Blinded.",
                    "Dancer's Shoes: Makes it easier to dodge attacks.",
                    "Water Pendant: Has a high chance of your attack inflicting Water damage.",
                    "Fire Ring: Has a high chance of your attack inflicting Fire damage.",
                    "Lightning Brooch: Has a high chance of your attack inflicting Lightning damage."
                };
                foreach (string playeraccessory in playeraccessoriess)
                {
                    Console.WriteLine(playeraccessory);
                }

                _player.WornAccessory = Console.ReadLine();
                Console.WriteLine($"You have chosen {_player.ClassName}, {_player.WornWeapon}, and {_player.WornAccessory} - is this correct?");
            }
        }
    }
}