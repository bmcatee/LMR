using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lilminirpg
{

    internal class Movement
    {
        public static int PlayerPos = 0;

        public async static void PlayerPosition(int length)
        {
            Console.WriteLine($"length = {length} || PlayerPos = {PlayerPos}");

            for (int i = 0; i < length; ++i)
            {
                await PlayerMovement(1, QuestEngine.CurrentGameScreen[i]);
            }
            QuestEngine.CreateStageArray();

        }

        public async static Task PlayerMovement(int delay, int gameobject)
        {
            await Task.Delay(delay * 1000);
            ++PlayerPos;
            Console.WriteLine($"Player at position {PlayerPos} & array filled with {gameobject}");
        }

    }
}
