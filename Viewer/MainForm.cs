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
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AcsViewer
{
    public partial class MainForm : Form
    {
        GameDefinition definition;
        string fileName = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // LoadGame(@"F:\Data\roms\PC\acs\adven.hrd");
           //  var playForm = new PlayGame(fileName);
           //   playForm.Show();
        }

        private void UpdateTree()
        {
            TreeNode node, node2;

            UIItemTree.Nodes.Clear();

            node = UIItemTree.Nodes.Add("General");
            node2 = node.Nodes.Add("General Info");
            node2.Tag = "info";
            node2 = node.Nodes.Add("World Map");
            node2.Tag = "worldmap";
            node2 = node.Nodes.Add("Graphics");
            node2.Tag = "graphics";

            //Things
            node = UIItemTree.Nodes.Add("Things");
            var treasureNode = node.Nodes.Add("Treasure");
            var magicItemNode = node.Nodes.Add("Magic Item");
            var missileWeaponNode = node.Nodes.Add("Missile Weapon");
            var meleeWeaponNode = node.Nodes.Add("Melee Weapon");
            var armorNode = node.Nodes.Add("Armor");
            var magicSpellNode = node.Nodes.Add("Magic Spell");
            var portalNode = node.Nodes.Add("Portal");
            var spaceNode = node.Nodes.Add("Space");
            var customSpaceNode = node.Nodes.Add("Custom Space");
            var obstacleNode = node.Nodes.Add("Obstacle");
            var customObstacleNode = node.Nodes.Add("Custom Obstacle");
            var storeNode = node.Nodes.Add("Store");
            var roomFloorNode = node.Nodes.Add("Room Floor");

            foreach (Thing thing in definition.Things)
            {
                if (thing.TypeOfThing == Thing.ThingType.Undefined) continue;

                switch (thing.TypeOfThing)
                {
                    case Thing.ThingType.Treasure:
                        node2 = treasureNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.MagicItem:
                        node2 = magicItemNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.Armor:
                        node2 = armorNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.CustomObstacle:
                        node2 = customObstacleNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.CustomSpace:
                        node2 = customSpaceNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.MagicSpell:
                        node2 = magicSpellNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.MeleeWeapon:
                        node2 = meleeWeaponNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.MissileWeapon:
                        node2 = missileWeaponNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.Obstacle:
                        node2 = obstacleNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.Portal:
                        node2 = portalNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.Space:
                        node2 = spaceNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.Store:
                        node2 = storeNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;
                    case Thing.ThingType.RoomFloor:
                        node2 = roomFloorNode.Nodes.Add(thing.Name);
                        node2.Tag = thing;
                        break;

                }
            }

            //Creatures & Players
            node = UIItemTree.Nodes.Add("Creatures");
            foreach (Creature creature in definition.CreatureList)
            {
                if (!creature.InUse) continue;
                node2 = node.Nodes.Add(creature.Name);
                node2.Tag = creature;
            }

            if (definition.ActivePlayerCount > 0)
            {
                node = UIItemTree.Nodes.Add("Active Players");
                foreach (WorldMapCreature player in definition.ActivePlayers)
                {
                    node2 = node.Nodes.Add(player.Creature.Name);
                    node2.Tag = player;
                }
            }

            if (definition.RetiredPlayerCount > 0)
            {
                node = UIItemTree.Nodes.Add("Retired Players");
                foreach (WorldMapCreature player in definition.RetiredPlayers)
                {
                    node2 = node.Nodes.Add(player.Creature.Name);
                    node2.Tag = player;
                }
            }

            //Region
            node = UIItemTree.Nodes.Add("Regions");
            foreach (Region region in definition.Regions)
            {
                if (region != null)
                {
                    node2 = node.Nodes.Add(region.Name);
                    node2.Tag = region;
                }

            }

            //Terrain
            node = UIItemTree.Nodes.Add("Terrain");
            for (int i = 0; i < 16; i++)
            {
                if (definition.TerrainTypes[i] == null) continue;
                node2 = node.Nodes.Add(definition.TerrainTypes[i].Name);
                node2.Tag = definition.TerrainTypes[i];
            }

            // World map creatures
            node = UIItemTree.Nodes.Add("World Map Creatures");
            for (int i = 0; i < 8; i++)
            {
                //node2 = node.Nodes.Add(definition.WorldMapCreatures[i].Creature.Name + " OF " + definition.TerrainTypes[definition.WorldMapCreatures[i].AppearingInTerrain].Name);
                node2 = node.Nodes.Add(definition.WorldMapCreatures[i].Creature.Name + " OF " + definition.WorldMapCreatures[i].AppearingIn);
                node2.Tag = definition.WorldMapCreatures[i];
            }
        }

        private void itmLoad_Click(object sender, EventArgs e)
        {
            var Odialog = new OpenFileDialog();
            string filter = "Amiga files (*.*)|*.*|Amiga disk files (*.adf)|*.adf|" +
                "Apple files (*.dsk)|*.dsk|Commodore files (*.d64)|*.d64|" + 
                "PC files (*.fpy;*.hrd)|*.fpy;*.hrd";
            Odialog.Filter = filter;
            Odialog.Title = "Open ACS Adventure";
            if (Odialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = Odialog.FileName;
                string shortFileName = Path.GetFileName(fileName);
                string ext = Path.GetExtension(fileName);
                if (ext == ".adf")
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "ACS Viewer needs to extract a file from inside " +
                            shortFileName+" using UAUNP. Proceed?", 
                        "ACS Viewer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string saveFile = "Amiga_" + 
                            Path.GetFileNameWithoutExtension(fileName);
                        var Sdialog = new SaveFileDialog
                        {
                            Filter = "Amiga files |",
                            FileName = saveFile,
                            Title = "Extract ACS Adventure from " + shortFileName
                        };
                        Sdialog.ShowDialog();
                        saveFile = Sdialog.FileName;
                        if (saveFile == "") return;

                        if (ExtractFromADF(fileName, saveFile))
                        {
                            if (TestFile(saveFile)) {
                                LoadGame(saveFile);
                            }
                            else
                            {
                                MessageBox.Show("Not an ACS adventure.", "ACS Viewer",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    return;
                }
                else
                {
                    if (TestFile(fileName))
                    {
                        LoadGame(fileName);
                    }
                    else
                    {
                        MessageBox.Show("Not an ACS adventure.", "ACS Viewer",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    LoadGame(fileName);
                }
            }
        }

        private bool TestFile(string file)
        {
            // This method tests to see if a file contains an ACS adventure.
            //  It won't work on Apple files, because those have no data shared
            //  between all adventures.
            string ext = Path.GetExtension(file);
            if (ext == ".dsk")
                return true;

            int addr = 0x54C8;
            // Change the address for Amiga adventures.
            if (ext == "") 
                addr = 0x4EC8;

            bool result = true;
            int _length = 100;
            try
            {
                System.IO.FileInfo info = new FileInfo(file);
                _length = (int)info.Length;

                if (_length < addr + 20)
                {
                    result = false;
                }
            }
            catch (Exception FileException)
            {
                MessageBox.Show(FileException.Message, "ACS Viewer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            if (result == false)
                return false;

            try { 
                byte[] buff = new Byte[_length];
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        buff = br.ReadBytes(_length);
                    }
                }
                byte[] data = new Byte[20];

                for (int i = 0; i < 20; i++) data[i] = buff[addr++];

                // ACS ADVENTURE SYSTEM
                byte[] comp = new byte[20]
                    { 0x01, 0x03, 0x13, 0x20, 0x01, 
                      0x04, 0x16, 0x05, 0x0E, 0x14, 
                      0x15, 0x12, 0x05, 0x20, 0x13, 
                      0x19, 0x13, 0x14, 0x05, 0x0D };

                if (Enumerable.SequenceEqual(data, comp))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception FileException)
            {
                MessageBox.Show(FileException.Message, "ACS Viewer", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }

        private void LoadGame(string file)
        {
            GameLoader loader = new GameLoader();
            definition = loader.LoadGame(file);
            fileName = file;
            UpdateTree();
            //this.Text = file;
            this.Text = definition.Name;
        }

        public bool ExtractFromADF(string fileName, string saveFile)
        {
            /* The UAE Unpacker is a command line tool,
             *   associated with the WinUAE Amiga emulator.
             * It was written by Toni Wilen.
             * Its current version is 0.8f and it is (c)2012.
             * 
             * WinUAE (and UAE in general) is released under the 
             *   GNU General Public License.
             */
            /* UAUNP arguments: 
             *    1. ADF file to use
             *    2. Operation to perform (-x for extract files)
             *    3. First argument for operation (for -x, name of file to extract)
             *    4. Optional second argument for operation (for -x, name to save file as)
             */
            string arg = "/c uaeunp " + fileName + " -x Adventure " + saveFile;
            try
            {
                System.Diagnostics.ProcessStartInfo PCI =
                    new System.Diagnostics.ProcessStartInfo("cmd", arg)
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                System.Diagnostics.Process proc = new System.Diagnostics.Process
                {
                    StartInfo = PCI
                };
                proc.Start();

                string result = proc.StandardOutput.ReadToEnd();
                if (result.Contains("extracted, 164608 bytes"))
                {
                    MessageBox.Show(saveFile + " extracted successfully", "UAEUNP",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show(result, "UAEUNP", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message, "UAEUNP",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UIItemTree_DoubleClick(object sender, EventArgs e)
        {
            if (UIItemTree.SelectedNode == null || UIItemTree.SelectedNode.Tag == null) return;

            if (UIItemTree.SelectedNode.Tag is string)
            {
                var t = (string)UIItemTree.SelectedNode.Tag;

                switch (t)
                {
                    case "graphics":
                        var grViewer = new GraphicsViewer
                        {
                            MdiParent = this,
                            Definition = definition
                        };
                        grViewer.Show();
                        grViewer.UpdateSelectedGraphic();
                        break;
                    case "worldmap":
                        var mapViewer = new MapViewer
                        {
                            MdiParent = this,
                            Definition = definition
                        };
                        mapViewer.Show();
                        mapViewer.UpdateMap();
                        break;
                    case "info":
                        var infoViewer = new InfoViewer
                        {
                            MdiParent = this,
                            Definition = definition
                        };
                        infoViewer.Show();
                        break;
                }

            }

            if (UIItemTree.SelectedNode.Tag is Thing)
            {
                ThingViewer form = new ThingViewer
                {
                    MdiParent = this,
                    Definition = definition,
                    Thing = (Thing)UIItemTree.SelectedNode.Tag
                };
                form.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is Creature)
            {
                CreatureViewer creatForm = new CreatureViewer
                {
                    Definition = definition,
                    MdiParent = this,
                    Creature = (Creature)UIItemTree.SelectedNode.Tag
                };
                creatForm.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is WorldMapCreature)
            {
                CreatureViewer creatForm = new CreatureViewer
                {
                    Definition = definition,
                    MdiParent = this,
                    MapCreature = (WorldMapCreature)UIItemTree.SelectedNode.Tag
                };
                creatForm.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is Region)
            {
                RegionViewer regform = new RegionViewer
                {
                    MdiParent = this,
                    Definition = definition,
                    DisplayRegion = (Region)UIItemTree.SelectedNode.Tag
                };
                regform.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is Terrain)
            {
                TerrainViewer terrainForm = new TerrainViewer
                {
                    MdiParent = this,
                    Definition = definition,
                    Terrain = (Terrain)UIItemTree.SelectedNode.Tag
                };
                terrainForm.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is WorldMapCreature)
            {
                CreatureViewer creatureForm = new CreatureViewer
                {
                    Definition = definition,
                    MdiParent = this,
                    MapCreature = (WorldMapCreature)UIItemTree.SelectedNode.Tag
                };
                creatureForm.Show();
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileName)) return;

            MessageBox.Show("Play mode is only preliminary. Currently you can only walk around the map.");
            var playForm = new PlayGame(fileName);
            playForm.Show();
        }
    }
}
