namespace AcsViewer
{
    partial class DisplayText
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
            this.UIText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UIText
            // 
            this.UIText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIText.Location = new System.Drawing.Point(4, 3);
            this.UIText.Multiline = true;
            this.UIText.Name = "UIText";
            this.UIText.Size = new System.Drawing.Size(233, 130);
            this.UIText.TabIndex = 0;
            this.UIText.WordWrap = false;
            // 
            // DisplayText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 135);
            this.Controls.Add(this.UIText);
            this.Name = "DisplayText";
            this.Text = "DisplayText";
            this.Load += new System.EventHandler(this.DisplayText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UIText;
    }
}