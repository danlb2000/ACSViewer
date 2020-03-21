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

using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AcsLib;
using System.Collections.Generic;

namespace AcsViewer
{
    public partial class RoomViewer : Form
    {
        private Bitmap bmp = new Bitmap(256, 256);
        // map[] dimensions are x, y, and a.
        // a=0 for picture # to display.
        // a=1 for flag: 0=empty, 1=occupied.
        // a=2 for thing # of top item
        private byte[,,] map = new byte[16, 16, 3];
        private int selectedX = -1;
        private int selectedY = -1;
        private int picWidth = 16;
        private int picHeight = 16;


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
            if (this.definition.System == GameDefinition.SystemType.Apple)
            {
                picWidth = 14;
            }
            this.Text = room.Name;
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
                    if (map[x, y, 0] <= definition.Pictures.GetUpperBound(0) && definition.Pictures[map[x, y, 0]] != null)
                    {
                        gr.DrawImageUnscaled(definition.Pictures[map[x, y, 0]], x * picWidth, y * picHeight);
                    }
                }
            }

            if (selectedX != -1)
            {
                var pen = new Pen(new SolidBrush(Color.White));
                gr.DrawRectangle(pen, selectedX * picWidth, selectedY * picHeight, picWidth, picHeight);
            }

            this.Refresh();
        }

        public void ClearMap(byte tile)
        {
            for (int y = 0; y <= 15; y++)
            {
                for (int x = 0; x <= 15; x++)
                {
                    map[x, y, 0] = tile;
                    map[x, y, 1] = 0; // unoccupied
                    map[x, y, 2] = 127; // Room Floor
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
            players.AddRange(room.RoomPlayers);
            UIPlayers.DataSource = players;

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
                //if (map[item.XPosition, item.YPosition] == floorTile || map[item.XPosition, item.YPosition] == wallPicture)
                if (map[item.XPosition, item.YPosition, 1] == 0)
                {
                    map[item.XPosition, item.YPosition, 0] = (byte)(item.Item.Picture);
                    map[item.XPosition, item.YPosition, 1] = 1; // occupied
                    map[item.XPosition, item.YPosition, 2] = item.ItemNumber;
                }

            }

            foreach (Creature creature in room.RoomCreatures)
            {
                //if (map[creature.XPosition, creature.YPosition] == floorTile || map[creature.XPosition, creature.YPosition] == wallPicture)
                if (map[creature.XPosition, creature.YPosition, 1] == 0)
                {
                    map[creature.XPosition, creature.YPosition, 0] = (byte)(creature.Picture);
                    map[creature.XPosition, creature.YPosition, 1] = 1; // occupied
                }
            }

            foreach (WorldMapCreature player in room.RoomPlayers)
            {
                Creature cr = player.Creature;
                map[cr.XPosition, cr.YPosition, 0] = (byte)(cr.Picture);
                map[cr.XPosition, cr.YPosition, 1] = 1; // occupied
            }


            UpdateImage();
        }

        public void DrawHLine(int x1, int y1, int width, byte tile, byte floorTile)
        {
            for (int x = x1; x < x1 + width; x++) if (map[x, y1, 0] == floorTile) map[x, y1, 0] = tile;
        }

        public void DrawVLine(int x1, int y1, int height, byte tile, byte floorTile)
        {
            for (int y = y1; y < y1 + height; y++) if (map[x1, y, 0] == floorTile) map[x1, y, 0] = tile;
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
            //var desc = selectedItem.Item.Description();

            //UIInformation.Text = desc[0] + "\n";
            //UIInformation.Text += desc[1] + "\n";
            //UIInformation.Text += desc[2] + "\n";

            if(selectedItem.Item.ChooseWhenPutIntoRoom == AcsLib.Thing.ChooseWhenPutIntoRoomType.SpellModifier && 
                selectedItem.Item.Action.TypeOfSpellAction == SpellAction.SpellActionType.DisplayMessage)
            {
                UIText.Visible = true;
                UIInformation.Visible = false;
                lblRandomCreature.Visible = false;
                lblAppearChance.Visible = false;
                UIPortalDest.Visible = false;
                UIRandomCreature.Visible = false;
                UIAppearChance.Visible = false;
                UIPortalDestination.Visible = false;
                UIStoreItems.Visible = false;
                byte param = selectedItem.Parameter;
                if (param > 0)
                {
                    string Message = definition.LongMessages[param - 1];
                    UIText.Text = Message.Substring(0, 32);
                    for (int i = 1; i < 8; i++)
                    {
                        UIText.AppendText("\r\n" + Message.Substring(i * 32, 32));
                    }
                }
                return;
            }

            UIText.Visible = false;
            if (selectedItem.Item.TypeOfThing != Thing.ThingType.Store)
            {
                UIInformation.Visible = true;
                lblRandomCreature.Visible = true;
                lblAppearChance.Visible = true;
                UIPortalDest.Visible = true;
                UIRandomCreature.Visible = true;
                UIAppearChance.Visible = true;
                UIPortalDestination.Visible = true;
                UIStoreItems.Visible = false;
            }
            UIInformation.Text = "";
            string descFormat = selectedItem.Item.GetUsageDescription();
            if (descFormat.Length > 0)
            {
                byte param = selectedItem.Parameter;
                string descText = "";
                if (selectedItem.Item.ChooseWhenPutIntoRoom == AcsLib.Thing.ChooseWhenPutIntoRoomType.Object)
                {
                    descText = definition.Things[param - 1].Name;
                }
                if (selectedItem.Item.ChooseWhenPutIntoRoom == AcsLib.Thing.ChooseWhenPutIntoRoomType.SpellModifier)
                {
                    switch (selectedItem.Item.Action.ParameterType)
                    {
                        case SpellAction.ActionParameterType.Music:
                            Music mus = new Music();
                            descText = mus.GetMusicName(param);
                            break;
                        case SpellAction.ActionParameterType.Item:
                            descText = definition.Things[param - 1].Name;
                            break;
                        case SpellAction.ActionParameterType.VictimStat:
                            descText = Enum.ToObject(typeof(Creature.Stat), param).ToString();
                            break;
                        case SpellAction.ActionParameterType.ChangeLifeForcePower:
                            int n = param & 0x3F;
                            if (param.BitField(7)) n = -n;
                            descText = n.ToString();
                            if (param.BitField(6))
                                descText += " Temporarily";
                            else
                                descText += " Permanently";
                            break;
                        case SpellAction.ActionParameterType.Creature:
                            if (param == 0)
                            {
                                descFormat = "Banish all creatures in room";
                            }
                            else
                            {
                                descFormat = "Summon creature {0} - {1}";
                                descText = definition.CreatureList[param - 1].Name;
                            }
                            break;
                    }
                }
                UIInformation.Text = string.Format(CultureInfo.CurrentCulture, descFormat, param, descText);
            }

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

            if (selectedItem.Item.TypeOfThing == Thing.ThingType.Store)
            {
                UIInformation.Visible = false;
                lblRandomCreature.Visible = false;
                lblAppearChance.Visible = false;
                UIPortalDest.Visible = false;
                UIRandomCreature.Visible = false;
                UIAppearChance.Visible = false;
                UIPortalDestination.Visible = false;
                UIStoreItems.Visible = true;
                UIStoreItems.Items.Clear();
                for (int i = 0; i < 81; i++)
                {
                    if (region.StoreItems[i] != 0)
                    {
                        string s = "(" + region.StoreItems[i].ToString() + ") " + definition.Things[i - 1].Name;
                        UIStoreItems.Items.Add(s);
                    }
                }
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
            UpdateImage();
        }

        private void UIItems_DoubleClick(object sender, System.EventArgs e)
        {
            if (selectedX == -1) return;
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
            if (UIRandomCreature.TextLength == 0) return;
            var form = new CreatureViewer();
            form.Definition = definition;
            WorldMapCreature MapCreature = new WorldMapCreature();
            MapCreature.Creature = region.RandomCreatures[room.RandomCreatureNumber];
            MapCreature.AppearingIn = room.Name;
            MapCreature.ChanceAppearing = room.RandomCreatureChance;
            //form.Creature = region.RandomCreatures[room.RandomCreatureNumber];
            form.MapCreature = MapCreature;

            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void UIResidentCreatures_DoubleClick(object sender, System.EventArgs e)
        {
            if (selectedX == -1) return;
            var creature = (Creature)UIResidentCreatures.SelectedItem;
            var form = new CreatureViewer();
            form.Definition = definition;
            WorldMapCreature MapCreature = new WorldMapCreature();
            MapCreature.Creature = creature;
            MapCreature.AppearingIn = room.Name;
            MapCreature.ChanceAppearing = (byte)100;
            //form.Creature = creature;
            form.MapCreature = MapCreature;
            form.Show();
        }

        private void UIPlayers_DoubleClick(object sender, System.EventArgs e)
        {
            if (selectedX == -1) return;
            var wmc = (WorldMapCreature)UIPlayers.SelectedItem;
            var form = new CreatureViewer();
            form.Definition = definition;
            form.MapCreature = wmc;
            form.Show();
        }


    }
}
