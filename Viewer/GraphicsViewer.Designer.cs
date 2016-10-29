namespace AcsViewer
{
    partial class GraphicsViewer
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
            this.pbGraphics = new System.Windows.Forms.PictureBox();
            this.UIPrevious = new System.Windows.Forms.Button();
            this.UINext = new System.Windows.Forms.Button();
            this.UINumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraphics)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGraphics
            // 
            this.pbGraphics.Location = new System.Drawing.Point(38, 12);
            this.pbGraphics.Name = "pbGraphics";
            this.pbGraphics.Size = new System.Drawing.Size(82, 76);
            this.pbGraphics.TabIndex = 0;
            this.pbGraphics.TabStop = false;
            this.pbGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGraphics_Paint);
            // 
            // UIPrevious
            // 
            this.UIPrevious.Location = new System.Drawing.Point(10, 114);
            this.UIPrevious.Name = "UIPrevious";
            this.UIPrevious.Size = new System.Drawing.Size(39, 23);
            this.UIPrevious.TabIndex = 1;
            this.UIPrevious.Text = "<";
            this.UIPrevious.UseVisualStyleBackColor = true;
            this.UIPrevious.Click += new System.EventHandler(this.UIPrevious_Click);
            // 
            // UINext
            // 
            this.UINext.Location = new System.Drawing.Point(108, 114);
            this.UINext.Name = "UINext";
            this.UINext.Size = new System.Drawing.Size(38, 23);
            this.UINext.TabIndex = 2;
            this.UINext.Text = ">";
            this.UINext.UseVisualStyleBackColor = true;
            this.UINext.Click += new System.EventHandler(this.UINext_Click);
            // 
            // UINumber
            // 
            this.UINumber.Location = new System.Drawing.Point(55, 116);
            this.UINumber.Name = "UINumber";
            this.UINumber.Size = new System.Drawing.Size(47, 20);
            this.UINumber.TabIndex = 3;
            this.UINumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UINumber_KeyUp);
            // 
            // GraphicsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 152);
            this.Controls.Add(this.UINumber);
            this.Controls.Add(this.UINext);
            this.Controls.Add(this.UIPrevious);
            this.Controls.Add(this.pbGraphics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GraphicsViewer";
            this.Text = "GraphicsViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pbGraphics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGraphics;
        private System.Windows.Forms.Button UIPrevious;
        private System.Windows.Forms.Button UINext;
        private System.Windows.Forms.TextBox UINumber;
    }
}