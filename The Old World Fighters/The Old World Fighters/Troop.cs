using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Old_World_Fighters
{
public class Troop
{
    public string troopName { get; set; } = "Unit 1";
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
    public string faction { get; set; } = "Whoops";
    public int lead { get; set; } = 7;
    public int stubborn {get; set;} = 0; //1 = Stubborn, 2 = unbreakable
    public int ap { get; set; } = 0;
    public bool fightInExtraRank { get; set;} = false;
    public int modelsInUnit {get; set;} = 10;
    public int filesForRankBonus {get; set;} = 5;
    public int? MountId { get; set; }
    public Mount? CurrentMount { get; set; }
    public bool isCloseorder {get; set;} = true;
    public bool magicAttacks {get; set;} = false;
    public int armBane {get; set;} = 0;
    public weapon currentWeapon { get; set; }

    // Constructor 
    public Troop()
    {
        currentWeapon = WeaponRepository.Weapons.FirstOrDefault(w => w.weaponName == "Hand Weapon") 
                        ?? new weapon { weaponName = "Hand Weapon" }; // Fallback if not found
    }

    // Method to change weapons
    public void ChangeWeapon(string newWeaponName)
    {
        var newWeapon = WeaponRepository.Weapons.FirstOrDefault(w => w.weaponName == newWeaponName);
        if (newWeapon != null)
        {
            currentWeapon = newWeapon;
        }
        else
        {
            Console.WriteLine($"Weapon '{newWeaponName}' not found! Keeping current weapon.");
        }
    }
}
/* TODO: USE THIS method to swap weapons
theTroopInQuestion.ChangeWeapon("Greatsword");
*/
}
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
        public bool killingBlow {get; set;} = false

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
    }
}
