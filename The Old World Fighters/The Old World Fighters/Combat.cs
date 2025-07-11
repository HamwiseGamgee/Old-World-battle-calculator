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
        public class InitiativeRoster
        {
            public Troop? FighterInput { get; set; }     // Will hold a Troop object
            public Mount? MountInput { get; set; }       // Will hold a Mount object (if applicable)
            public int Initiative { get; set; }          // Initiative value for sorting

            // Constructor for a Troop
            public InitiativeRoster(Troop troop)
            {
                FighterInput = troop;
                Initiative = (troop.ini + troop.currentWeapon.iniBonus);  // 'ini' is the initiative property on Troop
            }

            // Constructor for a Mount
            public InitiativeRoster(Mount mount)
            {
                MountInput = mount;
                Initiative = mount.ini;  // 'ini' is the initiative property on Mount
            }
        }

        // Static method to build and return a sorted initiative list
        public static List<InitiativeRoster> GetInitiative(Troop input1, Troop input2)
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
                        Debug.WriteLine($"  Troop: {entry.FighterInput.troopName}");
                    else if (entry.MountInput != null)
                        Debug.WriteLine($"  Mount: {entry.MountInput.mountName}");
                }
            }

            return sortedRoster;
        }
    private static int TotalAttacks(Troop attacker, Troop defender)
    {

    int fullAttacks = 0;
    int supportingAttacks = 0;

    int remainingModels = attacker.ModelsInUnit - attacker.Casualties;
    int fightingRank;// TODO: Test this, It Might work.
    if (attacker.isCharging == false && attacker.battlePressers == true)
        { 
        fightingRank = Math.Max(Math.Min((attacker.frontage * 2) - attacker.Casualties, remainingModels), 0);
        }
    else
        {
        fightingRank = Math.Max(Math.Min(attacker.frontage - attacker.Casualties, remainingModels), 0);
        }
    for (int i = 0; i < fightingRank; i++)
    {
        fullAttacks += (attacker.att + attacker.currentWeapon.attBonus);
    }
    if ((attacker.fightInExtraRank == true || attacker.currentWeapon.affectsExtraRanks == true) && attacker.isCharging == false)
        {
            //Some great code.. TODO - Should frontage be used the way I use it?
            supportingAttacks = Math.Min(Math.Max(attacker.frontage - Math.Max(attacker.Casualties - attacker.frontage), 0), (remainingModels - attacker.frontage);
        }
        else
        {
            //No Spears Etc
            supportingAttacks = 0;
        }
    return fullAttacks + supportingAttacks;
    }
    private static int ResolveAttacks(Troop attacker, Troop defender)
        {
            int totalAttacks = TotalAttacks(attacker, defender);
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

            richTextBox1.AppendText($"{attacker.troopName} were armed with {attackter.currentWeapon.weaponName} and made {successfulAttacks} successful attacks (needed {toHitTarget}'s).\n");

            // Calculate Wound Roll
            int woundTarget = (4 - ((attacker.stg + attacker.currentWeapon.stgBonus) - (defender.tuff + (defender.CurrentMount?.tuffBonus ?? 0))));

            woundTarget = Math.Max(2, Math.Min(6, woundTarget));
            for (int i = 0; i < successfulAttacks; i++)
            {
                if (RollDice(woundTarget)) successfulWounds++;
            }

            richTextBox1.AppendText($"{defender.troopName} suffered {successfulWounds} potential wounds ({attacker.troopName} struck at strength {attacker.stg + attacker.currentWeapon.stgBonus} and needed {woundTarget}'s).\n");

            // Apply Saves
            unsavedWounds = successfulWounds;
            for (int i = 0; i < successfulWounds; i++)
            {
                if (RollDice((defender.sav1 + (defender.CurrentMount?.armBonus ?? 0)) - (attacker.ap + attacker.currentWeapon.apBonus))) unsavedWounds--; //Calculate armor save to be save -AP of attacker and weapon bonus.
            }

            richTextBox1.AppendText($"{defender.troopName} has {unsavedWounds} unsaved wounds after saves.\n");

            return unsavedWounds;
        }
        
        private static int MountedAttacks(Mount attacker, Troop defender)
        { 
            int totalAttacks = (Math.Min((attacker.Rider.frontage - attacker.Rider.Casualties), attacker.Rider.ModelsInUnit)) * attacker.att;
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

    richTextBox1.AppendText($"{attacker.mountName} made {successfulAttacks} successful attacks (needed {toHitTarget}'s).\n");

    // Calculate Wound Roll
    int woundTarget = (4 - ((attacker.stg) - (defender.tuff + (defender.CurrentMount?.tuffBonus ?? 0))));

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
        if (RollDice((defender.sav1 + (defender.CurrentMount?.armBonus ?? 0)) - attacker.ap)) unsavedWounds--; //Calculate armor save to be save -AP of attacker and weapon bonus.
    }

    richTextBox1.AppendText($"{defender.troopName} has {unsavedWounds} unsaved wounds after saves.\n");

    return unsavedWounds;
}



        public static void RevisedAttack(List<InitiativeRoster> initiativeOrder, Troop leftFighter, Troop rightFighter)
        {
            // Group entities by initiative value in descending order
            var groupedByInitiative = initiativeOrder
                .GroupBy(e => e.Initiative)
                .OrderByDescending(g => g.Key);

            foreach (var initiativeGroup in groupedByInitiative)
            {
                int initiative = initiativeGroup.Key;
                Debug.WriteLine($"Initiative {initiative}:");

                foreach (var entity in initiativeGroup)
                {
                    // Troop action
                    if (entity.FighterInput != null)
                    {
                        Troop attacker = entity.FighterInput;
                        Troop target = (attacker == leftFighter) ? rightFighter : leftFighter;

                        Debug.WriteLine($"  Troop: {attacker.troopName}");
                        Debug.WriteLine($"{attacker.troopName} Swing at {target.troopName}");

                        int floatingDamage = ResolveAttacks(attacker, target);
                        Debug.WriteLine($"{floatingDamage} unsaved wounds caused");

                        attacker.CombatScore += floatingDamage;
                        target.FloatingCasualties += (target.FloatingWounds + floatingDamage) / target.wounds;

                        Debug.WriteLine($"{target.troopName} took {(target.FloatingWounds + floatingDamage) / target.wounds} casualties. (They had {target.FloatingWounds} wounds left over from before.");
                        target.FloatingWounds = (target.FloatingWounds + floatingDamage) % target.wounds;
                    }
                    // Mount action
                    else if (entity.MountInput != null)
                    {
                        Mount attacker = entity.MountInput;
                        Troop mountOwner = (attacker == leftFighter.CurrentMount) ? leftFighter : rightFighter;
                        attacker.Rider = mountOwner;
                        Troop target = (mountOwner == leftFighter) ? rightFighter : leftFighter;

                        Debug.WriteLine($"  Mount: {attacker.mountName}");
                        Debug.WriteLine($"{attacker.mountName} Swing at {target.troopName}");

                        int floatingDamage = MountedAttacks(attacker, target);
                        Debug.WriteLine($"{floatingDamage} unsaved wounds caused by {attacker.mountName} while {attacker.Rider.troopName} sits around");

                        attacker.CombatScore += floatingDamage;
                        target.FloatingCasualties += (target.FloatingWounds + floatingDamage) / target.wounds;
                    }
                }

                // This happens once per initiative group
                Debug.WriteLine($"Initiative resolved for {initiative}.");

                leftFighter.Casualties += leftFighter.FloatingCasualties;
                leftFighter.FloatingCasualties = 0;
                rightFighter.Casualties += rightFighter.FloatingCasualties;
                rightFighter.FloatingCasualties = 0;
                leftFighter.ModelsInUnit -= leftFighter.Casualties;
                rightFighter.ModelsInUnit -= rightFighter.Casualties;
               
            }
        }

    public static int CombatBonusChecks(Troop accountants, baddies)
    {
        int totalBonus = 0;
        if (accountants.isCloseorder && (accountants.ModelsInUnit - accountants.Casualties) >= 10) totalBonus += 1;
        if ((accountants.UnitStrengthMultiplier * (accountants.ModelsInUnit - accountants.Casualties) > baddies.UnitStrengthMultiplier * (baddies.ModelsInUnit - baddies.Casualties)) && accountants.BattlePressers == true) totalBonus +=1;
    }
        public static void ResolveCombat(Troop leftFighter, Troop rightFighter)
        {
            leftFighter.RankBonus = Math.Min(((leftFighter.ModelsInUnit / leftFighter.frontage)
                + (leftFighter.ModelsInUnit % leftFighter.frontage >= leftFighter.filesForRankBonus ? 1 : 0) - 1), leftFighter.maxRankBonus);
            rightFighter.RankBonus = Math.Min(((rightFighter.ModelsInUnit / rightFighter.frontage) + (rightFighter.ModelsInUnit % rightFighter.frontage
                 >= rightFighter.filesForRankBonus ? 1 : 0) - 1), rightFighter.maxRankBonus);


            leftFighter.CombatScore = leftFighter.CombatScore + leftFighter.RankBonus + CombatBonusChecks(leftFighter, rightFighter);
            rightFighter.CombatScore = rightFighter.CombatScore + rightFighter.RankBonus + CombatBonusChecks(rightFighter, leftFighter);
            Debug.WriteLine($"{leftFighter.troopName} achieved a combat score of {leftFighter.CombatScore} and {rightFighter.troopName} had {rightFighter.CombatScore}");

            var Troop winner = leftFighter.CombatScore > rightFighter.CombatScore ? leftFighter | rightFighter;
            var Troop loser = leftFighter.CombatScore < rightFighter.CombatScore ? leftFighter | rightFighter;

            if (leftFighter.CombatScore == rightFighter.CombatScore)
            {
                richTextBox1.AppendText($"The {leftFighter.troopName} and the {rightFighter.troopName} fought to a standstill. It's a draw!");
            }
            else
            {
                margin = winner.CombatScore - loser.CombatScore
                richTextBox1.AppendText($"The {winner.troopName} emerges victorious over the {loser.troopName} by a margin of {margin}. \n
                Did the {winner.}'s hope that leadership {loser.lead} comes through./n";
                Breaktest(loser, margin);
                
            }
            //Reset floating variables for the next combat
            leftFighter.CombatScore = 0;
            rightFighter.CombatScore = 0;
            leftFighter.FloatingWounds = 0;  // This Should be off for protracted combats
            rightFighter.FloatingWounds = 0;// This Should be off for protracted combats
            Debug.WriteLine("ScoreKeeping Reset Occurred Floating Wounds lost.");

        private static void BreakTest(Troop loser, int margin)
            {
                Debug.WriteLine($"Break test for {loser.troopName} may or may not have happened");
                int roll = rng.Next(1, 7) + rng.Next(1, 7);
                leadBonus = loser.isWarband ? loser.RankBonus : 0;
                
                if (roll > (loser.lead + leadBonus) && loser.stubborn > 0)
                {
                    richTextBox1.AppendText($"{loser.troopName} Breaks and flees from combat.");
                }
                else
                {
                    Debug.WriteLine($"Whatever, dude");
                }
            }


        }

    }
}

