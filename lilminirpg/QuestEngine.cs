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
        static bool[] CurrentGameScreen = new bool[16];
        // Create an array and fill it with on/off statements (first 5 slots are always 'off')
        public static void CreateStageArray()
        {

            for (int i = 0; i < CurrentGameScreen.Length; ++i)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4)
                {
                    CurrentGameScreen[i] = false;
                }
                else
                {
                    CurrentGameScreen[i] = randombool.Next(2) == 1;
                }

                // TESTS
                // Console.WriteLine($"{CurrentGameScreen[i]}");
            }
        }
        
        // Fills the stage array with objects
        public static void FillStageArray() 
        {
            
        }

    }
}
