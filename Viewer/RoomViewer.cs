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

using System.Drawing;
using System.Windows.Forms;
using AcsLib;
using System.Collections.Generic;

namespace AcsViewer
{
    public partial class RoomViewer : Form
    {
        private Bitmap bmp = new Bitmap(256, 256);
        private byte[,] map = new byte[16, 16];
        private int selectedX = -1;
        private int selectedY = -1;


        public byte floorTile;
        public byte wallPicture;

        private Room room = null;
        private GameDefinition definition = null;
        private AcsLib.Region region = null;

        public RoomViewer(GameDefinition definition, AcsLib.Region region, Room room)
        {
            InitializeComponent();
            this.definition = definition;
            this.region = region;
            this.room = room;
        }

        private void RoomViewer_Load(object sender, System.EventArgs e)
        {
            ShowRoom();
        }

        public void UpdateImage()
        {
            Graphics gr = Graphics.FromImage(bmp);

            for (int y = 0; y <= 15; y++)
            {
                for (int x = 0; x <= 15; x++)
                {
                    if (map[x, y] <= definition.Pictures.GetUpperBound(0) && definition.Pictures[map[x, y]] != null)
                    {
                        gr.DrawImageUnscaled(definition.Pictures[map[x, y]], x * 16, y * 16);
                    }
                }
            }

            if (selectedX != -1)
            {
                var pen = new Pen(new SolidBrush(Color.White));
                gr.DrawRectangle(pen, selectedX * 16, selectedY * 16, 16, 16);
            }

            this.Refresh();
        }

        public void ClearMap(byte tile)
        {
            for (int y = 0; y <= 15; y++)
            {
                for (int x = 0; x <= 15; x++)
                {
                    map[x, y] = tile;
                }
            }
        }

        public void ShowRoom()
        {
            DrawRoom(room);
            var items = new List<RoomItem>();
            items.Add(new RoomItem());
            items.AddRange(room.RoomItems);
            UIItems.DataSource = items;

            var creatures = new List<Creature>();
            var creature = new Creature();
            creature.InUse = false;
            creatures.Add(creature);
            creatures.AddRange(room.RoomCreatures);
            UIResidentCreatures.DataSource = creatures;

            if (room.RandomCreatureChance > 0)
            {
                UIRandomCreature.Text = region.RandomCreatures[room.RandomCreatureNumber].Name;
                UIAppearChance.Text = room.RandomCreatureChance.ToString() + "%";
            }
        }


        public void DrawRoom(Room room)
        {
            floorTile = (byte)definition.Things[126].Picture;
            wallPicture = room.WallPicture;
            ClearMap(floorTile);

            DrawHLine(0, 0, room.Width - 1, wallPicture, floorTile);
            DrawHLine(0, room.Height - 1, room.Width, wallPicture, floorTile);
            DrawVLine(0, 0, room.Height - 1, wallPicture, floorTile);
            DrawVLine(room.Width - 1, 0, room.Height, wallPicture, floorTile);

            foreach (RoomItem item in room.RoomItems)
            {
                if (map[item.XPosition, item.YPosition] == floorTile || map[item.XPosition, item.YPosition] == wallPicture)
                    map[item.XPosition, item.YPosition] = (byte)(item.Item.Picture);
            }

            foreach (Creature creature in room.RoomCreatures)
            {
                if (map[creature.XPosition, creature.YPosition] == floorTile || map[creature.XPosition, creature.YPosition] == wallPicture)
                    map[creature.XPosition, creature.YPosition] = (byte)(creature.Picture);
            }


            UpdateImage();
        }

        public void DrawHLine(int x1, int y1, int width, byte tile, byte floorTile)
        {
            for (int x = x1; x < x1 + width; x++) if (map[x, y1] == floorTile) map[x, y1] = tile;
        }

        public void DrawVLine(int x1, int y1, int height, byte tile, byte floorTile)
        {
            for (int y = y1; y < y1 + height; y++) if (map[x1, y] == floorTile) map[x1, y] = tile;
        }

        private void UIMap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0, 640, 640);
        }


        private void UIItems_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedItem = (RoomItem)UIItems.SelectedItem;
            if (selectedItem.Item == null)
            {
                selectedX = -1;
                selectedY = -1;
            }
            else
            {
                selectedX = selectedItem.XPosition;
                selectedY = selectedItem.YPosition;
            }
            UpdateImage();

            if (selectedItem.Item == null) return;
            var desc = selectedItem.Item.Description();

            UIInformation.Text = desc[0] + "\n";
            UIInformation.Text += desc[1] + "\n";
            UIInformation.Text += desc[2] + "\n";

            if (selectedItem.Item.TypeOfThing == Thing.ThingType.Portal)
            {
                string s = "";
                if (selectedItem.WorldMapDestination)
                {
                    s = string.Format("World map {0},{1}", selectedItem.PortalDestinationX, selectedItem.PortalDestinationY);
                }
                else
                {
                    s = s + definition.Regions[selectedItem.PortalDestinationRegion - 1].Name;
                    s = s + ":" + definition.Regions[selectedItem.PortalDestinationRegion - 1].Room(selectedItem.PortalDestinationRoom).Name;
                    s = s + string.Format(" ({0},{1})", selectedItem.PortalDestinationX, selectedItem.PortalDestinationY);
                }

                UIPortalDestination.Text = s;
            }


        }

        private void UIResidentCreatures_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedCreature = (Creature)UIResidentCreatures.SelectedItem;
            if (selectedCreature.InUse)
            {
                selectedX = selectedCreature.XPosition;
                selectedY = selectedCreature.YPosition;
            }
            else
            {
                selectedX = -1;
                selectedY = -1;
            }
            UpdateImage();
        }

        private void UIItems_DoubleClick(object sender, System.EventArgs e)
        {
            if (UIItems.SelectedItem == null) return;
            var ri = (RoomItem)UIItems.SelectedItem;

            var th = definition.Things[ri.ItemNumber - 1];

            var form = new ThingViewer();
            form.Thing = th;
            form.Definition = definition;
            form.MdiParent = this.MdiParent;
            form.ActionParameter = ri.Parameter;
            form.Show();
        }

        private void UIRandomCreature_DoubleClick(object sender, System.EventArgs e)
        {
            var form = new CreatureViewer();
            form.Definition = definition;
            form.Creature = region.RandomCreatures[room.RandomCreatureNumber];

            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void UIResidentCreatures_DoubleClick(object sender, System.EventArgs e)
        {
            var creature = (Creature)UIResidentCreatures.SelectedItem;
            var form = new CreatureViewer();
            form.Definition = definition;
            form.Creature = creature;
            form.Show();
        }



    }
}
