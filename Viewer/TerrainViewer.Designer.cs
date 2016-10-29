namespace AcsViewer
{
    partial class TerrainViewer
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
            this.UIPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UIName = new System.Windows.Forms.TextBox();
            this.UIPictureNum = new System.Windows.Forms.Label();
            this.UIOpenTo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UIPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // UIPicture
            // 
            this.UIPicture.Location = new System.Drawing.Point(162, 21);
            this.UIPicture.Name = "UIPicture";
            this.UIPicture.Size = new System.Drawing.Size(69, 71);
            this.UIPicture.TabIndex = 1;
            this.UIPicture.TabStop = false;
            this.UIPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.UIPicture_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // UIName
            // 
            this.UIName.Location = new System.Drawing.Point(28, 127);
            this.UIName.Name = "UIName";
            this.UIName.ReadOnly = true;
            this.UIName.Size = new System.Drawing.Size(337, 20);
            this.UIName.TabIndex = 3;
            // 
            // UIPictureNum
            // 
            this.UIPictureNum.AutoSize = true;
            this.UIPictureNum.Location = new System.Drawing.Point(189, 95);
            this.UIPictureNum.Name = "UIPictureNum";
            this.UIPictureNum.Size = new System.Drawing.Size(13, 13);
            this.UIPictureNum.TabIndex = 4;
            this.UIPictureNum.Text = "0";
            // 
            // UIOpenTo
            // 
            this.UIOpenTo.Location = new System.Drawing.Point(28, 173);
            this.UIOpenTo.Name = "UIOpenTo";
            this.UIOpenTo.ReadOnly = true;
            this.UIOpenTo.Size = new System.Drawing.Size(337, 20);
            this.UIOpenTo.TabIndex = 6;
            // 
            // TerrainViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 243);
            this.Controls.Add(this.UIOpenTo);
            this.Controls.Add(this.UIPictureNum);
            this.Controls.Add(this.UIName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UIPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TerrainViewer";
            this.Text = "TerrainViewer";
            this.Load += new System.EventHandler(this.TerrainViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UIPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UIPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UIName;
        private System.Windows.Forms.Label UIPictureNum;
        private System.Windows.Forms.TextBox UIOpenTo;
    }
}