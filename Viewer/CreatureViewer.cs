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
    public partial class CreatureViewer : Form
    {
        public GameDefinition Definition { get; set; }
        public Creature Creature { get; set; }
        public WorldMapCreature MapCreature { get; set; }

        public CreatureViewer()
        {
            InitializeComponent();
        }

        private void ShowCreature()
        {
            if (MapCreature != null)
            {
                Creature = MapCreature.Creature;
                UIPercentChance.Text = string.Format("{0}%", MapCreature.ChanceAppearing);
                //UITerrain.Text = Definition.TerrainTypes[MapCreature.AppearingInTerrain].Name;
                UITerrain.Text = MapCreature.AppearingIn;
            }

            this.Text = Creature.Name;
            thingBindingSource.DataSource = Creature;
            for (int i = 0; i < 81; i++)
            {
                if (Creature.Possessions[i] != 0)
                {
                    string s = "(" + Creature.Possessions[i].ToString() + ") " + Definition.Things[i - 1].Name;
                    UIPossessions.Items.Add(s);
                }
            }
        }

        private void thingBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            Creature creature = (Creature)thingBindingSource.DataSource;
            if (creature == null) return;

            UIClass.Text = Definition.CreatureClassNames[creature.Class];
            if (MapCreature != null) UIClass.Text = "Map Creature";
            if (creature.ReadiedArmor > 0) UIReadiedArmor.Text = Definition.Things[creature.ReadiedArmor - 1].Name;
            if (creature.ReadiedWeapon > 0) UIReadiedWeapon.Text = Definition.Things[creature.ReadiedWeapon - 1].Name;
        }

        private void UIPicture_Paint(object sender, PaintEventArgs e)
        {
            Creature creature = (Creature)thingBindingSource.DataSource;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (Definition.Pictures[creature.Picture & 0x7F] != null) e.Graphics.DrawImage(Definition.Pictures[creature.Picture], 0, 0, 64, 64);
        }

        private void CreatureViewer_Load(object sender, EventArgs e)
        {
            ShowCreature();
        }
    }
}
