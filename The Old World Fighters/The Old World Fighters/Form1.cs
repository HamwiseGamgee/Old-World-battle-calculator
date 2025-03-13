using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        public Form1()
        {
            InitializeComponent();
            Instance = this;  // Set the static reference when the form is initialized
            LoadFactions();
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
                                    $"WS: {selectedTroop1.wepSkil}, STG: {selectedTroop1.stg}, TOU: {selectedTroop1.tuff}, " +
                                    $"INI: {selectedTroop1.ini}, ATT: {selectedTroop1.att}, SAV1: {selectedTroop1.sav1}";

                // Set the frontage input to the selected troop's frontage value
                troop1Frontage.Value = selectedTroop1.frontage;
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
                                    $"WS: {selectedTroop2.wepSkil}, STG: {selectedTroop2.stg}, TOU: {selectedTroop2.tuff}, " +
                                    $"INI: {selectedTroop2.ini}, ATT: {selectedTroop2.att}, SAV1: {selectedTroop2.sav1}";

                // Set the frontage input to the selected troop's frontage value
                troop2Frontage.Value = selectedTroop2.frontage;
            }
        }

        // Handles the attack when the button is clicked
        private void attackButton_Click(object sender, EventArgs e)
        {
            if (selectedTroop1 != null && selectedTroop2 != null)
            {
                Combat.initiativeOrder(selectedTroop1, selectedTroop2);
              //  Combat.PerformAttack(selectedTroop1, selectedTroop2);
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


        // Handles troop selection and displays its details
        private void selectTroopButton_Click(object sender, EventArgs e)
        {
            if (troop1ComboBox.SelectedItem == null)
            {
                richTextBox1.Text = "No troop selected.\n";
                return;
            }

            string selectedTroop1Name = troop1ComboBox.SelectedItem.ToString();

            // Fetch troop from repository (Ensure Troops list is properly accessible)
            Troop selectedTroop = TroopRepository.Troops.Find(t => t.troopName == selectedTroop1Name);

            if (selectedTroop != null)
            {
                richTextBox1.Text = $"Selected: {selectedTroop.troopName} (Faction: {selectedTroop.faction})\n" +
                                    $"WS: {selectedTroop.wepSkil}, STG: {selectedTroop.stg}, TOU: {selectedTroop.tuff}\n, " +
                                    $"INI: {selectedTroop.ini}, ATT: {selectedTroop.att}, SAV1: {selectedTroop.sav1}\n";
            }
            else
            {
                richTextBox1.Text = "Error: Troop not found.\n";
            }
        }


    }
}

