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

            //Creatures
            node = UIItemTree.Nodes.Add("Creatures");
            foreach (Creature creature in definition.CreatureList)
            {
                if (!creature.InUse) continue;
                node2 = node.Nodes.Add(creature.Name);
                node2.Tag = creature;
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
                node2 = node.Nodes.Add(definition.WorldMapCreatures[i].Creature.Name + " OF " + definition.TerrainTypes[definition.WorldMapCreatures[i].AppearingInTerrain].Name);
                node2.Tag = definition.WorldMapCreatures[i];
            }
        }

        private void itmLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) LoadGame(dialog.FileName);
        }

        private void LoadGame(string file)
        {
            GameLoader loader = new GameLoader();
            definition = loader.LoadGame(file);
            fileName = file;
            UpdateTree();
            this.Text = file;
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
                        var grViewer = new GraphicsViewer();
                        grViewer.MdiParent = this;
                        grViewer.Definition = definition;
                        grViewer.Show();
                        grViewer.UpdateDisplay();
                        break;
                    case "worldmap":
                        var mapViewer = new MapViewer();
                        mapViewer.MdiParent = this;
                        mapViewer.Definition = definition;
                        mapViewer.Show();
                        mapViewer.UpdateMap();
                        break;
                    case "info":
                        var infoViewer = new InfoViewer();
                        infoViewer.MdiParent = this;
                        infoViewer.Definition = definition;
                        infoViewer.Show();
                        break;
                }

            }

            if (UIItemTree.SelectedNode.Tag is Thing)
            {
                ThingViewer form = new ThingViewer();
                form.MdiParent = this;
                form.Definition = definition;
                form.Thing = (Thing)UIItemTree.SelectedNode.Tag;
                form.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is Creature)
            {
                CreatureViewer creatForm = new CreatureViewer();
                creatForm.Definition = definition;
                creatForm.MdiParent = this;
                creatForm.Creature = (Creature)UIItemTree.SelectedNode.Tag;
                creatForm.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is Region)
            {
                RegionViewer regform = new RegionViewer();
                regform.MdiParent = this;
                regform.Definition = definition;
                regform.DisplayRegion = (Region)UIItemTree.SelectedNode.Tag;
                regform.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is Terrain)
            {
                TerrainViewer terrainForm = new TerrainViewer();
                terrainForm.MdiParent = this;
                terrainForm.Definition = definition;
                terrainForm.Terrain = (Terrain)UIItemTree.SelectedNode.Tag;
                terrainForm.Show();
            }
            else if (UIItemTree.SelectedNode.Tag is WorldMapCreature)
            {
                CreatureViewer creatureForm = new CreatureViewer();
                creatureForm.Definition = definition;
                creatureForm.MdiParent = this;
                creatureForm.MapCreature = (WorldMapCreature)UIItemTree.SelectedNode.Tag;
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
