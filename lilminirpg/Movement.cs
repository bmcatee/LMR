using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{

    internal class Movement
    {
        public static int PlayerPos = 0;

        public async static void PlayerPosition(int length)
        {
            Console.WriteLine($"length = {length} || PlayerPos = {PlayerPos}");

            while (Console.ReadLine() != "Enter")
            {
                for (int i = 0; i < length; ++i)
                {
                await PlayerMovement(1);
                }
            }
            Console.WriteLine($"Doop!");
            Console.ReadLine();
            QuestEngine.CreateStageArray();

        }

        public async static Task PlayerMovement(int delay)
        {
            await Task.Delay(delay * 1000);
            ++PlayerPos;
            Console.WriteLine($"Player at position {PlayerPos}");
        }

    }
}
