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
            this.label1 = new System.Windows.Forms.Label();
            this.pbTerrain = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbTHings = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbCreatures = new System.Windows.Forms.PictureBox();
            this.pbGraphic = new System.Windows.Forms.PictureBox();
            this.UINumber = new System.Windows.Forms.TextBox();
            this.UIPrevious = new System.Windows.Forms.Button();
            this.UINext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pbPalette = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTerrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTHings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreatures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Terrain Pictures (or Things && Creatures)";
            // 
            // pbTerrain
            // 
            this.pbTerrain.Location = new System.Drawing.Point(13, 26);
            this.pbTerrain.Name = "pbTerrain";
            this.pbTerrain.Size = new System.Drawing.Size(288, 48);
            this.pbTerrain.TabIndex = 1;
            this.pbTerrain.TabStop = false;
            this.pbTerrain.Paint += new System.Windows.Forms.PaintEventHandler(this.pbTerrain_Paint);
            this.pbTerrain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbTerrain_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thing Pictures (or Terrain && Creatures)";
            // 
            // pbTHings
            // 
            this.pbTHings.Location = new System.Drawing.Point(13, 103);
            this.pbTHings.Name = "pbTHings";
            this.pbTHings.Size = new System.Drawing.Size(288, 96);
            this.pbTHings.TabIndex = 3;
            this.pbTHings.TabStop = false;
            this.pbTHings.Paint += new System.Windows.Forms.PaintEventHandler(this.pbThings_Paint);
            this.pbTHings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbThings_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Creature Pictures (only)";
            // 
            // pbCreatures
            // 
            this.pbCreatures.Location = new System.Drawing.Point(13, 224);
            this.pbCreatures.Name = "pbCreatures";
            this.pbCreatures.Size = new System.Drawing.Size(288, 96);
            this.pbCreatures.TabIndex = 5;
            this.pbCreatures.TabStop = false;
            this.pbCreatures.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCreatures_Paint);
            this.pbCreatures.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCreatures_MouseDown);
            // 
            // pbGraphic
            // 
            this.pbGraphic.Location = new System.Drawing.Point(414, 204);
            this.pbGraphic.Name = "pbGraphic";
            this.pbGraphic.Size = new System.Drawing.Size(64, 64);
            this.pbGraphic.TabIndex = 6;
            this.pbGraphic.TabStop = false;
            this.pbGraphic.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGraphic_Paint);
            // 
            // UINumber
            // 
            this.UINumber.Location = new System.Drawing.Point(422, 299);
            this.UINumber.Name = "UINumber";
            this.UINumber.Size = new System.Drawing.Size(47, 20);
            this.UINumber.TabIndex = 0;
            this.UINumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UINumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UINumber_KeyUp);
            // 
            // UIPrevious
            // 
            this.UIPrevious.Location = new System.Drawing.Point(377, 297);
            this.UIPrevious.Name = "UIPrevious";
            this.UIPrevious.Size = new System.Drawing.Size(39, 23);
            this.UIPrevious.TabIndex = 1;
            this.UIPrevious.Text = "<";
            this.UIPrevious.UseVisualStyleBackColor = true;
            this.UIPrevious.Click += new System.EventHandler(this.UIPrevious_Click);
            // 
            // UINext
            // 
            this.UINext.Location = new System.Drawing.Point(475, 297);
            this.UINext.Name = "UINext";
            this.UINext.Size = new System.Drawing.Size(39, 23);
            this.UINext.TabIndex = 2;
            this.UINext.Text = ">";
            this.UINext.UseVisualStyleBackColor = true;
            this.UINext.Click += new System.EventHandler(this.UINext_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(419, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Palette";
            // 
            // pbPalette
            // 
            this.pbPalette.Location = new System.Drawing.Point(323, 26);
            this.pbPalette.Name = "pbPalette";
            this.pbPalette.Size = new System.Drawing.Size(246, 148);
            this.pbPalette.TabIndex = 20;
            this.pbPalette.TabStop = false;
            this.pbPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPalette_Paint);
            // 
            // GraphicsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 333);
            this.Controls.Add(this.pbPalette);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UINext);
            this.Controls.Add(this.UIPrevious);
            this.Controls.Add(this.UINumber);
            this.Controls.Add(this.pbGraphic);
            this.Controls.Add(this.pbCreatures);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbTHings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbTerrain);
            this.Controls.Add(this.label1);
            this.Name = "GraphicsViewer";
            this.Text = "GraphicsViewer";
            this.Load += new System.EventHandler(this.GraphicsViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTerrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTHings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreatures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPalette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbTerrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbTHings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbCreatures;
        private System.Windows.Forms.PictureBox pbGraphic;
        private System.Windows.Forms.TextBox UINumber;
        private System.Windows.Forms.Button UIPrevious;
        private System.Windows.Forms.Button UINext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbPalette;
    }
}