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

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AcsLib;

namespace AcsViewer
{
    public partial class MapViewer : Form
    {
        private Bitmap bmp = new Bitmap(640, 640);
        private int selectedX = -1;
        private int selectedY = -1;
        private int picWidth = 16;
        private int picHeight = 16;

        public GameDefinition Definition { get; set; }

        private WorldMapPortal selectedPortal = null;

        public MapViewer()
        {
            InitializeComponent();

            int buttonNumber = 0;
            var button = new Button();           
            button.Name = "Button_" + buttonNumber.ToString();
            button.Top = 100;
            button.Left = 100;
            button.Text = "Button";         
        }

        public void UpdateMap()
        {
            if (Definition.System == GameDefinition.SystemType.Apple)
            {
                picWidth = 14;
            }
            Graphics gr = Graphics.FromImage(bmp);
            for (int y = 0; y < 40; y++)
            {
                for (int x = 0; x < 40; x++)
                {
                    int tile = Definition.TerrainTypes[Definition.WorldMap[x, y] ].Picture;
                    gr.DrawImageUnscaled(Definition.Pictures[tile], x * picWidth, y * picHeight);
                }
            }

            var pen = new Pen(new SolidBrush(Color.White));

            if (selectedPortal != null && (selectedPortal.TypeOfPortal == WorldMapPortal.PortalType.RoomDestination || selectedPortal.TypeOfPortal ==  WorldMapPortal.PortalType.WorldMapDestination))
            {
                gr.DrawRectangle(pen, selectedPortal.XPosition * picWidth, selectedPortal.YPosition * picHeight, picWidth, picHeight);

                if (selectedPortal.TypeOfPortal == WorldMapPortal.PortalType.WorldMapDestination)
                {
                    pen = new Pen(new SolidBrush(Color.Yellow));
                    gr.DrawRectangle(pen, selectedPortal.MapDestinationX * picWidth, selectedPortal.MapDestinationY * picHeight, picWidth, picHeight);
                }
            }

            pen = new Pen(new SolidBrush(Color.Cyan));
            gr.DrawRectangle(pen, Definition.WorldMapStartX * picWidth, Definition.WorldMapStartY * picHeight, picWidth, picHeight);

            // Place players
            foreach (WorldMapCreature Player in Definition.WorldMapPlayers)
            {
                int tile = Player.Creature.Picture;
                gr.DrawImageUnscaled(Definition.Pictures[tile],
                    Player.Creature.XPosition * picWidth,
                    Player.Creature.YPosition * picHeight);
            }
            // outline the selected player
            if (selectedX != -1)
            {
                pen = new Pen(new SolidBrush(Color.White));
                gr.DrawRectangle(pen, selectedX * picWidth, selectedY * picHeight, picWidth, picHeight);
            }

            this.Refresh();
        }


        private void UIMap_Paint(object sender, PaintEventArgs e)
        { 
            e.Graphics.DrawImage(bmp, 0, 0, 640,640);
        }

        private void UIPortalNumber_ValueChanged(object sender, System.EventArgs e)
        {
            ShowMap();
        }

        private void ShowMap()
        {
            selectedPortal = Definition.WorldMapPortals[(int)UIPortalNumber.Value];

            switch (selectedPortal.TypeOfPortal)
            {
                case WorldMapPortal.PortalType.NotUsed:
                    UIDestination.Text = "Not in use";
                    break;
                case WorldMapPortal.PortalType.RoomDestination:
                    if (Definition.Regions[selectedPortal.DestinationRegion - 1] != null)
                        UIDestination.Text = string.Format("Region {0}, Room {1}, {2},{3}", Definition.Regions[selectedPortal.DestinationRegion - 1]
                                                                                          , Definition.Regions[selectedPortal.DestinationRegion - 1].Rooms[selectedPortal.DestinationRoom]
                                                                                          , selectedPortal.RoomDestinationX, selectedPortal.RoomDestinationY);
                    break;
                case WorldMapPortal.PortalType.WorldMapDestination:
                    UIDestination.Text = string.Format("World Map {0},{1}", selectedPortal.MapDestinationX, selectedPortal.MapDestinationY);
                    break;
                case WorldMapPortal.PortalType.Destination:
                    UIDestination.Text = "Room portal destination";
                    break;
            }

            var players = new List<WorldMapCreature>();
            Creature cr = new Creature
            {
                InUse = false
            };
            WorldMapCreature player = new WorldMapCreature
            {
                Creature = cr
            };
            players.Add(player);
            players.AddRange(Definition.WorldMapPlayers);
            UIPlayers.DataSource = players;

            UpdateMap();
        }

        private void MapViewer_Load(object sender, System.EventArgs e)
        {
            ShowMap();
            UIMapName.Text = Definition.WorldMapName;
            UIMapWrap.Text = Definition.WorldMapWrapTypeDescription;
            if (UIPlayers.Items.Count == 1)
            {
                UIPlayers.Visible = false;
                this.Width = 667;
            }
            else
            {
                UIPlayers.Visible = true;
                this.Width = 819;
            }
        }
        private void UIPlayers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedPlayer = (WorldMapCreature)UIPlayers.SelectedItem;
            var selectedCreature = (Creature)selectedPlayer.Creature;
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
            UpdateMap();
        }
        private void UIPlayers_DoubleClick(object sender, System.EventArgs e)
        {
            if (selectedX == -1) return;
            var wmc = (WorldMapCreature)UIPlayers.SelectedItem;
            var form = new CreatureViewer
            {
                Definition = Definition,
                MapCreature = wmc
            };
            form.Show();
        }
    }
}
