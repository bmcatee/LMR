using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Character
    {
        public string CharacterName { get; set; }
        public string CharacterDescription { get; set; }
        public int CurrentLevel { get; set; }
        public int HealthPointsMax { get; set; }
        public int HealthPointsCurrent { get; set; }
        public int StatStrength { get; set; }
        public int StatDexterity { get; set; }
        public int StatIntelligence { get; set; }
        public int StatMoveSpeed { get; set; }
        public int StatAttackSpeed { get; set; }

    }

    public class Player : Character
    {
        public DataLists.PlayerClassInfo PlayerClass { get; set; }
        public int XPCurrent { get; set; }
        public int XPToLevel { get; set; }
        public DataLists.PlayerWeaponList WornWeapon { get; set; }
        public DataLists.Clothing WornClothing { get; set; }
        public DataLists.PlayerAccessoryInfo WornAccessory { get; set; }
    }

    public class Enemy : Character
    {
        public int MonsterPerk1 { get; set; }
        public int MonsterPerk2 { get; set; }
        public int MonsterPerk3 { get; set; }
        public int GoldDropped { get; set; }
        public int XPDropped { get; set; }
        public int MonsterFamily { get; set; }
        public int MonsterEnvironment { get; set; }
        public int MonsterRank { get; set; }
    }
}
