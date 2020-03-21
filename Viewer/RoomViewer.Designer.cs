namespace AcsViewer
{
    partial class RoomViewer
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
            this.UIMap = new System.Windows.Forms.PictureBox();
            this.UIItems = new System.Windows.Forms.ListBox();
            this.UIResidentCreatures = new System.Windows.Forms.ListBox();
            this.UIInformation = new System.Windows.Forms.TextBox();
            this.lblRandomCreature = new System.Windows.Forms.Label();
            this.UIRandomCreature = new System.Windows.Forms.TextBox();
            this.lblAppearChance = new System.Windows.Forms.Label();
            this.UIAppearChance = new System.Windows.Forms.TextBox();
            this.UIPortalDestination = new System.Windows.Forms.TextBox();
            this.UIPortalDest = new System.Windows.Forms.Label();
            this.UIStoreItems = new System.Windows.Forms.ListBox();
            this.UIText = new System.Windows.Forms.TextBox();
            this.UIPlayers = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.UIMap)).BeginInit();
            this.SuspendLayout();
            // 
            // UIMap
            // 
            this.UIMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UIMap.Location = new System.Drawing.Point(0, 0);
            this.UIMap.Name = "UIMap";
            this.UIMap.Size = new System.Drawing.Size(696, 587);
            this.UIMap.TabIndex = 1;
            this.UIMap.TabStop = false;
            this.UIMap.Paint += new System.Windows.Forms.PaintEventHandler(this.UIMap_Paint);
            // 
            // UIItems
            // 
            this.UIItems.FormattingEnabled = true;
            this.UIItems.Location = new System.Drawing.Point(702, 0);
            this.UIItems.Name = "UIItems";
            this.UIItems.Size = new System.Drawing.Size(147, 251);
            this.UIItems.TabIndex = 2;
            this.UIItems.SelectedIndexChanged += new System.EventHandler(this.UIItems_SelectedIndexChanged);
            this.UIItems.DoubleClick += new System.EventHandler(this.UIItems_DoubleClick);
            // 
            // UIResidentCreatures
            // 
            this.UIResidentCreatures.FormattingEnabled = true;
            this.UIResidentCreatures.Location = new System.Drawing.Point(702, 258);
            this.UIResidentCreatures.Name = "UIResidentCreatures";
            this.UIResidentCreatures.Size = new System.Drawing.Size(147, 212);
            this.UIResidentCreatures.TabIndex = 3;
            this.UIResidentCreatures.SelectedIndexChanged += new System.EventHandler(this.UIResidentCreatures_SelectedIndexChanged);
            this.UIResidentCreatures.DoubleClick += new System.EventHandler(this.UIResidentCreatures_DoubleClick);
            // 
            // UIInformation
            // 
            this.UIInformation.Location = new System.Drawing.Point(0, 588);
            this.UIInformation.Multiline = true;
            this.UIInformation.Name = "UIInformation";
            this.UIInformation.Size = new System.Drawing.Size(696, 72);
            this.UIInformation.TabIndex = 4;
            // 
            // lblRandomCreature
            // 
            this.lblRandomCreature.AutoSize = true;
            this.lblRandomCreature.Location = new System.Drawing.Point(16, 676);
            this.lblRandomCreature.Name = "lblRandomCreature";
            this.lblRandomCreature.Size = new System.Drawing.Size(90, 13);
            this.lblRandomCreature.TabIndex = 5;
            this.lblRandomCreature.Text = "Random Creature";
            // 
            // UIRandomCreature
            // 
            this.UIRandomCreature.Location = new System.Drawing.Point(19, 689);
            this.UIRandomCreature.Name = "UIRandomCreature";
            this.UIRandomCreature.Size = new System.Drawing.Size(136, 20);
            this.UIRandomCreature.TabIndex = 6;
            this.UIRandomCreature.DoubleClick += new System.EventHandler(this.UIRandomCreature_DoubleClick);
            // 
            // lblAppearChance
            // 
            this.lblAppearChance.AutoSize = true;
            this.lblAppearChance.Location = new System.Drawing.Point(182, 675);
            this.lblAppearChance.Name = "lblAppearChance";
            this.lblAppearChance.Size = new System.Drawing.Size(107, 13);
            this.lblAppearChance.TabIndex = 7;
            this.lblAppearChance.Text = "Chance of Appearing";
            // 
            // UIAppearChance
            // 
            this.UIAppearChance.Location = new System.Drawing.Point(185, 689);
            this.UIAppearChance.Name = "UIAppearChance";
            this.UIAppearChance.Size = new System.Drawing.Size(100, 20);
            this.UIAppearChance.TabIndex = 8;
            // 
            // UIPortalDestination
            // 
            this.UIPortalDestination.Location = new System.Drawing.Point(325, 689);
            this.UIPortalDestination.Name = "UIPortalDestination";
            this.UIPortalDestination.Size = new System.Drawing.Size(260, 20);
            this.UIPortalDestination.TabIndex = 10;
            // 
            // UIPortalDest
            // 
            this.UIPortalDest.AutoSize = true;
            this.UIPortalDest.Location = new System.Drawing.Point(322, 675);
            this.UIPortalDest.Name = "UIPortalDest";
            this.UIPortalDest.Size = new System.Drawing.Size(90, 13);
            this.UIPortalDest.TabIndex = 9;
            this.UIPortalDest.Text = "Portal Destination";
            // 
            // UIStoreItems
            // 
            this.UIStoreItems.FormattingEnabled = true;
            this.UIStoreItems.Location = new System.Drawing.Point(0, 588);
            this.UIStoreItems.Name = "UIStoreItems";
            this.UIStoreItems.Size = new System.Drawing.Size(696, 121);
            this.UIStoreItems.TabIndex = 11;
            this.UIStoreItems.Visible = false;
            // 
            // UIText
            // 
            this.UIText.Enabled = false;
            this.UIText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIText.Location = new System.Drawing.Point(19, 588);
            this.UIText.Multiline = true;
            this.UIText.Name = "UIText";
            this.UIText.ReadOnly = true;
            this.UIText.Size = new System.Drawing.Size(233, 130);
            this.UIText.TabIndex = 12;
            this.UIText.Visible = false;
            this.UIText.WordWrap = false;
            // 
            // UIPlayers
            // 
            this.UIPlayers.FormattingEnabled = true;
            this.UIPlayers.Location = new System.Drawing.Point(702, 477);
            this.UIPlayers.Name = "UIPlayers";
            this.UIPlayers.Size = new System.Drawing.Size(147, 212);
            this.UIPlayers.TabIndex = 13;
            this.UIPlayers.SelectedIndexChanged += new System.EventHandler(this.UIPlayers_SelectedIndexChanged);
            this.UIPlayers.DoubleClick += new System.EventHandler(this.UIPlayers_DoubleClick);
            // 
            // RoomViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 721);
            this.Controls.Add(this.UIPlayers);
            this.Controls.Add(this.UIPortalDestination);
            this.Controls.Add(this.UIPortalDest);
            this.Controls.Add(this.UIAppearChance);
            this.Controls.Add(this.lblAppearChance);
            this.Controls.Add(this.UIRandomCreature);
            this.Controls.Add(this.lblRandomCreature);
            this.Controls.Add(this.UIInformation);
            this.Controls.Add(this.UIResidentCreatures);
            this.Controls.Add(this.UIItems);
            this.Controls.Add(this.UIStoreItems);
            this.Controls.Add(this.UIText);
            this.Controls.Add(this.UIMap);
            this.Name = "RoomViewer";
            this.Text = "RoomViewer";
            this.Load += new System.EventHandler(this.RoomViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UIMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UIMap;
        private System.Windows.Forms.ListBox UIItems;
        private System.Windows.Forms.ListBox UIResidentCreatures;
        private System.Windows.Forms.TextBox UIInformation;
        private System.Windows.Forms.Label lblRandomCreature;
        private System.Windows.Forms.TextBox UIRandomCreature;
        private System.Windows.Forms.Label lblAppearChance;
        private System.Windows.Forms.TextBox UIAppearChance;
        private System.Windows.Forms.TextBox UIPortalDestination;
        private System.Windows.Forms.Label UIPortalDest;
        private System.Windows.Forms.ListBox UIStoreItems;
        private System.Windows.Forms.TextBox UIText;
        private System.Windows.Forms.ListBox UIPlayers;
    }
}