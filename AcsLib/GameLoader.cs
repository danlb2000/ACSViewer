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
using System.Linq;

namespace AcsLib
{
    public class GameLoader
    {

        private const int PC_OFFSET = 0x00;
        private const int C64_OFFSET = 0x200;

        BinaryFile file;
        private Brush[] palette = new Brush[17];
        int[] colorLookup = new Int32[4];


        public GameDefinition LoadGame(string fileName)
        {
            GameDefinition definition = new GameDefinition();

            string extension = System.IO.Path.GetExtension(fileName);
            file = new BinaryFile();

            if (extension.ToUpper(CultureInfo.CurrentCulture) == ".D64")
            {
                definition.TypeOfFile = GameDefinition.FileType.C64;
                file.Offset = C64_OFFSET;
            }
            else
            {
                definition.TypeOfFile = GameDefinition.FileType.PC;
                file.Offset = PC_OFFSET;
            }

            file.Load(fileName);

            LoadFinishGameNames(definition);

            LoadThings(definition);

            if (definition.TypeOfFile == GameDefinition.FileType.PC)
                LoadPicturesPC(definition);
            else
                LoadPicturesC64(definition);

            LoadGameInfo(definition);
            LoadTerrain(definition);
            LoadWorldMap(definition);
            LoadWorldMapPortals(definition);
            LoadWorldMapCreatures(definition);
            LoadRegions(definition);

            LoadClassNames(definition);
            LoadMasterCreatures(definition);
            LoadLongMessages(definition);

            return definition;
        }

        private void LoadFinishGameNames(GameDefinition definition)
        {
            int start = 0x4B00;

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    var dat = file.ReadBlock(start + (i * 20), 20);
                    definition.FinishGameNames.Add(TextDecoder.DecodeAscii(dat));
                }
                start += 0x100;

            }

        }

        private void LoadWorldMapCreatures(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            for (int i = 0; i < 8; i++)
            {
                definition.WorldMapCreatures[i] = new WorldMapCreature();
                definition.WorldMapCreatures[i].Creature = LoadCreature((int)(0x1CE52 + i * 10), 0, (int)(0x1CB0A + i * 37));
                definition.WorldMapCreatures[i].AppearingInTerrain = file.ReadByte(0x1CD5A + i).Field(4, 7);
                int chance = file.ReadByte(0x1CD5A + i).Field(0, 3);
                if (chance < 5)
                    chance *= 2;
                else
                    chance = (chance - 3) * 5;
                definition.WorldMapCreatures[i].ChanceAppearing = (byte)chance;

            }
        }

        private void LoadGameInfo(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            definition.Name = TextDecoder.DecodeAscii(file.ReadBlock(0x1C200, 0x13)).TrimEnd();
            definition.Byline = TextDecoder.DecodeAscii(file.ReadBlock(0x1C214, 0x13)).TrimEnd();
            definition.IntroText = TextDecoder.DecodeAscii(file.ReadBlock(0x16A00, 256));
        }

        private void LoadLongMessages(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            for (int i = 0; i < 80; i++)
            {
                var msg = file.ReadBlock(0x6C00 + (i * 256), 256);
                definition.LongMessages[i] = TextDecoder.DecodeAscii(msg);
            }
        }

        #region "Things"

        private void LoadThings(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            byte b;
            byte[] name;

            for (int thingNum = 0; thingNum < 128; thingNum++)
            {
                Thing thing = new Thing();
                thing.Number = thingNum + 1;

                //Name
                name = file.ReadBlock(0x1B800 + (thingNum * 10), 10);
                thing.Name = TextDecoder.DecodePacked(name).Trim();

                // Common Properties 
                b = file.ReadByte(0x1BD00 + thingNum * 4);

                thing.TypeOfThing = (Thing.ThingType)(b.Field(0, 3));
                thing.DisappearsAfterUser = b.BitField(4);

                // How many ACS can add
                b = file.ReadByte(0x1C000 + thingNum);
                thing.AcsMayAdd = b.Field(4, 7);
                switch (thing.TypeOfThing)
                {
                    case Thing.ThingType.RoomFloor:
                    case Thing.ThingType.Store:
                        thing.Picture = file.ReadByte(0x1BD00 + thingNum * 4 + 1);
                        break;
                    case Thing.ThingType.Treasure:
                        thing.Picture = file.ReadByte(0x1BD00 + thingNum * 4 + 3);
                        LoadThingWeightValue(thing);
                        break;
                    case Thing.ThingType.MagicItem:
                        LoadMagicItem(thing);
                        break;
                    case Thing.ThingType.MeleeWeapon:
                    case Thing.ThingType.MissileWeapon:
                    case Thing.ThingType.Armor:
                        LoadWeaponArmor(thing);
                        LoadThingWeightValue(thing);
                        break;

                    case Thing.ThingType.MagicSpell:
                        LoadMagicSpell(thing);
                        break;
                    case Thing.ThingType.Portal:
                        LoadPortal(thing);
                        break;
                    case Thing.ThingType.Space:
                        LoadSpace(thing);
                        break;
                    case Thing.ThingType.CustomSpace:
                        LoadCustomSpace(thing);
                        break;
                    case Thing.ThingType.Obstacle:
                        LoadObstacle(thing);
                        break;
                    case Thing.ThingType.CustomObstacle:
                        LoadCustomObstacle(thing);
                        break;
                }

                definition.Things.Add(thing);
            }

        }

        public void LoadCustomSpace(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int address = 0x1BD00 + (thing.Number - 1) * 4;
            byte[] data = file.ReadBlock(address, 4);

            if (data[0x00].BitField(7))
                thing.ChooseWhenPutIntoRoom = Thing.ChooseWhenPutIntoRoomType.SpellModifier;
            else
                thing.ChooseWhenPutIntoRoom = Thing.ChooseWhenPutIntoRoomType.Object;

            thing.Picture = data[0x01].Field(0, 5);
            thing.CustomSpaceAccess = (Thing.CustomSpaceAccessType)(data[0x01].Field(6, 7));
            thing.Action.TypeOfSpellAction = (SpellAction.SpellActionType)data[0x02].Field(0, 3);

            thing.DestroyThingNeededToMove = data[0x03].BitField(7);

            if (thing.ChooseWhenPutIntoRoom == Thing.ChooseWhenPutIntoRoomType.Object)
            {
                thing.Action.Parameter = data[0x03].Field(0,6);
            }
            else if (thing.ChooseWhenPutIntoRoom == Thing.ChooseWhenPutIntoRoomType.SpellModifier)
            {
                thing.PortalActionParameter = data[0x03].Field(0, 6);
            }

            thing.WhyCannotPassMessage = LoadMessage(thing, 0);
            thing.SpellCastMessage = LoadMessage(thing, 1);
        }

        public void LoadSpace(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int address = 0x1BD00 + (thing.Number - 1) * 4;

            byte b = file.ReadByte(address + 1);
            thing.Picture = b.Field(0, 5);

            LoadOpenToProperties(thing);

            thing.WhyCannotPassMessage = LoadMessage(thing, 0);
            thing.SpellCastMessage = LoadMessage(thing, 1);
        }

        public void LoadObstacle(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int address = 0x1BD00 + (thing.Number - 1) * 4;
            byte[] data = file.ReadBlock(address, 4);

            thing.Picture = data[1].Field(0, 5);
            thing.BumpAction = Thing.BumpActionType.Closed;
            if (data[1].BitField(6)) thing.BumpAction = Thing.BumpActionType.InvokeSpell;
            thing.Action.TypeOfSpellAction = (SpellAction.SpellActionType)data[2].Field(0, 3);
            thing.Action.Parameter = data[3];

            thing.WhyCannotPassMessage = LoadMessage(thing, 0);
            thing.SpellCastMessage = LoadMessage(thing, 1);
        }

        public void LoadCustomObstacle(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int address = 0x1BD00 + (thing.Number - 1) * 4;
            byte[] data = file.ReadBlock(address, 4);

            thing.ChooseWhenPutIntoRoom = Thing.ChooseWhenPutIntoRoomType.SpellModifier;
            thing.Picture = data[1].Field(0, 5);
            thing.Action.TypeOfSpellAction = (SpellAction.SpellActionType)data[2].Field(0, 3);

            thing.SpellCastMessage = LoadMessage(thing, 1);
        }

        public void LoadMagicSpell(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            thing.HasPicture = false;
            thing.Picture = 0;

            int address = 0x1BD00 + (thing.Number - 1) * 4;
            thing.Power = (int)file.ReadByte(address + 1);
            byte b = file.ReadByte(address + 2);
            thing.Action.TypeOfSpellAction = (SpellAction.SpellActionType)(b.Field(0, 3));
            thing.Action.Parameter = (byte)file.ReadByte(address + 3);

            thing.SpellCastMessage = LoadMessage(thing, 1);
        }

        public void LoadMagicItem(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            byte b;
            int index = file.ReadByte(0x1BD00 + (thing.Number - 1) * 4 + 3);

            int offset = file.ReadByte(0x1C082);
            int address = 0x1C084 + offset + (index * 3);
            b = file.ReadByte(address);
            thing.Action.TypeOfSpellAction = (SpellAction.SpellActionType)(b.Field(0, 3));
            thing.InvokedWhenOwnerUsesItem = b.BitField(7);
            thing.Action.Parameter = file.ReadByte(address + 2);
            b = file.ReadByte(address + 1);
            thing.Picture = (byte)(b.Field(0, 5));
            thing.InvokedWhenItemIsDropped = b.BitField(6);
            thing.InvokedWhenItemIsPickedUp = b.BitField(7);

            thing.SpellCastMessage = LoadMessage(thing, 1);
            LoadThingWeightValue(thing);
        }

        private string LoadMessage(Thing thing, int whichMessage)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            bool show = false;

            // Load message
            int address = 0x1BF00 + (thing.Number - 1) + (whichMessage * 0x80);
            byte b = file.ReadByte(address);
            show = !b.BitField(7);
            int messageIndex = b.Field(0, 6);
            if (messageIndex == 0) show = false;

            if (show)
            {
                messageIndex -= 1;
                address = 0x16B00 + ((((messageIndex & 0x7E) >> 1) * 0x100) + (messageIndex & 0x01) * 0x78);
                byte[] msg = file.ReadBlock(address, 120);
                return TextDecoder.DecodeAscii(msg);
            }

            return "";
        }

        public void LoadPortal(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int address = 0x1BD00 + (thing.Number - 1) * 4;
            byte b = file.ReadByte(address);
            thing.OneWayPortal = !b.BitField(5);
            b = file.ReadByte(address + 1);
            thing.Picture = b.Field(0, 5);
            LoadOpenToProperties(thing);
            b = file.ReadByte(address + 2);
            thing.DestroyThingNeededToMove = b.BitField(7);

            int address2 = 0x1BF00 + (thing.Number - 1);
            b = file.ReadByte(address2);

            thing.WhyCannotPassMessage = LoadMessage(thing, 0);
        }

        public void LoadOpenToProperties(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int address = 0x1BD00 + (thing.Number - 1) * 4;
            byte b = file.ReadByte(address + 1);

            thing.PortalAccess = (Thing.PortalAccessType)b.Field(6, 7);
            switch (thing.PortalAccess)
            {
                case Thing.PortalAccessType.InvokeSpell:
                    thing.Action.TypeOfSpellAction = (SpellAction.SpellActionType)file.ReadByte(address + 2);
                    thing.Action.Parameter = file.ReadByte(address + 3);
                    break;
                case Thing.PortalAccessType.SpecificItem:
                case Thing.PortalAccessType.DoNotOwn:
                    thing.PortalActionParameter = file.ReadByte(address + 3);
                    break;
            }
        }

        public void LoadWeaponArmor(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int index = file.ReadByte(0x1BD00 + (thing.Number - 1) * 4 + 3);
            int address = 0x1C084 + index * 3;
            byte[] bb = file.ReadBlock(address, 3);

            thing.ChanceOfBreaking = bb[1].Field(0, 3);

            if (thing.TypeOfThing == Thing.ThingType.MissileWeapon)
            {
                thing.Range = bb[0].Field(5, 7) + 2;
                thing.Power = bb[0].Field(0, 3);
            }
            else
            {
                thing.Power = bb[0].Field(0, 4);
            }

            if (thing.TypeOfThing == Thing.ThingType.Armor)
                thing.AttackAdjustment = -65 + (bb[1].Field(4, 7) * 5);
            else
                thing.AttackAdjustment = -35 + (bb[1].Field(4, 7) * 5);

            thing.Picture = bb[2].Field(0, 5);
            thing.UsedByAnyone = bb[2].BitField(6);
            thing.Magic = bb[2].BitField(7);
        }

        public void LoadThingWeightValue(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int[] weightMultiplier = { 1, -1, 20, -20 };
            byte[] b = file.ReadBlock(0x1BD00 + (thing.Number - 1) * 4, 3);

            // Weight
            thing.Weight = (int)(b[1]);
            thing.Weight *= weightMultiplier[b[0].Field(5, 6)];

            // Value
            thing.Value = (int)(b[2]);
            if (b[0].BitField(7)) thing.Value *= 20;
        }
        #endregion

        #region "Graphics"
        private void SetupPalette()
        {
            palette[0] = new SolidBrush(Color.FromArgb(0, 0, 0));
            palette[1] = new SolidBrush(Color.FromArgb(0, 0, 170));
            palette[2] = new SolidBrush(Color.FromArgb(0, 170, 0));
            palette[3] = new SolidBrush(Color.FromArgb(0, 170, 170));

            palette[4] = new SolidBrush(Color.FromArgb(170, 0, 0));
            palette[5] = new SolidBrush(Color.FromArgb(170, 0, 170));
            palette[6] = new SolidBrush(Color.FromArgb(170, 85, 0));
            palette[7] = new SolidBrush(Color.FromArgb(170, 170, 170));

            palette[8] = new SolidBrush(Color.FromArgb(85, 85, 85));
            palette[9] = new SolidBrush(Color.FromArgb(85, 85, 255));
            palette[10] = new SolidBrush(Color.FromArgb(85, 255, 85));
            palette[11] = new SolidBrush(Color.FromArgb(85, 255, 255));

            palette[12] = new SolidBrush(Color.FromArgb(255, 85, 85));
            palette[13] = new SolidBrush(Color.FromArgb(255, 85, 255));
            palette[14] = new SolidBrush(Color.FromArgb(255, 255, 85));
            palette[15] = new SolidBrush(Color.FromArgb(255, 255, 255));
        }


        public void LoadPicturesPC(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            int ypos = 0;
            int curAddress;

            int xpos = 0;
            Graphics g;

            SetupPalette();
            colorLookup[0] = (int)(file.ReadByte(0x2A802) & 0x0f);
            colorLookup[1] = (int)(file.ReadByte(0x2A803) & 0x0f);
            colorLookup[2] = (int)(file.ReadByte(0x2A804) & 0x0f);
            colorLookup[3] = (int)(file.ReadByte(0x2A805) & 0x0f);

            definition.NumberOfPictures = 96;

            for (int pic = 0; pic < 96; pic++)
            {
                definition.Pictures[pic] = new System.Drawing.Bitmap(16, 16);
                g = Graphics.FromImage(definition.Pictures[pic]);

                g.Clear(Color.Black);

                xpos = 0;
                ypos = 0;
                curAddress = 0x28720 + pic * 16;

                for (int i = 0; i < 8; i++)
                {
                    RenderByte(g, file.ReadByte(curAddress + i), xpos, ypos + i);
                    RenderByte(g, file.ReadByte(curAddress + 0x2400 + i), xpos + 4, ypos + i);
                    RenderByte(g, file.ReadByte(curAddress + 8 + i), xpos + 8, ypos + i);
                    RenderByte(g, file.ReadByte(curAddress + 0x2400 + 8 + i), xpos + 12, ypos + i);

                    RenderByte(g, file.ReadByte(curAddress + i + 0x800), xpos, ypos + i + 8);
                    RenderByte(g, file.ReadByte(curAddress + 0x2400 + i + 0x800), xpos + 4, ypos + i + 8);
                    RenderByte(g, file.ReadByte(curAddress + 8 + i + 0x800), xpos + 8, ypos + i + 8);
                    RenderByte(g, file.ReadByte(curAddress + 0x2400 + 8 + i + 0x800), xpos + 12, ypos + i + 8);
                }
            }

        }

        public void LoadPicturesC64(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            int ypos = 0;
            int curAddress;

            int xpos = 0;
            Graphics g;

            SetupPalette();
            colorLookup[0] = (int)(file.ReadByte(0x29880 - C64_OFFSET) & 0x0f);
            colorLookup[1] = (int)(file.ReadByte(0x29881 - C64_OFFSET) & 0x0f);
            colorLookup[2] = (int)(file.ReadByte(0x29882 - C64_OFFSET) & 0x0f);
            colorLookup[3] = (int)(file.ReadByte(0x29883 - C64_OFFSET) & 0x0f);

            definition.NumberOfPictures = 110;

            for (int pic = 0; pic < 110; pic++)
            {
                definition.Pictures[pic] = new System.Drawing.Bitmap(16, 16);
                g = Graphics.FromImage(definition.Pictures[pic]);

                g.Clear(Color.Black);

                xpos = 0;
                ypos = 0;
                curAddress = 0x28920 - C64_OFFSET + pic * 16;

                for (int i = 0; i < 8; i++)
                {
                    RenderByteC64(g, file.ReadByte(curAddress + i), xpos, ypos + i);
                    RenderByteC64(g, file.ReadByte(curAddress + 8 + i), xpos + 8, ypos + i);
                    RenderByteC64(g, file.ReadByte(curAddress + i + 0x800), xpos, ypos + i + 8);
                    RenderByteC64(g, file.ReadByte(curAddress + 8 + i + 0x800), xpos + 8, ypos + i + 8);
                }
            }

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void RenderByte(Graphics gr, byte b, int x, int y)
        {
            if (x > 32) throw new ArgumentOutOfRangeException("x");
            if (y > 32) throw new ArgumentOutOfRangeException("y");

            byte c = 0;
           
            c = (byte)((b & 0xC0) >> 6);
            Plot(gr, x, y, c);
            c = (byte)((b & 0x30) >> 4);
            Plot(gr, x + 1, y, c);
            c = (byte)((b & 0x0C) >> 2);
            Plot(gr, x + 2, y, c);
            c = (byte)((b & 0x03));
            Plot(gr, x + 3, y, c);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void RenderByteC64(Graphics gr, byte b, int x, int y)
        {
            if (x > 32) throw new ArgumentOutOfRangeException("x");
            if (y > 32) throw new ArgumentOutOfRangeException("y");

            byte c = 0;

            c = (byte)((b & 0xC0) >> 6);
            Plot(gr, x, y, c);
            Plot(gr, x + 1, y, c);
            c = (byte)((b & 0x30) >> 4);
            Plot(gr, x + 2, y, c);
            Plot(gr, x + 3, y, c);
            c = (byte)((b & 0x0C) >> 2);
            Plot(gr, x + 4, y, c);
            Plot(gr, x + 5, y, c);
            c = (byte)((b & 0x03));
            Plot(gr, x + 6, y, c);
            Plot(gr, x + 7, y, c);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        private void Plot(Graphics gr, int x, int y, byte c)
        {
            gr.FillRectangle(palette[colorLookup[c]], x, y, 1, 1);
        }

        #endregion

        #region "World Map"

        public void LoadWorldMap(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            definition.WorldMapName = TextDecoder.DecodeAscii(file.ReadBlock(0x1C42D, 22)).TrimEnd();
            definition.WorldMapStartX = file.ReadByte(0x1C7A0);
            definition.WorldMapStartY = file.ReadByte(0x1C7A1);

            int srcAddress = 0x1C7EA;

            for (int y = 0; y < 40; y++)
            {
                for (int x = 0; x < 40; x += 2)
                {
                    byte b = file.ReadByte(srcAddress++);
                    definition.WorldMap[x, y] = (byte)((b & 0xF0) >> 4);
                    definition.WorldMap[x + 1, y] = (byte)(b & 0x0F);
                }
            }

        }

        public void LoadWorldMapPortals(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            int address = 0x1C720;
            byte b;

            for (int i = 0; i < 32; i++)
            {
                var portal = new WorldMapPortal();
                definition.WorldMapPortals[i] = portal;

                portal.XPosition = (byte)(file.ReadByte(address + (i * 2)));
                portal.YPosition = (byte)(file.ReadByte(address + (i * 2) + 1) & 0x7F);
                portal.MapDestinationX = file.ReadByte(address + (i * 2) + 0x40);
                portal.MapDestinationY = file.ReadByte(address + (i * 2) + 0x40 + 1);

                System.Diagnostics.Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "World map portal ({0}): {1} - {2},{3}", i, portal.XPosition, portal.YPosition, address + (i * 2)));
                b = file.ReadByte(address + (i * 2) + 0x8A);
                portal.DestinationRoom = b.Field(0, 3);
                portal.DestinationRegion = b.Field(4, 7);

                b = file.ReadByte(address + (i * 2) + 0x8A + 1);
                portal.RoomDestinationY = b.Field(0, 3);
                portal.RoomDestinationX = b.Field(4, 7);

                if (portal.XPosition == 0xFF)
                {
                    portal.TypeOfPortal = WorldMapPortal.PortalType.NotUsed;
                }
                else
                {
                    if (portal.DestinationRegion == 0)
                        portal.TypeOfPortal = WorldMapPortal.PortalType.WorldMapDestination;
                    else
                        portal.TypeOfPortal = WorldMapPortal.PortalType.RoomDestination;

                }
            }
        }


        public void LoadTerrain(GameDefinition definition)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");

            for (int i = 0; i < 16; i++)
            {
                int address = 0x1c700 + (i * 2);
                Terrain terr = new Terrain();
                terr.TerrainNumber = i;
                byte b = file.ReadByte(address);
                terr.Picture = b & 0x1F;
                terr.TypeOfTerrain = (Terrain.TerrainType)b.Field(6, 7);
                terr.TypeParameter = file.ReadByte(address + 1);
                terr.Name = TextDecoder.DecodeAscii(file.ReadBlock(0x1CD62 + (15 * i), 15)).Trim();
                definition.TerrainTypes[i] = terr;
            }
        }

        #endregion

        #region "Regions"

        private void LoadRegions(GameDefinition definition)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");

            definition.NumberOfRegions = file.ReadByte(0x1C229);
            for (int i = 0; i < definition.NumberOfRegions; i++)
            {
                definition.Regions[i] = new Region();
                definition.Regions[i].Name = TextDecoder.DecodeAscii(file.ReadBlock(0x1C441 + (20 * i), 20)).Trim();
                definition.Regions[i].Number = i;
                LoadRooms(definition, definition.Regions[i]);

                int addr = 0x1D300 + i * 0xC00;
                definition.Regions[i].E3 = file.ReadByte(addr + 0x4e3);
                definition.Regions[i].E4 = file.ReadByte(addr + 0x4e4);
            }
        }

        private void LoadRooms(GameDefinition definition, Region region)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");
            if (region == null) throw new System.ArgumentException("region cannot be null");

            int addr = 0x1D300 + region.Number * 0xC00;
            region.NumberOfRooms = file.ReadByte(addr);

            byte[] data;

            data = file.ReadBlock(addr, 0x08);

            for (int i = 0; i < 16; i++)
            {
                Room room = new Room();
                room.Number = (region.Number * 16) + i + 16;
                room.Name = TextDecoder.DecodePacked(file.ReadBlock(addr + 0x3F3 + (10 * i), 10)).Trim();

                data = file.ReadBlock(addr + 0x09 + (i * 5), 5);
                room.WallPicture = data[0];
                room.XPosition = data[2];
                room.YPosition = data[3];
                room.Width = data[1].Field(4, 7);
                room.Height = data[1].Field(0, 3);

                room.Deleted = false;
                if (room.Width == 0 && room.Height == 0) room.Deleted = true;

                room.Width += 1;
                room.Height += 1;
                room.RandomCreatureChance = data[4].Field(0, 3);
                room.RandomCreatureChance *= 5;
                room.RandomCreatureNumber = data[4].Field(4, 6);

                region.Rooms.Add(room);
            }

            LoadRoomItems(definition, region);
            LoadRandomCreatures(region);
            LoadResidentCreatures(region);

            data = file.ReadBlock(addr, 0x9);
        }


        private void LoadResidentCreatures(Region region)
        {
            if (region == null) throw new System.ArgumentException("region cannot be null");

            int regionAddr = (0x1D300 + region.Number * 0xC00);

            byte b = file.ReadByte(regionAddr + 7);

            for (int i = 0; i < 16; i++)
            {
                Creature creature = LoadCreature(regionAddr + 0x453 + b + (i * 0x0A), 0, regionAddr + 0x1A3 + (i * 37));

                if (creature.Room != 0 && creature.Room < region.Rooms.Count) region.Room(creature.Room).RoomCreatures.Add(creature);
            }

        }

        private void LoadRandomCreatures(Region region)
        {
            if (region == null) throw new System.ArgumentException("region cannot be null");

            int addr = (0x1D300 + region.Number * 0xC00);

            for (int i = 0; i < 8; i++)
            {
                Creature creature = LoadCreature(addr + 0x493 + (i * 0x0A), 0, addr + 0x7B + (i * 37));
                region.RandomCreatures.Add(creature);
            }

        }

        private void LoadRoomItems(GameDefinition definition, Region region)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");
            if (region == null) throw new System.ArgumentException("region cannot be null");

            int addr = (0x1D300 + region.Number * 0xC00);
            int itemPointer = file.ReadByte(addr + 0x07) + (file.ReadByte(addr + 0x08) * 256);

            addr = addr + 0x3F3 + itemPointer;

            int byteCount = 0;
            byte b;

            for (int roomnum = 0; roomnum < region.Rooms.Count(); roomnum++)
            {
                byteCount = file.ReadByte(addr) + file.ReadByte(addr + 1) * 256;

                addr += 2;
                byteCount -= 2;
                while (byteCount > 0)
                {
                    RoomItem item = new RoomItem();
                    b = file.ReadByte(addr++);

                    if (b == 0xFF)
                    {
                        byteCount -= 3;
                        addr += 2;
                    }
                    else
                    {
                        item.XPosition = b.Field(4, 7);
                        item.YPosition = b.Field(0, 3);
                        item.ItemNumber = (byte)(file.ReadByte(addr++) & 0x7F);
                        item.Parameter = file.ReadByte(addr++);
                        if (item.ItemNumber > 0)
                        {

                            item.Item = definition.Things[item.ItemNumber - 1];
                            if (item.Item.TypeOfThing == Thing.ThingType.Portal)
                            {
                                int portalAddr = (0x1D300 + region.Number * 0xC00) + 0x4e3;

                                portalAddr = portalAddr + (item.Parameter * 2);

                                item.PortalDestinationRegion = file.ReadByte(portalAddr).Field(4, 7);
                                item.PortalDestinationRoom = file.ReadByte(portalAddr).Field(0, 3);
                                item.PortalDestinationY = file.ReadByte(portalAddr + 1).Field(0, 3);
                                item.PortalDestinationX = file.ReadByte(portalAddr + 1).Field(4, 7);

                                if (item.Item.OneWayPortal)
                                {
                                    if (item.PortalDestinationRegion == 0)
                                    {

                                        int baseAddr = 0x1c720;
                                        int p = ((item.PortalDestinationY) & 0x0F) + ((item.PortalDestinationX & 0x0F) << 4);

                                        item.WorldMapDestination = true;
                                        b = file.ReadByte(baseAddr + (p * 2));
                                        item.PortalDestinationX = b.Field(0, 5);
                                        b = file.ReadByte(baseAddr + (p * 2) + 1);
                                        item.PortalDestinationY = b.Field(0, 5);
                                    }
                                }

                            }
                        }
                        region.Rooms[roomnum].RoomItems.Add(item);
                        byteCount -= 3;
                    }
                }
            }

        }

        #endregion

        #region "Master Creature List"
        private void LoadClassNames(GameDefinition definition)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");

            int addr;
            for (int i = 0; i < 8; i++)
            {
                addr = 0x19300 + (i * 15);
                byte[] buf = file.ReadBlock(addr, 15);
                definition.CreatureClassNames[i] = TextDecoder.DecodeAscii(buf).TrimEnd();
            }

        }

        private Creature LoadCreature(int nameAddress, int classAddress, int propertiesAddress)
        {
            Creature cr = new Creature();

            byte[] data;

            cr.InUse = true;

            // Name
            data = file.ReadBlock(nameAddress, 0x0A);
            cr.Name = TextDecoder.DecodePacked(data).Trim();

            // Class
            if (classAddress > 0)
            {
                cr.Class = file.ReadByte(classAddress).Field(0, 3);
                if (cr.Class == 8) cr.InUse = false;
            }

            // Other properties
            data = file.ReadBlock(propertiesAddress, 37);

            cr.Picture = (byte)(data[0x16] - 2);
            cr.Constitution = data[0x00].Field(0, 5);
            cr.SpecialDefense = (Creature.DefenseType)(data[0x00].Field(6, 7));
            cr.Strength = data[0x01].Field(0, 4);
            cr.Dexterity = data[0x02].Field(0, 4);
            cr.LifeForce = data[0x03].Field(0, 5);
            cr.Speed = data[0x04].Field(0, 3);
            cr.StrategyBrave = (Creature.StrategyBraveType)data[0x04].Field(7, 7);
            cr.StrategyAggression = (Creature.StrategyAggressionType)data[0x04].Field(6, 6);
            cr.StrategyAlignment = (Creature.StrategyAlignmentType)data[0x04].Field(4, 5);
            cr.Power = data[0x05].Field(0, 6);
            cr.DodgeSkill = data[0x06].Field(0, 6);
            cr.ParrySkill = data[0x07].Field(0, 6);
            cr.ArmorSkill = data[0x08].Field(0, 6);
            cr.MeleeSkill = data[0x09].Field(0, 6);
            cr.MimicPowers = data[0x09].BitField(7);
            cr.MissileSkill = data[0x0A].Field(0, 6);

            cr.XPosition = data[0x0D];
            cr.YPosition = data[0x0E];
            cr.Size = data[0x0F].Field(0, 4);
            cr.Room = data[0x10].Field(0, 3);
            cr.Region = data[0x10].Field(4, 7);

            cr.Wisdom = data[0x11].Field(0, 4);
            cr.Wealth = data[0x13] * 256 + data[0x12];
            cr.ReadiedArmor = data[0x15];
            cr.ReadiedWeapon = data[0x14];

            // Posessions
            int num = 1;
            for (int idx = 23; idx < 31; idx++)
            {
                cr.Possessions[num] = data[idx].Field(6, 7);
                cr.Possessions[num + 1] = data[idx].Field(4, 5);
                cr.Possessions[num + 2] = data[idx].Field(2, 3);
                cr.Possessions[num + 3] = data[idx].Field(0, 1);
                num += 4;
            }
            for (int idx = 31; idx < 37; idx++)
            {
                for (byte b = 7; b < 8; b--)
                {
                    cr.Possessions[num++] = data[idx].Field(b, b);
                }

            }
            return cr;
        }

        private void LoadMasterCreatures(GameDefinition definition)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");

            Creature cr;

            for (int i = 0; i < 128; i++)
            {

                int addr = 0x19400 + ((i / 6) * 0x100) + ((i % 6) * 37);

                cr = LoadCreature(0x1B280 + (i * 0x0A), 0x1B200 + i, addr);

                // Add to list
                definition.CreatureList.Add(cr);
            }
        }

        #endregion

    }
}

