using System.Security.Cryptography.X509Certificates;

namespace lilminirpg
{
    internal class Program
    {
        public static void Main()
        {
            // Make character

            //CharacterMaker _charactermaker = new CharacterMaker();
            //_charactermaker.MakeCharacter();
            UI.MenuTracker = "MenuMain";
            UI.MenuLength = ItemLists.MainMenu.GetLength(0);
            //Menus.MenuMain();
            UI.MenuSelector();

        }
    }
}
