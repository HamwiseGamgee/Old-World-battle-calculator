using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using The_Old_World_Fighters;

public static class TroopRepository
{
    public static List<Troop> Troops { get; private set; } = new List<Troop>();
    public static Dictionary<string, Mount> Mounts { get; private set; } = new Dictionary<string, Mount>();

    static TroopRepository()
    {
        LoadMounts();
        LoadTroops();
    }

    private static void LoadMounts()
    {
        string mountsPath = "mounts.json";
        if (File.Exists(mountsPath))
        {
            string json = File.ReadAllText(mountsPath);
            Mounts = JsonConvert.DeserializeObject<Dictionary<string, Mount>>(json);
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
        string[] troopFiles = Directory.GetFiles(troopsDirectory, "*.json");

        foreach (string filePath in troopFiles)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                List<Troop> loadedTroops = JsonConvert.DeserializeObject<List<Troop>>(json);

                foreach (var troop in loadedTroops)
                {
                    if (!string.IsNullOrEmpty(troop.CurrentMount?.mountName) && Mounts.ContainsKey(troop.CurrentMount.mountName))
                    {
                        troop.CurrentMount = Mounts[troop.CurrentMount.mountName];
                    }

                    Troops.Add(troop);
                }
            }
            catch
            {
                Debug.WriteLine("Fucked up the mount loading, I think");
            }
        }
    }

    public static List<string> GetFactions()
    {
        Debug.WriteLine("ATTEMPTING TO LOAD FACTIONS INTO A LIST");
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
}

