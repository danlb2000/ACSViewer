namespace AcsViewer
{
    partial class InfoViewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UIName = new System.Windows.Forms.TextBox();
            this.UIByLine = new System.Windows.Forms.TextBox();
            this.UIIntroduction = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adventure Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "By Line";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Introduction";
            // 
            // UIName
            // 
            this.UIName.Location = new System.Drawing.Point(12, 25);
            this.UIName.Name = "UIName";
            this.UIName.ReadOnly = true;
            this.UIName.Size = new System.Drawing.Size(257, 20);
            this.UIName.TabIndex = 3;
            // 
            // UIByLine
            // 
            this.UIByLine.Location = new System.Drawing.Point(12, 75);
            this.UIByLine.Name = "UIByLine";
            this.UIByLine.ReadOnly = true;
            this.UIByLine.Size = new System.Drawing.Size(257, 20);
            this.UIByLine.TabIndex = 4;
            // 
            // UIIntroduction
            // 
            this.UIIntroduction.Location = new System.Drawing.Point(15, 127);
            this.UIIntroduction.Multiline = true;
            this.UIIntroduction.Name = "UIIntroduction";
            this.UIIntroduction.ReadOnly = true;
            this.UIIntroduction.Size = new System.Drawing.Size(336, 144);
            this.UIIntroduction.TabIndex = 5;
            // 
            // InfoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 293);
            this.Controls.Add(this.UIIntroduction);
            this.Controls.Add(this.UIByLine);
            this.Controls.Add(this.UIName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InfoViewer";
            this.Text = "Game Information";
            this.Load += new System.EventHandler(this.InfoViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UIName;
        private System.Windows.Forms.TextBox UIByLine;
        private System.Windows.Forms.TextBox UIIntroduction;
    }
}