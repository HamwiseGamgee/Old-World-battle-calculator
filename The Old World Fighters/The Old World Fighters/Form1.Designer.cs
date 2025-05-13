namespace The_Old_World_Fighters
{
    partial class Form1
    {
        private Label weapon1Label;
private Label weapon2Label;
private ComboBox weapon1ComboBox;
private ComboBox weapon2ComboBox;
private Button equipWeapon1Button;
private Button equipWeapon2Button;

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            toolStrip1 = new ToolStrip();
            richTextBox1 = new RichTextBox();
            faction1ComboBox = new ComboBox();
            troop1ComboBox = new ComboBox();
            faction2ComboBox = new ComboBox();
            troop2ComboBox = new ComboBox();
            troop1Frontage = new NumericUpDown();
            troop2Frontage = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)troop1Frontage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)troop2Frontage).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(355, 217);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Attack";
            button2.UseVisualStyleBackColor = true;
            button2.Click += attackButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(573, 65);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 2;
            label1.Text = "Second Troop";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 65);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "First Troop";
            // 
            // toolStrip1
            // 
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(126, 252);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(568, 171);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // faction1ComboBox
            // 
            faction1ComboBox.FormattingEnabled = true;
            faction1ComboBox.Location = new Point(82, 105);
            faction1ComboBox.Name = "faction1ComboBox";
            faction1ComboBox.Size = new Size(121, 23);
            faction1ComboBox.TabIndex = 6;
            faction1ComboBox.SelectedIndexChanged += faction1ComboBox_SelectedIndexChanged;
            // 
            // troop1ComboBox
            // 
            troop1ComboBox.FormattingEnabled = true;
            troop1ComboBox.Location = new Point(82, 161);
            troop1ComboBox.Name = "troop1ComboBox";
            troop1ComboBox.Size = new Size(121, 23);
            troop1ComboBox.TabIndex = 7;
            troop1ComboBox.SelectedIndexChanged += troop1ComboBox_SelectedIndexChanged;
            // 
            // faction2ComboBox
            // 
            faction2ComboBox.FormattingEnabled = true;
            faction2ComboBox.Location = new Point(573, 105);
            faction2ComboBox.Name = "faction2ComboBox";
            faction2ComboBox.Size = new Size(121, 23);
            faction2ComboBox.TabIndex = 8;
            faction2ComboBox.SelectedIndexChanged += faction2ComboBox_SelectedIndexChanged;
            // 
            // troop2ComboBox
            // 
            troop2ComboBox.FormattingEnabled = true;
            troop2ComboBox.Location = new Point(573, 161);
            troop2ComboBox.Name = "troop2ComboBox";
            troop2ComboBox.Size = new Size(121, 23);
            troop2ComboBox.TabIndex = 9;
            troop2ComboBox.SelectedIndexChanged += troop2ComboBox_SelectedIndexChanged;
            // 
            // troop1Frontage
            // 
            troop1Frontage.Location = new Point(83, 217);
            troop1Frontage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            troop1Frontage.Name = "troop1Frontage";
            troop1Frontage.Size = new Size(120, 23);
            troop1Frontage.TabIndex = 10;
            troop1Frontage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            troop1Frontage.ValueChanged += troop1Frontage_ValueChanged;
            // 
            // troop2Frontage
            // 
            troop2Frontage.Location = new Point(574, 217);
            troop2Frontage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            troop2Frontage.Name = "troop2Frontage";
            troop2Frontage.Size = new Size(120, 23);
            troop2Frontage.TabIndex = 11;
            troop2Frontage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            troop2Frontage.ValueChanged += troop2Frontage_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 105);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 12;
            label3.Text = "Faction";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(521, 105);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 13;
            label4.Text = "Faction";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 161);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 14;
            label5.Text = "Unit";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(538, 161);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 15;
            label6.Text = "Unit";
// --- Weapon 1 UI Elements ---
weapon1Label = new Label
{
    AutoSize = true,
    Location = new Point(82, 250),
    Name = "weapon1Label",
    Size = new Size(110, 15),
    TabIndex = 16,
    Text = "Equipped Weapon: -"
};

weapon1ComboBox = new ComboBox
{
    FormattingEnabled = true,
    Location = new Point(82, 270),
    Name = "weapon1ComboBox",
    Size = new Size(121, 23),
    TabIndex = 17
};

equipWeapon1Button = new Button
{
    Location = new Point(82, 300),
    Name = "equipWeapon1Button",
    Size = new Size(121, 23),
    TabIndex = 18,
    Text = "Equip Weapon",
    UseVisualStyleBackColor = true
};
equipWeapon1Button.Click += equipWeapon1Button_Click;

// --- Weapon 2 UI Elements ---
weapon2Label = new Label
{
    AutoSize = true,
    Location = new Point(573, 250),
    Name = "weapon2Label",
    Size = new Size(110, 15),
    TabIndex = 19,
    Text = "Equipped Weapon: -"
};

weapon2ComboBox = new ComboBox
{
    FormattingEnabled = true,
    Location = new Point(573, 270),
    Name = "weapon2ComboBox",
    Size = new Size(121, 23),
    TabIndex = 20
};

equipWeapon2Button = new Button
{
    Location = new Point(573, 300),
    Name = "equipWeapon2Button",
    Size = new Size(121, 23),
    TabIndex = 21,
    Text = "Equip Weapon",
    UseVisualStyleBackColor = true
};
equipWeapon2Button.Click += equipWeapon2Button_Click;


            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(troop2Frontage);
            Controls.Add(troop1Frontage);
            Controls.Add(troop2ComboBox);
            Controls.Add(faction2ComboBox);
            Controls.Add(troop1ComboBox);
            Controls.Add(faction1ComboBox);
            Controls.Add(richTextBox1);
            Controls.Add(toolStrip1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(weapon1Label);
            Controls.Add(weapon2Label);
            Controls.Add(weapon1ComboBox);
            Controls.Add(weapon2ComboBox);
            Controls.Add(equipWeapon1Button);
            Controls.Add(equipWeapon2Button);
            Name = "Form1";
            Text = "The Old World Fighters";
            ((System.ComponentModel.ISupportInitialize)troop1Frontage).EndInit();
            ((System.ComponentModel.ISupportInitialize)troop2Frontage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Label label1;
        private Label label2;
        private ToolStrip toolStrip1;
        private RichTextBox richTextBox1;
        private ComboBox faction1ComboBox;
        private ComboBox troop1ComboBox;
        private ComboBox faction2ComboBox;
        private ComboBox troop2ComboBox;
        private NumericUpDown troop1Frontage;
        private NumericUpDown troop2Frontage;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
