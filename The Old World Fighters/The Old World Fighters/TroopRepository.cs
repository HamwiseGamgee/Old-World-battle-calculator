using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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

    private static void LoadTroops()
    {
 string troopsDirectory = "Troops"; // Folder containing faction JSON files

    if (!Directory.Exists(troopsDirectory))
    {
        Console.WriteLine($"Directory '{troopsDirectory}' not found.");
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
                if (!string.IsNullOrEmpty(troop.mount) && Mounts.ContainsKey(troop.mount))
                {
                    troop.ApplyMount(Mounts[troop.mount]);
                }
                Troops.Add(troop);
            }
        }
    }

    public static List<string> GetFactions()
    {
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

