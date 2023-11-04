using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class QuestEngine
    {
        static Random randombool = new Random();
        static bool[] NewGameScreen = new bool[16];
        // Create an array and fill it with on/off statements (first 5 slots are always 'off')
        public static void CreateStageArray()
        {

            for (int i = 0; i < NewGameScreen.Length; ++i)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4)
                {
                    NewGameScreen[i] = false;
                }
                else
                {
                    NewGameScreen[i] = randombool.Next(2) == 1;
                }


            }
        }
        
        // Fills the stage array with objects
        public static void FillStageArray() 
        {
            for (int i = 0; i <NewGameScreen.Length; ++i)
            {
                if (NewGameScreen[i] == true)
                {
                    DiceRoller.RollDice(1, 99);
                    if (DiceRoller.RollResults > -1 && DiceRoller.RollResults < 71)
                    {
                        Console.WriteLine("MAKE MONSTER AND SLIDE IT INTO THE ARRAY");
                    }
                    else
                    {
                        Console.WriteLine($"Roll Result was: {DiceRoller.RollResults} (71-99)");
                    }
                }
                else
                {

                }
            }
        }

    }
}

// TESTS
// Console.WriteLine($"Array filled with{CurrentGameScreen[i]}");
// Console.WriteLine($"Roll Result was: {DiceRoller.RollResults} (0-70)");
