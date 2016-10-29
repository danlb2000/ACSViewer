namespace AcsViewer
{
    partial class RegionViewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.UIRoom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UIMap)).BeginInit();
            this.SuspendLayout();
            // 
            // UIMap
            // 
            this.UIMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UIMap.Location = new System.Drawing.Point(6, 1);
            this.UIMap.Name = "UIMap";
            this.UIMap.Size = new System.Drawing.Size(736, 359);
            this.UIMap.TabIndex = 1;
            this.UIMap.TabStop = false;
            this.UIMap.Paint += new System.Windows.Forms.PaintEventHandler(this.UIMap_Paint);
            this.UIMap.DoubleClick += new System.EventHandler(this.UIMap_DoubleClick);
            this.UIMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIMap_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Room";
            // 
            // UIRoom
            // 
            this.UIRoom.Location = new System.Drawing.Point(6, 380);
            this.UIRoom.Name = "UIRoom";
            this.UIRoom.ReadOnly = true;
            this.UIRoom.Size = new System.Drawing.Size(150, 20);
            this.UIRoom.TabIndex = 3;
            // 
            // RegionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 410);
            this.Controls.Add(this.UIRoom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UIMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegionViewer";
            this.Text = "RegionViewer";
            ((System.ComponentModel.ISupportInitialize)(this.UIMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UIMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UIRoom;
    }
}