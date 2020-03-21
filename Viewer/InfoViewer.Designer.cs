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
            this.UITheme = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Byline";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Introduction";
            // 
            // UIName
            // 
            this.UIName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIName.Location = new System.Drawing.Point(12, 25);
            this.UIName.Name = "UIName";
            this.UIName.ReadOnly = true;
            this.UIName.Size = new System.Drawing.Size(148, 21);
            this.UIName.TabIndex = 3;
            // 
            // UIByLine
            // 
            this.UIByLine.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIByLine.Location = new System.Drawing.Point(12, 65);
            this.UIByLine.Name = "UIByLine";
            this.UIByLine.ReadOnly = true;
            this.UIByLine.Size = new System.Drawing.Size(148, 21);
            this.UIByLine.TabIndex = 4;
            // 
            // UIIntroduction
            // 
            this.UIIntroduction.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIIntroduction.Location = new System.Drawing.Point(12, 145);
            this.UIIntroduction.Multiline = true;
            this.UIIntroduction.Name = "UIIntroduction";
            this.UIIntroduction.ReadOnly = true;
            this.UIIntroduction.Size = new System.Drawing.Size(233, 130);
            this.UIIntroduction.TabIndex = 5;
            this.UIIntroduction.WordWrap = false;
            // 
            // UITheme
            // 
            this.UITheme.Location = new System.Drawing.Point(12, 105);
            this.UITheme.Name = "UITheme";
            this.UITheme.ReadOnly = true;
            this.UITheme.Size = new System.Drawing.Size(148, 20);
            this.UITheme.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Theme";
            // 
            // InfoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 287);
            this.Controls.Add(this.UITheme);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.TextBox UITheme;
        private System.Windows.Forms.Label label4;
    }
}