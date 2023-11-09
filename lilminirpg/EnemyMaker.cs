using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class EnemyMaker
    {
        public Enemy MakeEnemy(int enemyBaseID)
        {
            Enemy createdEnemy = new Enemy();

            createdEnemy.CurrentLevel = 0;
            for (int i = 0; i < DataLists.EnemiesList.GetLength(1); ++i)
            {
                SetStat(enemyBaseID, i, createdEnemy);
            }
            return createdEnemy;
        }
        private static void SetStat(int enemyBaseID, int statPosition, Enemy createdEnemy)
        {
            if (statPosition == 0)
            {
                createdEnemy.CharacterName = DataLists.EnemiesList[enemyBaseID, statPosition];
//                Console.WriteLine($"Creating: {createdEnemy.CharacterName}");
            }
            else if (statPosition == 1)
            {

            }
            else if (statPosition == 2)
            {
                createdEnemy.HealthPointsMax = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.HealthPointsMax}");
            }
            else if (statPosition == 3)
            {
                createdEnemy.StatStrength = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.StatStrength}");
            }
            else if (statPosition == 4)
            {
                createdEnemy.StatAtkSpeed = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.StatAtkSpeed}");
            }
            else if (statPosition == 5)
            {
                createdEnemy.MonsterPerk1 = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
             //   Console.WriteLine($"CharName: {NewEnemy.MonsterPerk1}");
            }
            else if (statPosition == 6)
            {
                createdEnemy.MonsterPerk2 = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterPerk2}");
            }
            else if (statPosition == 7)
            {
                createdEnemy.MonsterPerk3 = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterPerk3}");
            }
            else if (statPosition == 8)
            {
                createdEnemy.GoldDropped = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
             //   Console.WriteLine($"CharName: {NewEnemy.GoldDropped}");
            }
            else if (statPosition == 9)
            {
                createdEnemy.XPDropped = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.XPDropped}");
            }
            else if (statPosition == 10)
            {
                createdEnemy.MonsterFamily = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterFamily}");
            }
            else if (statPosition == 11)
            {
                createdEnemy.MonsterEnvironment = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterEnvironment}");
            }
            else if (statPosition == 12)
            {
                createdEnemy.MonsterRank = Int32.Parse(DataLists.EnemiesList[enemyBaseID, statPosition]);
            //    Console.WriteLine($"CharName: {NewEnemy.MonsterRank}");
            }
            else
            {
                UI.InvalidSelection();
            }
        }
    }
}

