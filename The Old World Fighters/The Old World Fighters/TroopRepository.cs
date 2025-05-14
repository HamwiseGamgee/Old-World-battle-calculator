using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using The_Old_World_Fighters;

public static class TroopRepository
{
    public static List<Troop> Troops { get; private set; } = new List<Troop>();
    public static Dictionary<string, Mount> Mounts { get; private set; } = new Dictionary<string, Mount>();
    public static List<Weapon> Weapons { get; private set; } = new List<Weapon>();


    public static void LoadWeapons()
     {
        string weaponsPath = Path.Combine("Repos", "WeaponRepo.json");
        if (File.Exists(weaponsPath))
         {
             string json = File.ReadAllText(weaponsPath);
            Weapons = JsonConvert.DeserializeObject<List<Weapon>>(json) ?? new List<Weapon>();
           // Debug.WriteLine($"Loaded {Weapons.Count} weapons from {weaponsPath}");
        }
        else
        {
            Debug.WriteLine($"Weapons file '{weaponsPath}' not found.");
        }
    }
    /* public static void LoadMounts()
     {
         string mountsPath = "mounts.json";
         if (File.Exists(mountsPath))
         {
             string json = File.ReadAllText(mountsPath);
             Mounts = JsonConvert.DeserializeObject<Dictionary<string, Mount>>(json);
         }
     } KEEPING FOR A RAINY DAY*/

    public static void LoadMounts()// COPIED FROM WINDOWS COPILOT
    {
        string mountsPath = Path.Combine("Repos", "MountRepo.json");
        if (File.Exists(mountsPath))
        {
            try
            {
                string json = File.ReadAllText(mountsPath);
                var loadedMounts = JsonConvert.DeserializeObject<List<Mount>>(json) ?? new List<Mount>();
                Mounts = loadedMounts.ToDictionary(m => m.Id.ToString());

                Debug.WriteLine($"Loaded {Mounts.Count} mounts from {mountsPath}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading mounts: This is Copilot's Fault");
            }
        }
        else
        {
            Debug.WriteLine($"Mounts file '{mountsPath}' not found.");
        }
    }
public static void LoadTroops()
{
    string troopsDirectory = "Repos"; // Folder containing faction JSON files

    if (!Directory.Exists(troopsDirectory))
    {
        Debug.WriteLine($"Directory '{troopsDirectory}' not found.");
        return;
    }

    // Get all JSON files in the Troops directory
    string[] troopFiles = Directory.GetFiles(troopsDirectory, "*Troops.json", SearchOption.AllDirectories);
    Debug.WriteLine($" Files found: {string.Join(", ", troopFiles)}");

    foreach (string filePath in troopFiles)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            List<Troop> loadedTroops = JsonConvert.DeserializeObject<List<Troop>>(json);
            Debug.WriteLine($"Loaded {loadedTroops.Count} troops from {filePath}");

            foreach (var troop in loadedTroops)
            {
                // ✅ Assign correct weapon using wepId
                if (!string.IsNullOrEmpty(troop.WeaponId))
                {
                    var matchedWeapon = Weapons.FirstOrDefault(w => w.wepId == troop.WeaponId);
                    if (matchedWeapon != null)
                    {
                        troop.currentWeapon = matchedWeapon;
                            Debug.WriteLine($"Successfully gave {troop.currentWeapon.weaponName} to {troop.troopName}.");
                    }
                    else
                    {
                        Debug.WriteLine($"Weapon with wepId '{troop.currentWeapon.wepId}' not found. Using default weapon.");
                        troop.currentWeapon = new Weapon();
                    }
                }

                // ✅ Assign correct mount
                if (troop.MountId.HasValue && Mounts.TryGetValue(troop.MountId.Value.ToString(), out var mount))
                {
                    troop.CurrentMount = mount;
                }

                Troops.Add(troop);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading troops from {filePath}: {ex.Message}");
        }
    }
}
    public static List<string> GetFactions()
    {
        Debug.WriteLine("Attempting to Load Factions into a list");
        HashSet<string> factions = new HashSet<string>();
        foreach (var troop in Troops)
        {
            factions.Add(troop.faction);
        }
        return new List<string>(factions);
    }

    public static List<Troop> GetTroopsByFaction(string faction)
    {
        return Troops.FindAll(t => t.faction == faction);
    }
    public static List<string> FillWeapons()
    {
        List<string> weaponNames = new List<string>();
        foreach (var weapon in Weapons)
        {
            weaponNames.Add(weapon.weaponName);
        }
        return weaponNames;
    }
}

