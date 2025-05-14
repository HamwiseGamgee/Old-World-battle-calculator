using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Windows.Forms;
using The_Old_World_Fighters;
using Newtonsoft.Json;
using System.Diagnostics;

namespace The_Old_World_Fighters
{
    public partial class Form1 : Form
    {

        public static Form1 Instance { get; private set; }
        public RichTextBox RichTextBoxOutput
        {
            get { return richTextBox1; }
        }
        public Troop attacker = null;
        public Troop defender = null;
        public Troop selectedTroop = null;
        public Form1()
        {
            InitializeComponent();
            TroopRepository.LoadWeapons();
            TroopRepository.LoadMounts();
            TroopRepository.LoadTroops();
            Instance = this;  // Set the static reference when the form is initialized
            LoadFactions();
            LoadLeftWeaponBox();
            LoadRightWeaponBox();
        }

        // Load all factions into the first dropdown box
        private void LoadFactions()
        {
            faction1ComboBox.Items.Clear();
            faction2ComboBox.Items.Clear();
            // Ensure GetFactions() returns a valid list before adding items
            List<string> factions = TroopRepository.GetFactions();
            if (factions != null && factions.Count > 0)
            {
                faction1ComboBox.Items.AddRange(factions.ToArray());
                faction2ComboBox.Items.AddRange(factions.ToArray());
            }
        }

        private void LoadLeftWeaponBox()
        {
            leftTroopWeaponBox.Items.Clear();
            List<string> weapons = TroopRepository.FillWeapons();
            leftTroopWeaponBox.Items.AddRange(weapons.ToArray());
        }

        private void LoadRightWeaponBox()
        {
            rightTroopWeaponBox.Items.Clear();
            List<string> weapons = TroopRepository.FillWeapons();
            rightTroopWeaponBox.Items.AddRange(weapons.ToArray());
        }

        // Variables to hold the currently selected troops
        private Troop selectedTroop1 = null;
        private Troop selectedTroop2 = null;
        // Update Troop 1 frontage when the numeric up down value changes
        private void troop1Frontage_ValueChanged(object sender, EventArgs e)
        {
            if (selectedTroop1 != null)
            {
                selectedTroop1.frontage = (int)troop1Frontage.Value;
            }
        }

        // Update Troop 2 frontage when the numeric up down value changes
        private void troop2Frontage_ValueChanged(object sender, EventArgs e)
        {
            if (selectedTroop2 != null)
            {
                selectedTroop2.frontage = (int)troop2Frontage.Value;
            }
        }
        private void leftTroopModelCount_ValueChanged(object sender, EventArgs e)
        {
            if (selectedTroop1 != null)
            {
                selectedTroop1.ModelsInUnit = (int)leftTroopModelCount.Value;
            }
        }
        private void rightTroopModelCount_ValueChanged(object sender, EventArgs e)
        {
            if (selectedTroop2 != null)
            {
                selectedTroop2.ModelsInUnit = (int)rightTroopModelCount.Value;
            }
        }
        // Event handler for troop 1 combo box
        private void troop1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (troop1ComboBox.SelectedItem == null)
            {
                richTextBox1.Text = "No troop selected for Troop 1.";
                return;
            }

            // Get the name of the selected troop
            string selectedTroopName1 = troop1ComboBox.SelectedItem.ToString();

            // Find the corresponding troop from your TroopRepository
            selectedTroop1 = TroopRepository.Troops.Find(t => t.troopName == selectedTroopName1);

            if (selectedTroop1 != null)
            {
                // Update attacker var with selected troop
                attacker = selectedTroop1;
                // Update rich text box with troop info
                richTextBox1.Text = $"Selected Troop 1: {selectedTroop1.troopName} (Faction: {selectedTroop1.faction})\n" +
                                    $"WeaponSkill: {selectedTroop1.wepSkil}, Strength: {selectedTroop1.stg}, Toughness: {selectedTroop1.tuff}, " +
                                    $"Initiative: {selectedTroop1.ini}, Attacks: {selectedTroop1.att}, Armor Save: {selectedTroop1.sav1}+\n" +
                                    $"These cool cats are carrying {selectedTroop1.currentWeapon.weaponName}'s. They can't wait to fight.";

                // Set the frontage input to the selected troop's frontage value
                troop1Frontage.Value = selectedTroop1.frontage;
                leftTroopModelCount.Value = selectedTroop1.ModelsInUnit;
            }
        }

        // Event handler for troop 2 combo box
        private void troop2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (troop2ComboBox.SelectedItem == null)
            {
                richTextBox1.Text = "No troop selected for Troop 2.";
                return;
            }

            // Get the name of the selected troop
            string selectedTroopName2 = troop2ComboBox.SelectedItem.ToString();

            // Find the corresponding troop from your TroopRepository
            selectedTroop2 = TroopRepository.Troops.Find(t => t.troopName == selectedTroopName2);

            if (selectedTroop2 != null)
            {
                // Update defender var with selected troop
                defender = selectedTroop2;
                // Update rich text box with troop info
                richTextBox1.Text = $"Selected Troop 2: {selectedTroop2.troopName} (Faction: {selectedTroop2.faction})\n" +
                                    $"WeaponSkill: {selectedTroop2.wepSkil}, Strength: {selectedTroop2.stg}, Toughness: {selectedTroop2.tuff}, " +
                                    $"Initiative: {selectedTroop2.ini}, Attacks: {selectedTroop2.att}, Armor Save: {selectedTroop2.sav1}+\n" +
                                    $"These cool cats are carrying {selectedTroop2.currentWeapon.weaponName}'s. They can't wait to fight.";

                // Set the frontage input to the selected troop's frontage value
                troop2Frontage.Value = selectedTroop2.frontage;
                rightTroopModelCount.Value = selectedTroop2.ModelsInUnit;
            }
        }

        // Handles the attack when the button is clicked
        private void attackButton_Click(object sender, EventArgs e)
        {
            if (selectedTroop1 != null && selectedTroop2 != null)
            {

                List<Combat.InitiativeRoster> initiativeOrder = Combat.GetInitiative(selectedTroop1, selectedTroop2);
                Combat.RevisedAttack(initiativeOrder, selectedTroop1, selectedTroop2);
                Combat.ResolveCombat(selectedTroop1, selectedTroop2);
                leftTroopModelCount.Value = selectedTroop1.ModelsInUnit;
                rightTroopModelCount.Value = selectedTroop2.ModelsInUnit;
            }
            else
            {
                richTextBox1.Text = "Please select both troops before attacking.\n";
            }
        }

        // When a faction is selected, update the troop dropdown
        private void faction1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (faction1ComboBox.SelectedItem == null)
            {
                return; // Prevent errors if nothing is selected
            }

            string selectedFaction = faction1ComboBox.SelectedItem.ToString();

            // Clear previous troops and load new ones
            troop1ComboBox.Items.Clear();
            List<Troop> troops = TroopRepository.GetTroopsByFaction(selectedFaction);

            if (troops != null && troops.Count > 0)
            {
                foreach (var troop in troops)
                {
                    troop1ComboBox.Items.Add(troop.troopName);
                }
            }
        }

        // When a faction is selected, update the troop dropdown for faction 2
        private void faction2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (faction2ComboBox.SelectedItem == null)
            {
                return; // Prevent errors if nothing is selected
            }

            string selectedFaction = faction2ComboBox.SelectedItem.ToString();
            Console.WriteLine($"Faction 2 Selected: {selectedFaction}"); // Debugging line

            // Clear previous troops and load new ones
            troop2ComboBox.Items.Clear();
            List<Troop> troops = TroopRepository.GetTroopsByFaction(selectedFaction);

            if (troops != null && troops.Count > 0)
            {
                foreach (var troop in troops)
                {
                    troop2ComboBox.Items.Add(troop.troopName);
                }
            }
        }

        private void equipRightUnit_Click(object sender, EventArgs e)
        {
            if (selectedTroop2 != null)
            {
                string selectedWeaponName = rightTroopWeaponBox.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedWeaponName))
                {
                    MessageBox.Show("Please select a weapon.");
                    return;
                }
                var weapon = TroopRepository.Weapons.FirstOrDefault(w => w.weaponName == selectedWeaponName);
                if (weapon == null)
                {
                    MessageBox.Show($"Weapon '{selectedWeaponName}' not found in the repository.");
                    return;
                }
                // Change weapon using its ID
                if (selectedTroop2 != null)
                {
                    selectedTroop2.ChangeWeapon(weapon.wepId);
                    Debug.WriteLine($"Weapon changed to {weapon.weaponName} for {selectedTroop2.troopName}.");
                }
            }
        }
        private void equipLeftUnit_Click(object sender, EventArgs e)
        {
            if (selectedTroop1 != null)
            {
                // Get selected weapon name from combo box
                string selectedWeaponName = leftTroopWeaponBox.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedWeaponName))
                {
                    MessageBox.Show("Please select a weapon.");
                    return;
                }

                // Find weapon object by name
                var weapon = TroopRepository.Weapons.FirstOrDefault(w => w.weaponName == selectedWeaponName);
                if (weapon == null)
                {
                    MessageBox.Show($"Weapon '{selectedWeaponName}' not found in the repository.");
                    return;
                }

                // Change weapon using its ID
                if (selectedTroop1 != null)
                {
                    selectedTroop1.ChangeWeapon(weapon.wepId);
                    Debug.WriteLine($"Weapon changed to {weapon.weaponName} for {selectedTroop1.troopName}.");
                }
            }
        }
        private void leftTroopWeaponBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedTroop1 != null && leftTroopWeaponBox.SelectedItem != null)
            {

            }
            else
            {
                return;
            }
        }
        private void rightTroopWeaponBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedTroop2 != null && rightTroopWeaponBox.SelectedItem != null)
            {
            }
            else
            {
                return;
            }
        }
    }
}

