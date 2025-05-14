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
            weapon1Label = new Label();
            weapon1ComboBox = new ComboBox();
            equipWeapon1Button = new Button();
            weapon2Label = new Label();
            weapon2ComboBox = new ComboBox();
            equipWeapon2Button = new Button();
            labelWeapon1 = new Label();
            labelWeapon2 = new Label();
            labelLeftUnitFrontage = new Label();
            labelRightUnitFrontage = new Label();
            leftTroopModelCount = new NumericUpDown();
            rightTroopModelCount = new NumericUpDown();
            labelLeftUnitCount = new Label();
            labelRightUnitCount = new Label();
            labelLeftTroopWeapon = new Label();
            labelRightTroopWeapon = new Label();
            leftTroopWeaponBox = new ComboBox();
            rightTroopWeaponBox = new ComboBox();
            leftEquipButton = new Button();
            rightEquipButton = new Button();
            ((System.ComponentModel.ISupportInitialize)troop1Frontage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)troop2Frontage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftTroopModelCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightTroopModelCount).BeginInit();
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
            toolStrip1.Size = new Size(850, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(126, 391);
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
            troop1Frontage.Location = new Point(42, 312);
            troop1Frontage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            troop1Frontage.Name = "troop1Frontage";
            troop1Frontage.Size = new Size(39, 23);
            troop1Frontage.TabIndex = 10;
            troop1Frontage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            troop1Frontage.ValueChanged += troop1Frontage_ValueChanged;
            // 
            // troop2Frontage
            // 
            troop2Frontage.Location = new Point(528, 312);
            troop2Frontage.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            troop2Frontage.Name = "troop2Frontage";
            troop2Frontage.Size = new Size(39, 23);
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
            // 
            // weapon1Label
            // 
            weapon1Label.Location = new Point(0, 0);
            weapon1Label.Name = "weapon1Label";
            weapon1Label.Size = new Size(100, 23);
            weapon1Label.TabIndex = 16;
            // 
            // weapon1ComboBox
            // 
            weapon1ComboBox.Location = new Point(0, 0);
            weapon1ComboBox.Name = "weapon1ComboBox";
            weapon1ComboBox.Size = new Size(121, 23);
            weapon1ComboBox.TabIndex = 18;
            // 
            // equipWeapon1Button
            // 
            equipWeapon1Button.Location = new Point(0, 0);
            equipWeapon1Button.Name = "equipWeapon1Button";
            equipWeapon1Button.Size = new Size(75, 23);
            equipWeapon1Button.TabIndex = 20;
            // 
            // weapon2Label
            // 
            weapon2Label.Location = new Point(0, 0);
            weapon2Label.Name = "weapon2Label";
            weapon2Label.Size = new Size(100, 23);
            weapon2Label.TabIndex = 17;
            // 
            // weapon2ComboBox
            // 
            weapon2ComboBox.Location = new Point(0, 0);
            weapon2ComboBox.Name = "weapon2ComboBox";
            weapon2ComboBox.Size = new Size(121, 23);
            weapon2ComboBox.TabIndex = 19;
            // 
            // equipWeapon2Button
            // 
            equipWeapon2Button.Location = new Point(0, 0);
            equipWeapon2Button.Name = "equipWeapon2Button";
            equipWeapon2Button.Size = new Size(75, 23);
            equipWeapon2Button.TabIndex = 21;
            // 
            // labelWeapon1
            // 
            labelWeapon1.AutoSize = true;
            labelWeapon1.Location = new Point(30, 217);
            labelWeapon1.Name = "labelWeapon1";
            labelWeapon1.Size = new Size(51, 15);
            labelWeapon1.TabIndex = 22;
            labelWeapon1.Text = "Weapon";
            // 
            // labelWeapon2
            // 
            labelWeapon2.AutoSize = true;
            labelWeapon2.Location = new Point(516, 217);
            labelWeapon2.Name = "labelWeapon2";
            labelWeapon2.Size = new Size(51, 15);
            labelWeapon2.TabIndex = 23;
            labelWeapon2.Text = "Weapon";
            // 
            // labelLeftUnitFrontage
            // 
            labelLeftUnitFrontage.AutoSize = true;
            labelLeftUnitFrontage.Location = new Point(30, 338);
            labelLeftUnitFrontage.Name = "labelLeftUnitFrontage";
            labelLeftUnitFrontage.Size = new Size(54, 15);
            labelLeftUnitFrontage.TabIndex = 24;
            labelLeftUnitFrontage.Text = "Frontage";
            // 
            // labelRightUnitFrontage
            // 
            labelRightUnitFrontage.AutoSize = true;
            labelRightUnitFrontage.ImageAlign = ContentAlignment.TopCenter;
            labelRightUnitFrontage.Location = new Point(513, 338);
            labelRightUnitFrontage.Name = "labelRightUnitFrontage";
            labelRightUnitFrontage.Size = new Size(54, 15);
            labelRightUnitFrontage.TabIndex = 25;
            labelRightUnitFrontage.Text = "Frontage";
            // 
            // leftTroopModelCount
            // 
            leftTroopModelCount.Location = new Point(149, 312);
            leftTroopModelCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            leftTroopModelCount.Name = "leftTroopModelCount";
            leftTroopModelCount.Size = new Size(39, 23);
            leftTroopModelCount.TabIndex = 26;
            leftTroopModelCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            leftTroopModelCount.ValueChanged += leftTroopModelCount_ValueChanged;
            // 
            // rightTroopModelCount
            // 
            rightTroopModelCount.Location = new Point(655, 312);
            rightTroopModelCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            rightTroopModelCount.Name = "rightTroopModelCount";
            rightTroopModelCount.Size = new Size(39, 23);
            rightTroopModelCount.TabIndex = 27;
            rightTroopModelCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            rightTroopModelCount.ValueChanged += rightTroopModelCount_ValueChanged;
            // 
            // labelLeftUnitCount
            // 
            labelLeftUnitCount.AutoSize = true;
            labelLeftUnitCount.Location = new Point(142, 338);
            labelLeftUnitCount.Name = "labelLeftUnitCount";
            labelLeftUnitCount.Size = new Size(46, 15);
            labelLeftUnitCount.TabIndex = 28;
            labelLeftUnitCount.Text = "Models";
            // 
            // labelRightUnitCount
            // 
            labelRightUnitCount.AutoSize = true;
            labelRightUnitCount.Location = new Point(648, 338);
            labelRightUnitCount.Name = "labelRightUnitCount";
            labelRightUnitCount.Size = new Size(46, 15);
            labelRightUnitCount.TabIndex = 29;
            labelRightUnitCount.Text = "Models";
            // 
            // labelLeftTroopWeapon
            // 
            labelLeftTroopWeapon.AutoSize = true;
            labelLeftTroopWeapon.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelLeftTroopWeapon.ImageAlign = ContentAlignment.TopCenter;
            labelLeftTroopWeapon.Location = new Point(87, 212);
            labelLeftTroopWeapon.Name = "labelLeftTroopWeapon";
            labelLeftTroopWeapon.Size = new Size(40, 20);
            labelLeftTroopWeapon.TabIndex = 30;
            labelLeftTroopWeapon.Text = "none";
            // 
            // labelRightTroopWeapon
            // 
            labelRightTroopWeapon.AutoSize = true;
            labelRightTroopWeapon.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelRightTroopWeapon.ImageAlign = ContentAlignment.TopCenter;
            labelRightTroopWeapon.Location = new Point(573, 212);
            labelRightTroopWeapon.Name = "labelRightTroopWeapon";
            labelRightTroopWeapon.Size = new Size(40, 20);
            labelRightTroopWeapon.TabIndex = 31;
            labelRightTroopWeapon.Text = "none";
            // 
            // leftTroopWeaponBox
            // 
            leftTroopWeaponBox.FormattingEnabled = true;
            leftTroopWeaponBox.Location = new Point(42, 235);
            leftTroopWeaponBox.Name = "leftTroopWeaponBox";
            leftTroopWeaponBox.Size = new Size(121, 23);
            leftTroopWeaponBox.TabIndex = 32;
            leftTroopWeaponBox.SelectedIndexChanged += leftTroopWeaponBox_SelectedIndexChanged;
            // 
            // rightTroopWeaponBox
            // 
            rightTroopWeaponBox.FormattingEnabled = true;
            rightTroopWeaponBox.Location = new Point(538, 235);
            rightTroopWeaponBox.Name = "rightTroopWeaponBox";
            rightTroopWeaponBox.Size = new Size(121, 23);
            rightTroopWeaponBox.TabIndex = 33;
            rightTroopWeaponBox.SelectedIndexChanged += rightTroopWeaponBox_SelectedIndexChanged;
            // 
            // leftEquipButton
            // 
            leftEquipButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftEquipButton.Location = new Point(169, 217);
            leftEquipButton.Name = "leftEquipButton";
            leftEquipButton.Size = new Size(46, 41);
            leftEquipButton.TabIndex = 34;
            leftEquipButton.Text = "Equip";
            leftEquipButton.UseVisualStyleBackColor = true;
            leftEquipButton.Click += equipLeftUnit_Click;
            // 
            // rightEquipButton
            // 
            rightEquipButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightEquipButton.Location = new Point(665, 217);
            rightEquipButton.Name = "rightEquipButton";
            rightEquipButton.Size = new Size(46, 41);
            rightEquipButton.TabIndex = 35;
            rightEquipButton.Text = "Equip";
            rightEquipButton.UseVisualStyleBackColor = true;
            rightEquipButton.Click += equipRightUnit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 616);
            Controls.Add(rightEquipButton);
            Controls.Add(leftEquipButton);
            Controls.Add(rightTroopWeaponBox);
            Controls.Add(leftTroopWeaponBox);
            Controls.Add(labelRightTroopWeapon);
            Controls.Add(labelLeftTroopWeapon);
            Controls.Add(labelRightUnitCount);
            Controls.Add(labelLeftUnitCount);
            Controls.Add(rightTroopModelCount);
            Controls.Add(leftTroopModelCount);
            Controls.Add(labelRightUnitFrontage);
            Controls.Add(labelLeftUnitFrontage);
            Controls.Add(labelWeapon2);
            Controls.Add(labelWeapon1);
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
            ((System.ComponentModel.ISupportInitialize)leftTroopModelCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightTroopModelCount).EndInit();
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
        private Label labelWeapon1;
        private Label labelWeapon2;
        private Label labelLeftUnitFrontage;
        private Label labelRightUnitFrontage;
        public NumericUpDown leftTroopModelCount;
        public NumericUpDown rightTroopModelCount;
        private Label labelLeftUnitCount;
        private Label labelRightUnitCount;
        private Label labelLeftTroopWeapon;
        private Label labelRightTroopWeapon;
        private ComboBox leftTroopWeaponBox;
        private ComboBox rightTroopWeaponBox;
        private Button leftEquipButton;
        private Button rightEquipButton;
    }
}
