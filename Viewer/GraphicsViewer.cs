/*   This file is part of ACS Viewer.
     Copyright (C) 2016  Dan Boris (danlb_2000@yahoo.com)

    ACS Viewer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ACS Viewer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using AcsLib;
using System;
using System.Windows.Forms;

namespace AcsViewer
{
    public partial class GraphicsViewer : Form
    {
        public GameDefinition Definition { get; set; }

        private int picNum = 0;

        public GraphicsViewer()
        {
            InitializeComponent();
        }

        public void UpdateDisplay()
        {
            this.Refresh();
            UINumber.Text = picNum.ToString();
        }

        private void pbGraphics_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (Definition.Pictures[picNum] != null) e.Graphics.DrawImage(Definition.Pictures[picNum], 0, 0, 64, 64);
        }


        private void UIPrevious_Click(object sender, EventArgs e)
        {
            if (picNum > 0) picNum -= 1;
            UpdateDisplay();
        }

        private void UINext_Click(object sender, EventArgs e)
        {
            if (picNum < 128) picNum += 1;
            UpdateDisplay();
        }

        private void UINumber_KeyUp(object sender, KeyEventArgs e)
        {
            int num;
            if (int.TryParse(UINumber.Text, out num))
            {
                if (num >= 0 && num <= 95)
                {
                    picNum = num;
                    UpdateDisplay();
                }
            }
        }
    }
}
