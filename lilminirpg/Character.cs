using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Character
    {
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public int CurrentStage { get; set; } = 0;
        public int CurrentLevel { get; set; } = 0;
        public int HealthPointsMax { get; set; } = 0;
        public int HealthPointsCurrent { get; set; } = 0;
        public int StatStrength { get; set; } = 0;
        public int StatDexterity { get; set; } = 0;
        public int StatIntelligence { get; set; } = 0;
        public int StatLuck { get; set; } = 0;
        public int StatMoveSpeed { get; set; } = 0;
        public int StatAttackSpeed { get; set; } = 0;
    }

    public class Player : Character
    {
        public int XPCurrent { get; set; } = 0;
        public int XPToLevel { get; set; } = 0;
        public int GoldCurrent { get; set; } = 0;
        public int TilesMoved { get; set; } = 0;
        public int MaximumStage { get; set; } = 0;
        public Job? PlayerJob { get ; set; }
        public Weapon? WornWeapon { get; set; }
//        public DataLists.Clothing WornClothing { get; set; }
        public Accessory? WornAccessory { get; set; }
    }


    public class CharacterStatList
    {
        public List<CharacterStatList>? CharacterStats { get; set; }
    }
}
