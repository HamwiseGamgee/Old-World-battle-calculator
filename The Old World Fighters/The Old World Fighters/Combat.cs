using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace The_Old_World_Fighters
{
 
    public class Combat
    {
        private static Random rand = new Random();
        // Reference to the form's richTextBox
        private static RichTextBox richTextBox1 = Form1.Instance.RichTextBoxOutput;
         
         // Roll to check if the attack hits based on the target number (e.g., Weapon Skill)
private static bool RollDice(int targetNumber)
{
    return rand.Next(1, 7) >= targetNumber;
}
            // Here is a method to get the To Hit number for two Weapon Skill comparisons
            private static int GetToHitRoll(int attackerWS, int defenderWS)
{
    if (attackerWS > (2 * defenderWS)) 
        return 2;
    else if (attackerWS > defenderWS) 
        return 3;
    else if (defenderWS > (2 * attackerWS)) 
        return 5;
    else 
        return 4;
}


// This class holds either a Troop or a Mount with their initiative value.
// It's used to create a unified initiative list for sorting and display.
private class InitiativeRoster
{
    public Troop? FighterInput { get; set; }     // Will hold a Troop object
    public Mount? MountInput { get; set; }       // Will hold a Mount object (if applicable)
    public int Initiative { get; set; }          // Initiative value for sorting

    // Constructor for a Troop
    public InitiativeRoster(Troop troop)
    {
        FighterInput = troop;
        Initiative = troop.ini;  // 'ini' is the initiative property on Troop
    }

    // Constructor for a Mount
    public InitiativeRoster(Mount mount)
    {
        MountInput = mount;
        Initiative = mount.ini;  // 'ini' is the initiative property on Mount
    }
}

// Static method to build and return a sorted initiative list
private static List<InitiativeRoster> GetInitiative(Troop input1, Troop input2)
{
    // Validate that both troop inputs are not null
    if (input1 == null || input2 == null)
    {
        Debug.WriteLine("Initiative order failed: Troop inputs were not both provided.");
        return new List<InitiativeRoster>(); // Return an empty list instead of breaking
    }

    // Create the base initiative list with the two Troops
    var roster = new List<InitiativeRoster>
    {
        new InitiativeRoster(input1),
        new InitiativeRoster(input2)
    };

    // Add mounts to the list if they exist
    if (input1.CurrentMount != null)
        roster.Add(new InitiativeRoster(input1.CurrentMount));

    if (input2.CurrentMount != null)
        roster.Add(new InitiativeRoster(input2.CurrentMount));

    // Sort the list in descending order of initiative (higher goes first)
    var sortedRoster = roster
        .OrderByDescending(entry => entry.Initiative)
        .ToList();

    // Output the sorted roster to debug for verification
    Debug.WriteLine("=== Initiative Order ===");
    foreach (var group in sortedRoster.GroupBy(r => r.Initiative))
    {
        Debug.WriteLine($"Initiative {group.Key}:");

        foreach (var entry in group)
        {
            if (entry.FighterInput != null)
                Debug.WriteLine($"  Troop: {entry.FighterInput.TroopName}");
            else if (entry.MountInput != null)
                Debug.WriteLine($"  Mount: {entry.MountInput.MountName}");
        }
    }

    return sortedRoster;
}

private static int ResolveAttacks(Troop attacker, Troop defender)
{
    int totalAttacks = attacker.frontage * attacker.att;
    int successfulAttacks = 0;
    int successfulWounds = 0;
    int unsavedWounds = 0;

    // Calculate To-Hit Roll
    int toHitTarget = GetToHitRoll(attacker.wepSkil, defender.wepSkil);

    // Roll attacks
    for (int i = 0; i < totalAttacks; i++)
    {
        if (RollDice(toHitTarget)) successfulAttacks++;
    }

    richTextBox1.AppendText($"{attacker.troopName} made {successfulAttacks} successful attacks (needed {toHitTarget}'s).\n");

    // Calculate Wound Roll
    int woundTarget = (4 - ((attacker.stg + attacker.currentWeapon.stgBonus) - (defender.tuff + (defender.CurrentMount?.tuffBonus ?? 0))));

            woundTarget = Math.Max(2, Math.Min(6, woundTarget));
            for (int i = 0; i < successfulAttacks; i++)
    {
        if (RollDice(woundTarget)) successfulWounds++;
    }

    richTextBox1.AppendText($"{defender.troopName} suffered {successfulWounds} potential wounds (needed {woundTarget}'s).\n");

    // Apply Saves
    unsavedWounds = successfulWounds;
    for (int i = 0; i < successfulWounds; i++)
    {
        if (RollDice((defender.sav1 + (defender.CurrentMount?.armBonus ?? 0)) - (attacker.ap + attacker.currentWeapon.apBonus))) unsavedWounds--; //Calculate armor save to be save -AP of attacker and weapon bonus.
        }

    richTextBox1.AppendText($"{defender.troopName} has {unsavedWounds} unsaved wounds after saves.\n");

    return unsavedWounds;
}

        public static void initiativeOrder(Troop input1, Troop input2)
        {
            if (input1 == null || input2 == null)
            {
                return;
            }
            else if (input1.ini == input2.ini)
            {
                Troop simo1 = input1;
                Troop simo2 = input2;
                PerformSimoAttack(simo1, simo2);
            }
            else
            {
                Troop firstFighter = (input1.ini > input2.ini) ? input1 : input2;
                Troop secondFighter = (firstFighter == input1) ? input2 : input1;
                richTextBox1.Text = ($"You went ahead and pressed the button and now {firstFighter.troopName} gets to fight first\n");
                PerformAttack(firstFighter, secondFighter);
                
            }     
            richTextBox1.AppendText($"The battle is over, Go Home.");
        }

        public static void PerformSimoAttack(Troop simo1, Troop simo2)
{
    richTextBox1.Text = ($"{simo1.troopName} and {simo2.troopName} attack simultaneously!\n");

    int damageToSimo2 = ResolveAttacks(simo1, simo2);
    int damageToSimo1 = ResolveAttacks(simo2, simo1);
    richTextBox1.AppendText($"The {simo1.troopName} cause {damageToSimo2} unsaved wounds on {simo2.troopName}, and the {simo2.troopName} cause {damageToSimo1} unsaved wounds in return.");
            richTextBox1.AppendText($"That was pretty cool I guess?\n");
}

           
        
public static void PerformAttack(Troop firstFighter, Troop secondFighter)
{
    richTextBox1.AppendText($"{firstFighter.troopName} attacks {secondFighter.troopName}!\n");
    int damageDealt = ResolveAttacks(firstFighter, secondFighter);
    richTextBox1.AppendText($"After losing {damageDealt} wounds, the {secondFighter.troopName} strikes back!\n");
    secondFighter.frontage -= damageDealt / secondFighter.wounds;
    int returnDamage = ResolveAttacks(secondFighter, firstFighter);
}


        }

    }

