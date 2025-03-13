using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Old_World_Fighters
{
    internal class TroopRepository
    {
        public static List<Troop> Troops = new List<Troop>
    {
        new Troop { troopName = "Clanrats", faction = "Skaven", wepSkil = 3, stg = 3, tuff = 3, ini = 4, att = 1, frontage = 5, sav1 = 6 },
        new Troop { troopName = "Stormvermin", faction = "Skaven", wepSkil = 4, stg = 4, tuff = 3, ini = 5, att = 1, frontage = 5, sav1 = 5 },
        new Troop { troopName = "Empire Halberdiers", faction = "Empire", wepSkil = 3, stg = 4, tuff = 3, ini = 3, att = 1, frontage = 5, sav1 = 6 },
        new Troop { troopName = "Empire Greatswords", faction = "Empire", wepSkil = 4, stg = 5, tuff = 3, ini = 1, att = 1, frontage = 5, sav1 = 5 },
        new Troop { troopName = "Inner Circle Knights (Charging with Lances)", faction = "Empire", wepSkil = 4, stg = 6, ini = 4, sav1 = 2, frontage = 4},
        new Troop { troopName = "Rat Ogres", faction = "Skaven", wepSkil = 4, stg = 5, tuff = 4, ini = 4, att = 3, frontage = 3, sav1 = 6 },
        new Troop { troopName = "Rat Swarms", faction = "Skaven", wepSkil = 2, stg = 2, tuff = 2, ini = 4, att = 5, frontage = 3 },
    };

        public static List<string> GetFactions()
        {
            return Troops.Select(t => t.faction).Distinct().ToList();
        }

        // Get troops by faction
        public static List<Troop> GetTroopsByFaction(string faction)
        {
            return Troops.Where(t => t.faction == faction).ToList();
        }
        public static Troop GetTroopByName(string name)
        {
            return Troops.Find(t => t.troopName == name);
        }
    }
}