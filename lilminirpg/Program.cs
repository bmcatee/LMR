namespace lilminirpg
{
    internal class Program
    {

        public static void Main()
        {
            Player _player = new Player();
            Console.WriteLine("Welcome new player! Please enter your character's name:");
            _player.CharacterName = Console.ReadLine();
            Console.WriteLine("Hello {0}! Next you will choose your class, a weapon, and an accessory.", _player.CharacterName);
            Console.WriteLine("Your class choices are:");
            Console.WriteLine("Knight");
            Console.WriteLine("Thief");
            Console.WriteLine("Wizard");
            Console.WriteLine("Adventurer");
            Console.WriteLine("Monk");
            string temp = Console.ReadLine();
            if (temp == "Knight" || temp == "Thief" || temp == "Wizard" || temp == "Adventurer" || temp == "Monk")
            {
                _player.ClassName = temp;
                Console.WriteLine("You have chosen {0}!", temp);
            }
            else
            {
                Console.WriteLine("You have entered an invalid selection. Please try again.");
            }
            _player.ClassName = Console.ReadLine();
            Console.WriteLine("Now please choose a weapon:");
            Console.WriteLine("One-Handed Sword: A good, all-around weapon.");
            Console.WriteLine("Two-Handed Sword: Slow but packs a punch.");
            Console.WriteLine("Knife: Fast and nimble.");
            Console.WriteLine("Wand: Does randomized magical damage.");
            Console.WriteLine("Staff: Excellent for defensive fighting.");
            Console.WriteLine("Knuckle Wraps: For those that like to brawl.");
            _player.WornWeapon = Console.ReadLine();
            Console.WriteLine("Lastly, please choose your accessory:");
            Console.WriteLine("Shield: A bit bulky, but keeps distance between You and Them.");
            Console.WriteLine("Pocket Salt: May cause the enemy to become Blinded.");
            Console.WriteLine("Dancer's Shoes: Makes it easier to dodge attacks.");
            Console.WriteLine("Water Pendant: Has a high chance of your attack inflicting Water damage.");
            Console.WriteLine("Fire Ring: Has a high chance of your attack inflicting Fire damage.");
            Console.WriteLine("Lightning Brooch: Has a high chance of your attack inflicting Lightning damage.");
            _player.WornAccessory = Console.ReadLine();
            Console.WriteLine("You have chosen {0}, {1}, and {2} - is this correct?", _player.ClassName, _player.WornWeapon, _player.WornAccessory);
        }
    }
}