using System;
using System.Collections.Generic;
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

        public static void initiativeOrder(Troop input1, Troop input2)
        {
            if (input1 == null || input2 == null)
            {
                return;
            }
            else
            {
                Troop firstFighter = (input1.ini > input2.ini) ? input1 : input2;
                Troop secondFighter = (firstFighter == input1) ? input2 : input1;
                richTextBox1.Text = ($"You went ahead and pressed the button and now {firstFighter.troopName} gets to fight first\n");
                PerformAttack(firstFighter, secondFighter);
            }
        }

        public static void PerformAttack(Troop firstFighter, Troop secondFighter)
        {
            // Calculate the total number of attacks
            int totalAttacks = firstFighter.frontage * firstFighter.att;
            int successfulAttacks = 0;
            int successfulWounds = 0;
            int totalDefenderSaves = 0;

            // Display the number of attacks in the output
            richTextBox1.AppendText($"{firstFighter.troopName} attacks {secondFighter.troopName} with {totalAttacks} attacks.\n");

            // Define the target number for hitting (based on Weapon Skill or a similar attribute)
            int targetNumber = (firstFighter.wepSkil > secondFighter.wepSkil) ? 3 : 4;

            // Perform the attacks
            for (int i = 0; i < totalAttacks; i++)
            {
                bool attackHit = AttackRoll(firstFighter, targetNumber);  // Roll for each attack and check if it hits
                if (attackHit)
                {
                    successfulAttacks++;
                }
            }

            // Output the number of successful attacks
            richTextBox1.AppendText($"{firstFighter.troopName} made {successfulAttacks} successful attacks, they were looking for a {targetNumber}.\n");

            // My own attempt at S vs T
            targetNumber = 4 - (firstFighter.stg - secondFighter.tuff);
            targetNumber = Math.Max(2, Math.Min(6, targetNumber));
            for (int i = 0; i < successfulAttacks; i++)
            {
                bool attackWound = WoundRoll(firstFighter, targetNumber);
                if (attackWound)
                {
                    successfulWounds++;
                }      
            }  
            // Output for visibility
               richTextBox1.AppendText($"{secondFighter.troopName} were wounded {successfulWounds} time(s), on rolls of {targetNumber} or more.\n");
        }
            // Roll to check if the attack hits based on the target number (e.g., Weapon Skill)
            private static bool AttackRoll(Troop attacker, int targetNumber)
            {
             
                int roll = rand.Next(1, 7);  // Simulate a dice roll between 1 and 6
                return roll >= targetNumber;  // Success if the roll is greater than or equal to the target number
            }

            // Simplified wound roll (e.g., based on Strength vs. Toughness)
            private static bool WoundRoll(Troop attacker, int woundTarget)
            {
             
                int roll = rand.Next(1, 7);  // Simulate a dice roll between 1 and 6
                return roll >= woundTarget;  // success if it meets current targetnumber
            }

            // Simplified save roll (e.g., based on armor or saves)
            private static bool SaveRoll(Troop defender)
            {
              
                int roll = rand.Next(1, 7);  // Simulate a dice roll between 1 and 6
                return roll >= defender.sav1;  // Save on a roll equal or below the Save value (simplified)
            }
        }

    }

