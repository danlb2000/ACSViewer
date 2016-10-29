namespace AcsViewer
{
    partial class MapViewer
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
            this.UIPortalNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.UIDestination = new System.Windows.Forms.TextBox();
            this.UIMapName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UIMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIPortalNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // UIMap
            // 
            this.UIMap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UIMap.Location = new System.Drawing.Point(13, 32);
            this.UIMap.Name = "UIMap";
            this.UIMap.Size = new System.Drawing.Size(630, 531);
            this.UIMap.TabIndex = 0;
            this.UIMap.TabStop = false;
            this.UIMap.Paint += new System.Windows.Forms.PaintEventHandler(this.UIMap_Paint);
            // 
            // UIPortalNumber
            // 
            this.UIPortalNumber.Location = new System.Drawing.Point(12, 591);
            this.UIPortalNumber.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.UIPortalNumber.Name = "UIPortalNumber";
            this.UIPortalNumber.Size = new System.Drawing.Size(120, 20);
            this.UIPortalNumber.TabIndex = 1;
            this.UIPortalNumber.ValueChanged += new System.EventHandler(this.UIPortalNumber_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 572);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Portal";
            // 
            // UIDestination
            // 
            this.UIDestination.Location = new System.Drawing.Point(139, 591);
            this.UIDestination.Name = "UIDestination";
            this.UIDestination.Size = new System.Drawing.Size(503, 20);
            this.UIDestination.TabIndex = 3;
            // 
            // UIMapName
            // 
            this.UIMapName.Location = new System.Drawing.Point(12, 6);
            this.UIMapName.Name = "UIMapName";
            this.UIMapName.ReadOnly = true;
            this.UIMapName.Size = new System.Drawing.Size(630, 20);
            this.UIMapName.TabIndex = 4;
            // 
            // MapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 623);
            this.Controls.Add(this.UIMapName);
            this.Controls.Add(this.UIDestination);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UIPortalNumber);
            this.Controls.Add(this.UIMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MapViewer";
            this.Text = "MapViewer";
            this.Load += new System.EventHandler(this.MapViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UIMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIPortalNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UIMap;
        private System.Windows.Forms.NumericUpDown UIPortalNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UIDestination;
        private System.Windows.Forms.TextBox UIMapName;
    }
}