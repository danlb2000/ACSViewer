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
    public partial class TerrainViewer : Form
    {
        public GameDefinition Definition { get; set; }
        public Terrain Terrain { get; set; }

        public TerrainViewer()
        {
            InitializeComponent();
        }

        private void TerrainViewer_Load(object sender, EventArgs e)
        {
            if (Definition == null || Terrain == null) return;
            ShowTerrain();
        }

        private void ShowTerrain()
        {
            this.Text = "View Terrain " + Terrain.Name;
            UIName.Text = Terrain.Name;
            UIPictureNum.Text = Terrain.Picture.ToString();
            UIPicture.Refresh();

            string openTo = Terrain.TypeOfTerrain.ToDescription();

            if (Terrain.TypeOfTerrain == AcsLib.Terrain.TerrainType.OpenToOwnerOf || Terrain.TypeOfTerrain == AcsLib.Terrain.TerrainType.TriggersSpell)
            {
                openTo += " " + Definition.Things[Terrain.TypeParameter - 1].Name;
            }
            UIOpenTo.Text = openTo;
        }

        private void UIPicture_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(Definition.Pictures[Terrain.Picture], 0, 0, 64, 64);
        }
    }
}
