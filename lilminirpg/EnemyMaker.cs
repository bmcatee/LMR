using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class EnemyMaker
    {
        public static Enemy NewEnemy = new Enemy();

        public Enemy MakeEnemy(int enemybaseid)
        {
            NewEnemy.CurrentLevel = 0;
            for (int i = 0; i < DataLists.EnemiesList.GetLength(1); ++i)
            {
                SetStat(enemybaseid, i);
            }
            return NewEnemy;
        }
        public static void SetStat(int enemybaseid, int statposition)
        { 
            if (statposition == 0)
            {
                NewEnemy.CharacterName = DataLists.EnemiesList[enemybaseid, statposition];
                Console.WriteLine($"Creating: {NewEnemy.CharacterName}");
            }
            else if (statposition == 1)
            {

            }
            else if (statposition == 2)
            {
                NewEnemy.HealthPointsMax = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.HealthPointsMax}");
            }
            else if (statposition == 3)
            {
                NewEnemy.StatStrength = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.StatStrength}");
            }
            else if (statposition == 4)
            {
                NewEnemy.StatAtkSpeed = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.StatAtkSpeed}");
            }
            else if (statposition == 5)
            {
                NewEnemy.MonsterPerk1 = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
             //   Console.WriteLine($"CharName: {NewEnemy.MonsterPerk1}");
            }
            else if (statposition == 6)
            {
                NewEnemy.MonsterPerk2 = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterPerk2}");
            }
            else if (statposition == 7)
            {
                NewEnemy.MonsterPerk3 = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterPerk3}");
            }
            else if (statposition == 8)
            {
                NewEnemy.GoldDropped = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
             //   Console.WriteLine($"CharName: {NewEnemy.GoldDropped}");
            }
            else if (statposition == 9)
            {
                NewEnemy.XPDropped = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.XPDropped}");
            }
            else if (statposition == 10)
            {
                NewEnemy.MonsterFamily = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterFamily}");
            }
            else if (statposition == 11)
            {
                NewEnemy.MonsterEnvironment = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterEnvironment}");
            }
            else if (statposition == 12)
            {
                NewEnemy.MonsterRank = Int32.Parse(DataLists.EnemiesList[enemybaseid, statposition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterRank}");
            }
            else
            {
                UI.InvalidSelection();
            }
        }
    }
}

