namespace AcsViewer
{
    partial class CreatureViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.thingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UIStrategyAlignment = new System.Windows.Forms.TextBox();
            this.UIStrategyAggression = new System.Windows.Forms.TextBox();
            this.UIStrategyBrave = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.UIMimicPowers = new System.Windows.Forms.CheckBox();
            this.UIReadiedArmor = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.UIReadiedWeapon = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.UISpecialDefense = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.UISpeed = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.UIWealth = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.UIParrySkill = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.UIDodgeSkill = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.UIArmorSkill = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.UISize = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.UIPower = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.UILifeForce = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.UIMeleeSkill = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UIMissileSkill = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UIDexterity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UIStrength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.UIWisdom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UIConstitution = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UIClass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UIName = new System.Windows.Forms.TextBox();
            this.UINameLabel = new System.Windows.Forms.Label();
            this.UIPicture = new System.Windows.Forms.PictureBox();
            this.UIChanceLabel = new System.Windows.Forms.Label();
            this.UIPercentChance = new System.Windows.Forms.TextBox();
            this.UITerrain = new System.Windows.Forms.TextBox();
            this.UITerrainLabel = new System.Windows.Forms.Label();
            this.UIPossessions = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.thingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // thingBindingSource
            // 
            this.thingBindingSource.DataSource = typeof(AcsLib.Creature);
            this.thingBindingSource.CurrentItemChanged += new System.EventHandler(this.thingBindingSource_CurrentItemChanged);
            // 
            // UIStrategyAlignment
            // 
            this.UIStrategyAlignment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "StrategyAlignmentName", true));
            this.UIStrategyAlignment.Location = new System.Drawing.Point(326, 332);
            this.UIStrategyAlignment.Name = "UIStrategyAlignment";
            this.UIStrategyAlignment.ReadOnly = true;
            this.UIStrategyAlignment.Size = new System.Drawing.Size(100, 20);
            this.UIStrategyAlignment.TabIndex = 129;
            // 
            // UIStrategyAggression
            // 
            this.UIStrategyAggression.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "StrategyAggressionName", true));
            this.UIStrategyAggression.Location = new System.Drawing.Point(221, 332);
            this.UIStrategyAggression.Name = "UIStrategyAggression";
            this.UIStrategyAggression.ReadOnly = true;
            this.UIStrategyAggression.Size = new System.Drawing.Size(100, 20);
            this.UIStrategyAggression.TabIndex = 128;
            // 
            // UIStrategyBrave
            // 
            this.UIStrategyBrave.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "StrategyBraveName", true));
            this.UIStrategyBrave.Location = new System.Drawing.Point(114, 332);
            this.UIStrategyBrave.Name = "UIStrategyBrave";
            this.UIStrategyBrave.ReadOnly = true;
            this.UIStrategyBrave.Size = new System.Drawing.Size(100, 20);
            this.UIStrategyBrave.TabIndex = 127;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 332);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 126;
            this.label20.Text = "Strategy";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 361);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 13);
            this.label19.TabIndex = 125;
            this.label19.Text = "Mimics powers of victim";
            // 
            // UIMimicPowers
            // 
            this.UIMimicPowers.AutoCheck = false;
            this.UIMimicPowers.AutoSize = true;
            this.UIMimicPowers.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "MimicPowers", true));
            this.UIMimicPowers.Location = new System.Drawing.Point(144, 360);
            this.UIMimicPowers.Name = "UIMimicPowers";
            this.UIMimicPowers.Size = new System.Drawing.Size(15, 14);
            this.UIMimicPowers.TabIndex = 124;
            this.UIMimicPowers.UseVisualStyleBackColor = true;
            // 
            // UIReadiedArmor
            // 
            this.UIReadiedArmor.Location = new System.Drawing.Point(114, 297);
            this.UIReadiedArmor.Name = "UIReadiedArmor";
            this.UIReadiedArmor.ReadOnly = true;
            this.UIReadiedArmor.Size = new System.Drawing.Size(312, 20);
            this.UIReadiedArmor.TabIndex = 123;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 304);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 13);
            this.label18.TabIndex = 122;
            this.label18.Text = "Readied Armor";
            // 
            // UIReadiedWeapon
            // 
            this.UIReadiedWeapon.Location = new System.Drawing.Point(114, 271);
            this.UIReadiedWeapon.Name = "UIReadiedWeapon";
            this.UIReadiedWeapon.ReadOnly = true;
            this.UIReadiedWeapon.Size = new System.Drawing.Size(312, 20);
            this.UIReadiedWeapon.TabIndex = 121;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 278);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 13);
            this.label17.TabIndex = 120;
            this.label17.Text = "Readied Weapon";
            // 
            // UISpecialDefense
            // 
            this.UISpecialDefense.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "DefenseTypeName", true));
            this.UISpecialDefense.Location = new System.Drawing.Point(114, 245);
            this.UISpecialDefense.Name = "UISpecialDefense";
            this.UISpecialDefense.ReadOnly = true;
            this.UISpecialDefense.Size = new System.Drawing.Size(312, 20);
            this.UISpecialDefense.TabIndex = 119;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 252);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 13);
            this.label16.TabIndex = 118;
            this.label16.Text = "Special Defense";
            // 
            // UISpeed
            // 
            this.UISpeed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Speed", true));
            this.UISpeed.Location = new System.Drawing.Point(377, 219);
            this.UISpeed.Name = "UISpeed";
            this.UISpeed.ReadOnly = true;
            this.UISpeed.Size = new System.Drawing.Size(49, 20);
            this.UISpeed.TabIndex = 117;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(283, 226);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 116;
            this.label14.Text = "Speed";
            // 
            // UIWealth
            // 
            this.UIWealth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Wealth", true));
            this.UIWealth.Location = new System.Drawing.Point(114, 219);
            this.UIWealth.Name = "UIWealth";
            this.UIWealth.ReadOnly = true;
            this.UIWealth.Size = new System.Drawing.Size(49, 20);
            this.UIWealth.TabIndex = 115;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 226);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 114;
            this.label15.Text = "Wealth";
            // 
            // UIParrySkill
            // 
            this.UIParrySkill.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "ParrySkill", true));
            this.UIParrySkill.Location = new System.Drawing.Point(377, 193);
            this.UIParrySkill.Name = "UIParrySkill";
            this.UIParrySkill.ReadOnly = true;
            this.UIParrySkill.Size = new System.Drawing.Size(49, 20);
            this.UIParrySkill.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(283, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Parry Skill";
            // 
            // UIDodgeSkill
            // 
            this.UIDodgeSkill.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "DodgeSkill", true));
            this.UIDodgeSkill.Location = new System.Drawing.Point(377, 167);
            this.UIDodgeSkill.Name = "UIDodgeSkill";
            this.UIDodgeSkill.ReadOnly = true;
            this.UIDodgeSkill.Size = new System.Drawing.Size(49, 20);
            this.UIDodgeSkill.TabIndex = 111;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 110;
            this.label9.Text = "Dodge Skill";
            // 
            // UIArmorSkill
            // 
            this.UIArmorSkill.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "ArmorSkill", true));
            this.UIArmorSkill.Location = new System.Drawing.Point(377, 141);
            this.UIArmorSkill.Name = "UIArmorSkill";
            this.UIArmorSkill.ReadOnly = true;
            this.UIArmorSkill.Size = new System.Drawing.Size(49, 20);
            this.UIArmorSkill.TabIndex = 109;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 108;
            this.label10.Text = "Armor Skill";
            // 
            // UISize
            // 
            this.UISize.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Size", true));
            this.UISize.Location = new System.Drawing.Point(377, 115);
            this.UISize.Name = "UISize";
            this.UISize.ReadOnly = true;
            this.UISize.Size = new System.Drawing.Size(49, 20);
            this.UISize.TabIndex = 107;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(283, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "Size";
            // 
            // UIPower
            // 
            this.UIPower.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Power", true));
            this.UIPower.Location = new System.Drawing.Point(377, 89);
            this.UIPower.Name = "UIPower";
            this.UIPower.ReadOnly = true;
            this.UIPower.Size = new System.Drawing.Size(49, 20);
            this.UIPower.TabIndex = 105;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(283, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 104;
            this.label12.Text = "Power";
            // 
            // UILifeForce
            // 
            this.UILifeForce.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "LifeForce", true));
            this.UILifeForce.Location = new System.Drawing.Point(377, 63);
            this.UILifeForce.Name = "UILifeForce";
            this.UILifeForce.ReadOnly = true;
            this.UILifeForce.Size = new System.Drawing.Size(49, 20);
            this.UILifeForce.TabIndex = 103;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(283, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 102;
            this.label13.Text = "Life Force";
            // 
            // UIMeleeSkill
            // 
            this.UIMeleeSkill.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "MeleeSkill", true));
            this.UIMeleeSkill.Location = new System.Drawing.Point(114, 193);
            this.UIMeleeSkill.Name = "UIMeleeSkill";
            this.UIMeleeSkill.ReadOnly = true;
            this.UIMeleeSkill.Size = new System.Drawing.Size(49, 20);
            this.UIMeleeSkill.TabIndex = 101;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "Melee Skill";
            // 
            // UIMissileSkill
            // 
            this.UIMissileSkill.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "MissileSkill", true));
            this.UIMissileSkill.Location = new System.Drawing.Point(114, 167);
            this.UIMissileSkill.Name = "UIMissileSkill";
            this.UIMissileSkill.ReadOnly = true;
            this.UIMissileSkill.Size = new System.Drawing.Size(49, 20);
            this.UIMissileSkill.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Missile Skill";
            // 
            // UIDexterity
            // 
            this.UIDexterity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Dexterity", true));
            this.UIDexterity.Location = new System.Drawing.Point(114, 141);
            this.UIDexterity.Name = "UIDexterity";
            this.UIDexterity.ReadOnly = true;
            this.UIDexterity.Size = new System.Drawing.Size(49, 20);
            this.UIDexterity.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "Dexterity";
            // 
            // UIStrength
            // 
            this.UIStrength.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Strength", true));
            this.UIStrength.Location = new System.Drawing.Point(114, 115);
            this.UIStrength.Name = "UIStrength";
            this.UIStrength.ReadOnly = true;
            this.UIStrength.Size = new System.Drawing.Size(49, 20);
            this.UIStrength.TabIndex = 95;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "Strength";
            // 
            // UIWisdom
            // 
            this.UIWisdom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Wisdom", true));
            this.UIWisdom.Location = new System.Drawing.Point(114, 89);
            this.UIWisdom.Name = "UIWisdom";
            this.UIWisdom.ReadOnly = true;
            this.UIWisdom.Size = new System.Drawing.Size(49, 20);
            this.UIWisdom.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Wisdom";
            // 
            // UIConstitution
            // 
            this.UIConstitution.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Constitution", true));
            this.UIConstitution.Location = new System.Drawing.Point(114, 63);
            this.UIConstitution.Name = "UIConstitution";
            this.UIConstitution.ReadOnly = true;
            this.UIConstitution.Size = new System.Drawing.Size(49, 20);
            this.UIConstitution.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "Constitution";
            // 
            // UIClass
            // 
            this.UIClass.Location = new System.Drawing.Point(286, 26);
            this.UIClass.Name = "UIClass";
            this.UIClass.ReadOnly = true;
            this.UIClass.Size = new System.Drawing.Size(250, 20);
            this.UIClass.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Class";
            // 
            // UIName
            // 
            this.UIName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Name", true));
            this.UIName.Location = new System.Drawing.Point(15, 26);
            this.UIName.Name = "UIName";
            this.UIName.ReadOnly = true;
            this.UIName.Size = new System.Drawing.Size(248, 20);
            this.UIName.TabIndex = 87;
            // 
            // UINameLabel
            // 
            this.UINameLabel.AutoSize = true;
            this.UINameLabel.Location = new System.Drawing.Point(12, 9);
            this.UINameLabel.Name = "UINameLabel";
            this.UINameLabel.Size = new System.Drawing.Size(35, 13);
            this.UINameLabel.TabIndex = 86;
            this.UINameLabel.Text = "Name";
            // 
            // UIPicture
            // 
            this.UIPicture.Location = new System.Drawing.Point(452, 63);
            this.UIPicture.Name = "UIPicture";
            this.UIPicture.Size = new System.Drawing.Size(69, 60);
            this.UIPicture.TabIndex = 131;
            this.UIPicture.TabStop = false;
            this.UIPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.UIPicture_Paint);
            // 
            // UIChanceLabel
            // 
            this.UIChanceLabel.AutoSize = true;
            this.UIChanceLabel.Location = new System.Drawing.Point(23, 533);
            this.UIChanceLabel.Name = "UIChanceLabel";
            this.UIChanceLabel.Size = new System.Drawing.Size(106, 13);
            this.UIChanceLabel.TabIndex = 132;
            this.UIChanceLabel.Text = "% Chance Appearing";
            // 
            // UIPercentChance
            // 
            this.UIPercentChance.Location = new System.Drawing.Point(23, 550);
            this.UIPercentChance.Name = "UIPercentChance";
            this.UIPercentChance.ReadOnly = true;
            this.UIPercentChance.Size = new System.Drawing.Size(100, 20);
            this.UIPercentChance.TabIndex = 133;
            // 
            // UITerrain
            // 
            this.UITerrain.Location = new System.Drawing.Point(166, 550);
            this.UITerrain.Name = "UITerrain";
            this.UITerrain.ReadOnly = true;
            this.UITerrain.Size = new System.Drawing.Size(121, 20);
            this.UITerrain.TabIndex = 135;
            // 
            // UITerrainLabel
            // 
            this.UITerrainLabel.AutoSize = true;
            this.UITerrainLabel.Location = new System.Drawing.Point(166, 533);
            this.UITerrainLabel.Name = "UITerrainLabel";
            this.UITerrainLabel.Size = new System.Drawing.Size(58, 13);
            this.UITerrainLabel.TabIndex = 134;
            this.UITerrainLabel.Text = "Appears In";
            // 
            // UIPossessions
            // 
            this.UIPossessions.FormattingEnabled = true;
            this.UIPossessions.Location = new System.Drawing.Point(26, 393);
            this.UIPossessions.Name = "UIPossessions";
            this.UIPossessions.Size = new System.Drawing.Size(400, 121);
            this.UIPossessions.TabIndex = 136;
            // 
            // CreatureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 590);
            this.Controls.Add(this.UIPossessions);
            this.Controls.Add(this.UITerrain);
            this.Controls.Add(this.UITerrainLabel);
            this.Controls.Add(this.UIPercentChance);
            this.Controls.Add(this.UIChanceLabel);
            this.Controls.Add(this.UIPicture);
            this.Controls.Add(this.UIStrategyAlignment);
            this.Controls.Add(this.UIStrategyAggression);
            this.Controls.Add(this.UIStrategyBrave);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.UIMimicPowers);
            this.Controls.Add(this.UIReadiedArmor);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.UIReadiedWeapon);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.UISpecialDefense);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.UISpeed);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.UIWealth);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.UIParrySkill);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.UIDodgeSkill);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.UIArmorSkill);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.UISize);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.UIPower);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.UILifeForce);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.UIMeleeSkill);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.UIMissileSkill);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UIDexterity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UIStrength);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.UIWisdom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UIConstitution);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UIClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UIName);
            this.Controls.Add(this.UINameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreatureViewer";
            this.Load += new System.EventHandler(this.CreatureViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource thingBindingSource;
        private System.Windows.Forms.TextBox UIStrategyAlignment;
        private System.Windows.Forms.TextBox UIStrategyAggression;
        private System.Windows.Forms.TextBox UIStrategyBrave;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox UIMimicPowers;
        private System.Windows.Forms.TextBox UIReadiedArmor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox UIReadiedWeapon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox UISpecialDefense;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox UISpeed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox UIWealth;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox UIParrySkill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UIDodgeSkill;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox UIArmorSkill;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox UISize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox UIPower;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox UILifeForce;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox UIMeleeSkill;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UIMissileSkill;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UIDexterity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UIStrength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox UIWisdom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UIConstitution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UIClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UIName;
        private System.Windows.Forms.Label UINameLabel;
        private System.Windows.Forms.PictureBox UIPicture;
        private System.Windows.Forms.Label UIChanceLabel;
        private System.Windows.Forms.TextBox UIPercentChance;
        private System.Windows.Forms.TextBox UITerrain;
        private System.Windows.Forms.Label UITerrainLabel;
        private System.Windows.Forms.ListBox UIPossessions;
    }
}