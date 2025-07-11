using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Old_World_Fighters;

namespace The_Old_World_Fighters
{
public class Troop
{   //Attributes marked with * Should always be filled in .json
    public string troopName { get; set; } = "Unit 1"; //*
    public int wepSkil { get; set; } = 3;
    public int stg { get; set; } = 3;
    public int tuff { get; set; } = 3;
    public int ini { get; set; } = 3;
    public int wounds { get; set; } = 1;
    public int att { get; set; } = 1;
    public int sav1 { get; set; } = 7;
    public int sav2 { get; set; } = 7;
    public int sav3 { get; set; } = 7;
    public int frontage { get; set; } = 5;
    public int Casualties {get; set; } = 0;
    public int FloatingWounds {get; set; } = 0;
    public int FloatingCasualties {get; set;} = 0;
    public string faction { get; set; } = "Whoops"; //*
    public int lead { get; set; } = 7;
    public int stubborn {get; set;} = 0; //1 = Stubborn, 2 = unbreakable
    public int UnitStrengthMultiplier {get; set;} = 1;
    public int RankBonus {get; set;} = 0;
    public int ap { get; set; } = 0;
    public bool fightInExtraRank { get; set;} = false;
    public int ModelsInUnit {get; set;} = 10;
    public int filesForRankBonus {get; set;} = 5;
    public int maxRankBonus {get; set;} = 2;
    public int CombatScore {get; set;} = 0;
    public bool isWarband {get; set;} = false;
    public int ModelmmWidth {get; set;} = 25;
    public int ModelmmDepth {get; set;} = 25;
    public int? MountId { get; set; }
    public Mount? CurrentMount { get; set; }
    public bool isCloseorder {get; set;} = true;
    public bool magicAttacks {get; set;} = false;
    public int armBane {get; set;} = 0;    
    public bool isPoisoned {get; set;} = false;
    public bool isEthereal {get; set;} = false;
    public bool isUnstable {get; set;} = false;
    public bool causeFear {get; set;} = false;
    public bool causeTerror {get; set;} = false;
    public bool isFlaming {get; set;} = false;
    public bool isFlammable {get; set;} = false;
    public string WeaponId { get; set; } = "1HW"; // Default weapon ID
    public bool isCharging {get; set; } = false;
    public bool BattlePressers {get; set; } = false;

        // Stores only the wepId in JSON and later replaced by real object from repository
    public Weapon currentWeapon { get; set; } = new Weapon(); 

    // Optional helper method to change weapons in runtime, e.g. from UI
    public void ChangeWeapon(string newWepId)
    {
        var newWeapon = TroopRepository.Weapons.FirstOrDefault(w => w.wepId == newWepId);
        if (newWeapon != null)
        {
            currentWeapon = newWeapon;
        }
        else
        {
            Console.WriteLine($"Weapon ID '{newWepId}' not found! Keeping current weapon.");
        }
    }
}
public class Infantry : Troop
{
    public Infantry()
    {
        BattlePressers = true;
    }
}
public class HeavyInfantry : Infantry
{
    public HeavyInfantry()
    {
    filesForRankBonus = 4;
    ModelmmDepth = 30;
    ModelmmWidth = 30;
    BattlePressers = true;
    }
}
public class MonstrousInfantry : Infantry
{
    public MonstrousInfantry()
    {
        UnitStrengthMultiplier = 3
        stg = 4;
        tuff = 4;
        wounds = 3;
        ModelmmDepth = 40;
        ModelmmWidth = 40;
    }
}
public class Swarm : Infantry
{
    public Swarm()
    {
        UnitStrengthMultiplier = 3;
        stubborn = 2;
        ModelmmDepth = 40;
        ModelmmDepth = 40;
    }
}
public class Cavalry : Troop
{
    public Cavalry()
    {
        UnitStrengthMultiplier = 2;
        maxRankBonus = 1;
        ModelmmDepth = 50;
    }
}
public class HeavyCavalry : Cavalry
{
    public HeavyCavalry()
    {
        filesForRankBonus = 2;
        MountId = 1;
        ModelmmWidth = 30;
        ModelmmDepth = 60;
    }
}
public class MonstrousCavalry : Cavalry
    {
    public MonstrousCavalry()
    {
        filesForRankBonus = 3;
        ModelmmDepth = 100;
        ModelmmWidth = 50;
        wounds = 3;
        UnitStrengthMultiplier = 3;
    }
    }
public class WarBeast : Cavalry
{
    public WarBeast()
    {
        UnitStrengthMultiplier = 1;
    }
}
    }

 /* TODO: USE THIS method to swap weapons
theTroopInQuestion.ChangeWeapon("GrtWpn");
*/
 
    public class Mount 
    {
        public int Id {get; set;} = 0;
        public string mountName {get; set;} = "Horsie";
        public int wepSkil {get; set;} = 3;
        public int stg {get; set;} = 3;
        public int tuffBonus {get; set;} = 0;
        public int woundBonus {get; set;} = 0;
        public int armBonus {get; set;} = 0;
        public int ini {get; set;} = 3;
        public int att {get; set;} = 1;
        public int ap {get; set;} = 0;
        public int armBane {get; set;} = 0;
        public bool killingBlow { get; set; } = false;
        public bool isPoisoned { get; set; } = false;
        public Troop? Rider { get; set; } = null;

}

    public class Weapon
    {
        public string wepId {get; set;} = "1HW";
        public string weaponName {get; set;} = "Hand Weapon";
        public int stgBonus {get; set;} = 0;
        public int apBonus {get; set;} = 0;
        public int iniBonus {get; set;} = 0;
        public bool affectsExtraRanks { get; set; } = false;
        public int attBonus {get; set;} = 0;
        public bool canHoldShield {get; set;} = true;
        public int armBaneBonus {get; set;} = 0;
        public bool gainsMagic {get; set;} = false;
        public bool isPoisoned {get; set;} = false;
        public bool killingBlow {get; set;} = false;
        public bool extraRankOnCharge {get; set;} = false;
    }

