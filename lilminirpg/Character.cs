using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class CharacterStatList
    {
        public List<CharacterStatList> characterStats { get; set; }
    }
    public class Character
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentStage { get; set; }
        public int CurrentLevel { get; set; }
        public int HealthPointsMax { get; set; }
        public int HealthPointsCurrent { get; set; }
        public int StatStrength { get; set; }
        public int StatDexterity { get; set; }
        public int StatIntelligence { get; set; }
        public int StatLuck { get; set; }
        public int StatMoveSpeed { get; set; }
        public int StatAttackSpeed { get; set; }
    }

    public class Player : Character
    {
        public int XPCurrent { get; set; }
        public int XPToLevel { get; set; }
        public DataLists.PlayerClassStats PlayerClass { get; set; }
        public DataLists.PlayerWeaponStats WornWeapon { get; set; }
        public DataLists.Clothing WornClothing { get; set; }
        public DataLists.PlayerAccessoryStats WornAccessory { get; set; }
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
