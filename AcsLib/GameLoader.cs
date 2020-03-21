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

        enum AddressLabels: int
        {
            LongMessages = 0,
            IntroText,
            ShortMessages,
            Creatures,
            Things,
            AdventureData,
            WorldMap,
            Regions
        }

        BinaryFile file;
        private int fileOffset;
        private readonly int[] Addresses = new int[8];
        private Brush[] palette = new Brush[32];
        private readonly string[] paletteNames = new string[32];
        // This array is used to convert the 2 bits of Apple graphic bytes
        private readonly byte[] ac = new byte[16] { 0, 1, 2, 7, 0, 5, 2, 7, 0, 1, 6, 7, 0, 5, 6, 7 };
        public readonly int[] colorLookup = new Int32[32];


        public GameDefinition LoadGame(string fileName)
        {
            GameDefinition definition = new GameDefinition();

            string extension = System.IO.Path.GetExtension(fileName);
            file = new BinaryFile();

            // Setting system and starting value of fileOffset
            switch (extension.ToUpper(CultureInfo.CurrentCulture))
            {
                case ".D64":
                    definition.System = GameDefinition.SystemType.C64;
                    fileOffset = 0;
                    break;
                case ".FPY":
                case ".HRD":
                    definition.System = GameDefinition.SystemType.PC;
                    fileOffset = 0;
                    break;
                case ".DSK":
                    definition.System = GameDefinition.SystemType.Apple;
                    fileOffset = -26368;
                    break;
                default:
                    definition.System = GameDefinition.SystemType.Amiga;
                    fileOffset = 70912;
                    break;
            }

            // populate table of key addresses in the data file
            Addresses[(int)AddressLabels.LongMessages] =  0x06C00 + fileOffset;
                if (definition.System == GameDefinition.SystemType.C64) fileOffset = 512;
            Addresses[(int)AddressLabels.IntroText] =     0x16A00 + fileOffset;
                if (definition.System == GameDefinition.SystemType.Amiga) fileOffset = -4608;
            Addresses[(int)AddressLabels.ShortMessages] = 0x16B00 + fileOffset;
                if (definition.System == GameDefinition.SystemType.Amiga) fileOffset = -77056;
            Addresses[(int)AddressLabels.Creatures] =     0x19300 + fileOffset;
            Addresses[(int)AddressLabels.Things] =        0x1B800 + fileOffset;
            Addresses[(int)AddressLabels.AdventureData] = 0x1C200 + fileOffset;
                if (definition.System == GameDefinition.SystemType.Amiga) fileOffset = -77312;
            Addresses[(int)AddressLabels.WorldMap] =      0x1C700 + fileOffset;
            Addresses[(int)AddressLabels.Regions] =       0x1D300 + fileOffset;
            // pictures and palettes are so tied to system architecture 
            // that we won't bother to store the addresses for those

            file.Load(fileName);

            //LoadFinishGameNames(definition);

            LoadThings(definition);

            switch (definition.System)
            {
                case GameDefinition.SystemType.PC:
                    LoadPicturesPC(definition);
                    break;
                case GameDefinition.SystemType.C64:
                    LoadPicturesC64(definition);
                    break;
                case GameDefinition.SystemType.Apple:
                    LoadPicturesApple(definition);
                    break;
                case GameDefinition.SystemType.Amiga:
                    LoadPicturesAmiga(definition);
                    break;
            }

            switch (definition.System)
            {
                case GameDefinition.SystemType.PC:
                case GameDefinition.SystemType.C64:
                    definition.PaletteSize = 4;
                    definition.Colors[0] = (SolidBrush)palette[colorLookup[0]];
                    definition.Colors[1] = (SolidBrush)palette[colorLookup[1]];
                    definition.Colors[2] = (SolidBrush)palette[colorLookup[2]];
                    definition.Colors[3] = (SolidBrush)palette[colorLookup[3]];
                    definition.ColorNames[0] = paletteNames[colorLookup[0]];
                    definition.ColorNames[1] = paletteNames[colorLookup[1]];
                    definition.ColorNames[2] = paletteNames[colorLookup[2]];
                    definition.ColorNames[3] = paletteNames[colorLookup[3]];
                    break;
            }

            LoadGameInfo(definition);
            LoadTerrain(definition);
            LoadWorldMap(definition);
            LoadWorldMapPortals(definition);
            LoadWorldMapCreatures(definition);
            LoadRegions(definition);

            LoadClassNames(definition);
            LoadMasterCreatures(definition);
            LoadPlayers(definition);
            LoadLongMessages(definition);

            return definition;
        }

        /* The Apple data file doesn't contain this section,
         * and it isn't used in the viewer, so it's being removed.
         */
        /*
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
        */

        private void LoadWorldMapCreatures(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            for (int i = 0; i < 8; i++)
            {
                int chance = file.ReadByte(Addresses[(int)AddressLabels.WorldMap] + 0x65A + i).Field(0, 3);
                if (chance < 5)
                    chance *= 2;
                else
                    chance = (chance - 3) * 5;
                definition.WorldMapCreatures[i] = new WorldMapCreature
                {
                    Creature = LoadCreature((int)(Addresses[(int)AddressLabels.WorldMap] + 0x752 + i * 10), 0,
                    (int)(Addresses[(int)AddressLabels.WorldMap] + 0x40A + i * 37)),
                    //definition.WorldMapCreatures[i].AppearingInTerrain = file.ReadByte(0x1CD5A + i).Field(4, 7);
                    AppearingIn = definition.TerrainTypes[
                        file.ReadByte(Addresses[(int)AddressLabels.WorldMap] + 0x65A + i).Field(4, 7)].Name,
                    ChanceAppearing = (byte)chance
                };

            }
        }

        private void LoadGameInfo(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");
            int AdventureAddress = Addresses[(int)AddressLabels.AdventureData];

            definition.Name = TextDecoder.DecodeAscii(file.ReadBlock(AdventureAddress, 0x13)).TrimEnd();
            definition.Byline = TextDecoder.DecodeAscii(file.ReadBlock(AdventureAddress + 0x14, 0x13)).TrimEnd();
            definition.IntroText = TextDecoder.DecodeAscii(file.ReadBlock(
                Addresses[(int)AddressLabels.IntroText], 256));
            Music Theme = new Music
            {
                TypeOfMusic = (Music.MusicType)(file.ReadByte(AdventureAddress + 0x36E) + 13)
            };
            definition.Theme = Theme.MusicTypeDescription.Substring(8);

        }

        private void LoadLongMessages(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            // For the C64 only, the long message block is interrupted by the 
            //   1541 BAM and directory sectors, which is why we are loading
            //   the data in two pieces.
            for (int i = 0; i < 249; i++)
            {
                var msg = file.ReadBlock(Addresses[(int)AddressLabels.LongMessages] + (i * 256), 256);
                definition.LongMessages[i] = TextDecoder.DecodeAscii(msg);
            }
            for (int i = 0; i < 6; i++)
            {
                var msg = file.ReadBlock(Addresses[(int)AddressLabels.IntroText] - 1280 + (i * 256), 256);
                definition.LongMessages[i + 249] = TextDecoder.DecodeAscii(msg);
            }
        }

        #region "Things"

        private void LoadThings(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            int ThingAddr = Addresses[(int)AddressLabels.Things];
            byte b;
            byte[] name;

            for (int thingNum = 0; thingNum < 128; thingNum++)
            {
                Thing thing = new Thing
                {
                    Number = thingNum + 1
                };

                //Name
                name = file.ReadBlock(ThingAddr + (thingNum * 10), 10);
                thing.Name = TextDecoder.DecodePacked(name).Trim();

                // Common Properties 
                b = file.ReadByte(ThingAddr + 0x500 + thingNum * 4);

                thing.TypeOfThing = (Thing.ThingType)(b.Field(0, 3));
                thing.DisappearsAfterUser = b.BitField(4);

                // How many ACS can add
                b = file.ReadByte(ThingAddr + 0x800 + thingNum);
                thing.AcsMayAdd = b.Field(4, 7);
                switch (thing.TypeOfThing)
                {
                    case Thing.ThingType.RoomFloor:
                    case Thing.ThingType.Store:
                        thing.Picture = file.ReadByte(ThingAddr + 0x500 + thingNum * 4 + 1);
                        break;
                    case Thing.ThingType.Treasure:
                        thing.Picture = file.ReadByte(ThingAddr + 0x500 + thingNum * 4 + 3);
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

            int address = Addresses[(int)AddressLabels.Things] + 0x500 + (thing.Number - 1) * 4;
            byte[] data = file.ReadBlock(address, 4);

            if (data[0x00].BitField(7))
                thing.ChooseWhenPutIntoRoom = Thing.ChooseWhenPutIntoRoomType.SpellModifier;
            else
                thing.ChooseWhenPutIntoRoom = Thing.ChooseWhenPutIntoRoomType.Object;

            thing.Picture = data[0x01].Field(0, 5);
            thing.CustomSpaceAccess = (Thing.CustomSpaceAccessType)(data[0x01].Field(6, 7));
            thing.Action.TypeOfSpellAction = (SpellAction.SpellActionType)data[0x02].Field(0, 3);

            thing.DestroyThingNeededToMove = data[0x02].BitField(7);

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

            int address = Addresses[(int)AddressLabels.Things] + 0x500 + (thing.Number - 1) * 4;

            byte b = file.ReadByte(address + 1);
            thing.Picture = b.Field(0, 5);

            LoadOpenToProperties(thing);

            thing.WhyCannotPassMessage = LoadMessage(thing, 0);
            thing.SpellCastMessage = LoadMessage(thing, 1);
        }

        public void LoadObstacle(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int address = Addresses[(int)AddressLabels.Things] + 0x500 + (thing.Number - 1) * 4;
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

            int address = Addresses[(int)AddressLabels.Things] + 0x500 + (thing.Number - 1) * 4;
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

            int address = Addresses[(int)AddressLabels.Things] + 0x500 + (thing.Number - 1) * 4;
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
            int ThingAddress = Addresses[(int)AddressLabels.Things];
            int index = file.ReadByte(ThingAddress + 0x500 + (thing.Number - 1) * 4 + 3);

            int offset = file.ReadByte(ThingAddress + 0x882);
            int address = ThingAddress + 0x884 + offset + (index * 3);
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

            bool show;

            // Load message
            int address = Addresses[(int)AddressLabels.Things] + 0x700 + (thing.Number - 1) + (whichMessage * 0x80);
            byte b = file.ReadByte(address);
            show = !b.BitField(7);
            int messageIndex = b.Field(0, 6);
            if (messageIndex == 0) show = false;

            if (show)
            {
                messageIndex -= 1;
                address = Addresses[(int)AddressLabels.ShortMessages] + ((((messageIndex & 0x7E) >> 1) * 0x100) + (messageIndex & 0x01) * 0x78);
                byte[] msg = file.ReadBlock(address, 120);
                string rawMessage = TextDecoder.DecodeAscii(msg);
                string message = rawMessage.Substring(0, 40);
                if (rawMessage.Length > 40) message = String.Concat(message, "\r\n", rawMessage.Substring(40, 40));
                if (rawMessage.Length > 80) message = String.Concat(message, "\r\n", rawMessage.Substring(80, 40));
                return message;
            }

            return "";
        }

        public void LoadPortal(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int ThingAddress = Addresses[(int)AddressLabels.Things];

            int address = ThingAddress + 0x500 + (thing.Number - 1) * 4;
            byte b = file.ReadByte(address);
            thing.OneWayPortal = !b.BitField(5);
            b = file.ReadByte(address + 1);
            thing.Picture = b.Field(0, 5);
            LoadOpenToProperties(thing);
            b = file.ReadByte(address + 2);
            thing.DestroyThingNeededToMove = b.BitField(7);

            //int address2 = ThingAddress + 0x700 + (thing.Number - 1);
            //b = file.ReadByte(address2);

            thing.WhyCannotPassMessage = LoadMessage(thing, 0);
        }

        public void LoadOpenToProperties(Thing thing)
        {
            if (thing == null) throw new ArgumentNullException("thing");

            int address = Addresses[(int)AddressLabels.Things] + 0x500 + (thing.Number - 1) * 4;
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

            int ThingAddress = Addresses[(int)AddressLabels.Things];
            int index = file.ReadByte(ThingAddress + 0x500 + (thing.Number - 1) * 4 + 3);
            int address = ThingAddress + 0x884 + index * 3;
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
            byte[] b = file.ReadBlock(Addresses[(int)AddressLabels.Things] + 0x500 + (thing.Number - 1) * 4, 3);

            // Weight
            thing.Weight = (int)(b[1]);
            thing.Weight *= weightMultiplier[b[0].Field(5, 6)];

            // Value
            thing.Value = (int)(b[2]);
            if (b[0].BitField(7)) thing.Value *= 20;
        }
        #endregion

        #region "Graphics"
        private void SetupPalettePC()
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

            paletteNames[0] = "Black";
            paletteNames[1] = "Blue";
            paletteNames[2] = "Green";
            paletteNames[3] = "Cyan";
            paletteNames[4] = "Red";
            paletteNames[5] = "Magenta";
            paletteNames[6] = "Brown";
            paletteNames[7] = "Light Gray";
            paletteNames[8] = "Dark gray";
            paletteNames[9] = "Light Blue";
            paletteNames[10] = "Light Green";
            paletteNames[11] = "Light Cyan";
            paletteNames[12] = "Light Red";
            paletteNames[13] = "Light Magenta";
            paletteNames[14] = "Yellow";
            paletteNames[15] = "White";
        }

        private void SetupPaletteC64()
        {
            C64Palette cpal = new C64Palette();
            cpal.LoadPalette();

            palette = cpal.PalColor;

            paletteNames[0] = "Black";
            paletteNames[1] = "White";
            paletteNames[2] = "Red";
            paletteNames[3] = "Cyan";
            paletteNames[4] = "Purple";
            paletteNames[5] = "Green";
            paletteNames[6] = "Blue";
            paletteNames[7] = "Yellow";
            // Adventure Construction Set never uses the remaining colors:
            paletteNames[8] = "Orange";
            paletteNames[9] = "Brown";
            paletteNames[10] = "Light Red";
            paletteNames[11] = "Dark Gray";
            paletteNames[12] = "Medium Gray";
            paletteNames[13] = "Light Green";
            paletteNames[14] = "Light Blue";
            paletteNames[15] = "Light Gray";
        }

        public void SetupPaletteApple()
        {
            palette[0] = new SolidBrush(Color.FromArgb(0, 0, 0));
            palette[1] = new SolidBrush(Color.FromArgb(50, 208, 0));
            palette[2] = new SolidBrush(Color.FromArgb(212, 41, 255));
            palette[3] = new SolidBrush(Color.FromArgb(255, 255, 255));

            palette[4] = new SolidBrush(Color.FromArgb(0, 0, 0));
            palette[5] = new SolidBrush(Color.FromArgb(255, 92, 0));
            palette[6] = new SolidBrush(Color.FromArgb(0, 159, 226));
            palette[7] = new SolidBrush(Color.FromArgb(255, 255, 255));

            paletteNames[0] = "Black"; // binary 000
            paletteNames[1] = "Green"; // binary 001
            paletteNames[2] = "Violet"; // binary 010
            paletteNames[3] = "White"; // binary 011
            paletteNames[4] = "Black"; // binary 100
            paletteNames[5] = "Orange"; // binary 101
            paletteNames[6] = "Blue"; // binary 110
            paletteNames[7] = "White"; // binary 111
        }

        public void SetupPaletteAmiga(GameDefinition definition)
        {
            // Amiga color conversion involves unpacking hex shorthand:
            //  0 = 00, 1 = 11, ... F = FF. There's probably a built-in
            //  C# method for this, but I couldn't find it, so I'll use
            //  an array.
            byte[] hexExpand = new byte[16]
                { 00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77,
                    0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF };
            int addr = 0;
            for (int i = 0; i < 32; i++)
            {
                var dat = file.ReadBlock(addr + i * 2, 2);
                byte r = (byte)hexExpand[dat[0].Field(0, 3)];
                byte g = (byte)hexExpand[dat[1].Field(4, 7)];
                byte b = (byte)hexExpand[dat[1].Field(0, 3)];
                palette[i] = new SolidBrush(Color.FromArgb(r, g, b));
                colorLookup[i] = i;
                definition.Colors[i] = (SolidBrush)palette[i];
                // This will just populate the ARGB of each color
                definition.ColorNames[i] = definition.Colors[i].Color.Name;
            }
            definition.PaletteSize = 32;
        }

        public void LoadPicturesPC(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            int ypos;
            int curAddress;

            int xpos;
            Graphics g;

            SetupPalettePC();
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
                    RenderBytePC(g, file.ReadByte(curAddress + i), xpos, ypos + i);
                    RenderBytePC(g, file.ReadByte(curAddress + 0x2400 + i), xpos + 4, ypos + i);
                    RenderBytePC(g, file.ReadByte(curAddress + 8 + i), xpos + 8, ypos + i);
                    RenderBytePC(g, file.ReadByte(curAddress + 0x2400 + 8 + i), xpos + 12, ypos + i);

                    RenderBytePC(g, file.ReadByte(curAddress + i + 0x800), xpos, ypos + i + 8);
                    RenderBytePC(g, file.ReadByte(curAddress + 0x2400 + i + 0x800), xpos + 4, ypos + i + 8);
                    RenderBytePC(g, file.ReadByte(curAddress + 8 + i + 0x800), xpos + 8, ypos + i + 8);
                    RenderBytePC(g, file.ReadByte(curAddress + 0x2400 + 8 + i + 0x800), xpos + 12, ypos + i + 8);
                }
            }

        }

        public void LoadPicturesC64(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            int ypos;
            int curAddress;

            int xpos;
            Graphics g;

            SetupPaletteC64();
            colorLookup[0] = (int)(file.ReadByte(0x29880) & 0x0f);
            colorLookup[1] = (int)(file.ReadByte(0x29881) & 0x0f);
            colorLookup[2] = (int)(file.ReadByte(0x29882) & 0x0f);
            // for Commodore only, subtract 8 from last color
            colorLookup[3] = (int)(file.ReadByte(0x29883) & 0x0f)-8;

            definition.NumberOfPictures = 110;

            for (int pic = 0; pic < 110; pic++)
            {
                definition.Pictures[pic] = new System.Drawing.Bitmap(16, 16);
                g = Graphics.FromImage(definition.Pictures[pic]);

                g.Clear(Color.Black);

                xpos = 0;
                ypos = 0;
                curAddress = 0x28920 + pic * 16;

                for (int i = 0; i < 8; i++)
                {
                    RenderByteC64(g, file.ReadByte(curAddress + i), xpos, ypos + i);
                    RenderByteC64(g, file.ReadByte(curAddress + 8 + i), xpos + 8, ypos + i);
                    RenderByteC64(g, file.ReadByte(curAddress + i + 0x800), xpos, ypos + i + 8);
                    RenderByteC64(g, file.ReadByte(curAddress + 8 + i + 0x800), xpos + 8, ypos + i + 8);
                }
            }

        }

        public void LoadPicturesApple(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            int ypos;
            int curAddress;

            //int xpos = 0; // Apple loads whole row at a time
            int paletteSize = 6;
            byte paletteMask = 0;
            Graphics g;

            SetupPaletteApple();
            colorLookup[0] = 0;
            colorLookup[1] = 1;
            colorLookup[2] = 2;
            colorLookup[3] = 3;
            colorLookup[4] = 4;
            colorLookup[5] = 5;
            colorLookup[6] = 6;
            colorLookup[7] = 7;

            if (file.ReadByte(0x22FF9) == 0x7F)
            {
                paletteSize = 4;
                paletteMask = (byte)(file.ReadByte(0x22FF8) >> 5);
            }

            definition.NumberOfPictures = 110;

            for (int pic = 0; pic < 110; pic++)
            {
                definition.Pictures[pic] = new System.Drawing.Bitmap(14, 16);
                g = Graphics.FromImage(definition.Pictures[pic]);

                g.Clear(Color.Black);

                ypos = 0;
                curAddress = 0x22040 + pic * 32;

                for (int i = 0; i < 8; i++)
                {
                    RenderBytesApple(g, file.ReadByte(curAddress + i), file.ReadByte(curAddress + i + 8), ypos + i, paletteSize, paletteMask);
                    RenderBytesApple(g, file.ReadByte(curAddress + i + 16), file.ReadByte(curAddress + i + 24), ypos + 8 + i, paletteSize, paletteMask);
                }
            }
            if (paletteSize == 6)
            {
                definition.PaletteSize = 6;
                definition.Colors[0] = (SolidBrush)palette[colorLookup[0]];
                definition.Colors[1] = (SolidBrush)palette[colorLookup[1]];
                definition.Colors[2] = (SolidBrush)palette[colorLookup[2]];
                definition.Colors[3] = (SolidBrush)palette[colorLookup[3]];
                definition.Colors[4] = (SolidBrush)palette[colorLookup[5]];
                definition.Colors[5] = (SolidBrush)palette[colorLookup[6]];
                definition.ColorNames[0] = paletteNames[colorLookup[0]];
                definition.ColorNames[1] = paletteNames[colorLookup[1]];
                definition.ColorNames[2] = paletteNames[colorLookup[2]];
                definition.ColorNames[3] = paletteNames[colorLookup[3]];
                definition.ColorNames[4] = paletteNames[colorLookup[5]];
                definition.ColorNames[5] = paletteNames[colorLookup[6]];
            }
            else
            {
                definition.PaletteSize = 4;
                if (paletteMask == 0x00)
                {
                    definition.Colors[0] = (SolidBrush)palette[colorLookup[0]];
                    definition.Colors[1] = (SolidBrush)palette[colorLookup[1]];
                    definition.Colors[2] = (SolidBrush)palette[colorLookup[2]];
                    definition.Colors[3] = (SolidBrush)palette[colorLookup[3]];
                    definition.ColorNames[0] = paletteNames[colorLookup[0]];
                    definition.ColorNames[1] = paletteNames[colorLookup[1]];
                    definition.ColorNames[2] = paletteNames[colorLookup[2]];
                    definition.ColorNames[3] = paletteNames[colorLookup[3]];
                }
                else
                {
                    definition.Colors[0] = (SolidBrush)palette[colorLookup[0]];
                    definition.Colors[1] = (SolidBrush)palette[colorLookup[5]];
                    definition.Colors[2] = (SolidBrush)palette[colorLookup[6]];
                    definition.Colors[3] = (SolidBrush)palette[colorLookup[3]];
                    definition.ColorNames[0] = paletteNames[colorLookup[0]];
                    definition.ColorNames[1] = paletteNames[colorLookup[5]];
                    definition.ColorNames[2] = paletteNames[colorLookup[6]];
                    definition.ColorNames[3] = paletteNames[colorLookup[3]];
                }
            }
        }

        public void LoadPicturesAmiga(GameDefinition definition)
        {
            if (definition == null) throw new ArgumentNullException("definition");

            int ypos;
            int xpos;

            Graphics g;

            SetupPaletteAmiga(definition);

            definition.NumberOfPictures = 110;

            int[] BPAddr = new int[5] { 0x40, 0xE00, 0x1BC0, 0x2980, 0x3740 };
            byte[] b1 = new byte[5];
            byte[] b2 = new byte[5];
            int offset = 0;

            for (int pic = 0; pic < 110; pic++)
            {
                definition.Pictures[pic] = new System.Drawing.Bitmap(16, 16);
                g = Graphics.FromImage(definition.Pictures[pic]);

                g.Clear(definition.Colors[0].Color);

                xpos = 0;

                if (pic > 54) offset = 1650;

                for (ypos = 0; ypos < 16; ypos++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        b1[j] = file.ReadByte(BPAddr[j] + offset + pic*2 + ypos*110);
                        b2[j] = file.ReadByte(BPAddr[j] + offset + pic*2 + ypos*110 + 1);
                    }
                    RenderBytesAmiga(g, b1, xpos, ypos);
                    RenderBytesAmiga(g, b2, xpos + 8, ypos);
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void RenderBytePC(Graphics gr, byte b, int x, int y)
        {
            if (x > 32) throw new ArgumentOutOfRangeException("x");
            if (y > 32) throw new ArgumentOutOfRangeException("y");

            byte c;
           
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

            byte c;

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
        public void RenderBytesApple(Graphics gr, byte b1, byte b2, int y, int paletteSize, byte paletteMask)
        {
            if (y > 16) throw new ArgumentOutOfRangeException("y");

            int d;
            byte c, h1, h2, h3;

            if (paletteSize == 4)
            {
                h1 = paletteMask;
                h2 = paletteMask;
            } else
            {
                h1 = (byte)((b1 & 0x80) >> 5);
                h2 = (byte)((b2 & 0x80) >> 5);
            }
            h3 = (byte)(h2 * 2 + h1);
            d = (int)(((b2 & 0x7f) << 7) + (b1 & 0x7f)); // throw away high bits of both bytes
            c = (byte)(h1 + (d & 0x03));
            Plot(gr, 0, y, c);
            Plot(gr, 1, y, c);
            c = (byte)(h1 + ((d & 0x0C) >> 2));
            Plot(gr, 2, y, c);
            Plot(gr, 3, y, c);
            c = (byte)(h1 + ((d & 0x30) >> 4));
            Plot(gr, 4, y, c);
            Plot(gr, 5, y, c);
            c = (byte)ac[(h3 + ((d & 0xC0) >> 6))];
            //c = (byte)(h3 + ((d & 0xC0) >> 6));
            Plot(gr, 6, y, c);
            Plot(gr, 7, y, c);
            c = (byte)(h2 + ((d & 0x300) >> 8));
            Plot(gr, 8, y, c);
            Plot(gr, 9, y, c);
            c = (byte)(h2 + ((d & 0xC00) >> 10));
            Plot(gr, 10, y, c);
            Plot(gr, 11, y, c);
            c = (byte)(h2 + ((d & 0x3000) >> 12));
            Plot(gr, 12, y, c);
            Plot(gr, 13, y, c);
            return;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void RenderBytesAmiga(Graphics gr, byte[] b, int x, int y)
        {
            if (x > 32) throw new ArgumentOutOfRangeException("x");
            if (y > 32) throw new ArgumentOutOfRangeException("y");

            byte c, p;

            for (byte i = 0; i < 8; i++)
            {
                c = 0;
                p = (byte)(7 - i);
                for (int j = 0; j < 5; j++)
                {
                    c |= (byte)(b[j].Field(p, p) << j);
                }
                Plot(gr, x + i, y, c);
            }
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

            int AdventureAddress = Addresses[(int)AddressLabels.AdventureData];
            int WorldMapAddress = Addresses[(int)AddressLabels.WorldMap];
            definition.WorldMapName = TextDecoder.DecodeAscii(file.ReadBlock(AdventureAddress + 0x22D, 22)).TrimEnd();
            definition.WorldMapStartX = file.ReadByte(WorldMapAddress + 0xA0);
            definition.WorldMapStartY = file.ReadByte(WorldMapAddress + 0xA1);
            definition.TypeWorldMapWrap = (GameDefinition.WorldMapWrapType)file.ReadByte(AdventureAddress + 0x22C);

            int srcAddress = WorldMapAddress + 0xEA;

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

            int address = Addresses[(int)AddressLabels.WorldMap] + 0x20;
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

            int WorldMapAddress = Addresses[(int)AddressLabels.WorldMap];

            for (int i = 0; i < 16; i++)
            {
                int address = WorldMapAddress + (i * 2);
                byte b = file.ReadByte(address);
                Terrain terr = new Terrain
                {
                    TerrainNumber = i,
                    Picture = b & 0x1F,
                    TypeOfTerrain = (Terrain.TerrainType)b.Field(6, 7),
                    TypeParameter = file.ReadByte(address + 1),
                    Name = TextDecoder.DecodeAscii(file.ReadBlock(WorldMapAddress + 0x662 + (15 * i), 15)).Trim()
                };
                definition.TerrainTypes[i] = terr;
            }
        }

        #endregion

        #region "Regions"

        private void LoadRegions(GameDefinition definition)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");

            int AdventureAddress = Addresses[(int)AddressLabels.AdventureData];
            int RegionAddress = Addresses[(int)AddressLabels.Regions];

            definition.NumberOfRegions = file.ReadByte(AdventureAddress + 0x29);
            for (int i = 0; i < definition.NumberOfRegions; i++)
            {
                definition.Regions[i] = new Region
                {
                    Name = TextDecoder.DecodeAscii(file.ReadBlock(AdventureAddress + 0x241 + (20 * i), 20)).Trim(),
                    Number = i
                };
                LoadRooms(definition, definition.Regions[i]);

                int addr = RegionAddress + i * 0xC00;
                // Store Items
                byte[] data = file.ReadBlock(addr + 0x6D, 0x0e);
                int num = 1;
                for (int idx = 0; idx < 8; idx++)
                {
                    definition.Regions[i].StoreItems[num] = data[idx].Field(6, 7);
                    definition.Regions[i].StoreItems[num + 1] = data[idx].Field(4, 5);
                    definition.Regions[i].StoreItems[num + 2] = data[idx].Field(2, 3);
                    definition.Regions[i].StoreItems[num + 3] = data[idx].Field(0, 1);
                    num += 4;
                }
                for (int idx = 8; idx < 14; idx++)
                {
                    for (byte b = 7; b < 8; b--)
                    {
                        definition.Regions[i].StoreItems[num++] = data[idx].Field(b, b);
                    }

                }

                definition.Regions[i].E3 = file.ReadByte(addr + 0x4e3);
                definition.Regions[i].E4 = file.ReadByte(addr + 0x4e4);
            }
        }

        private void LoadRooms(GameDefinition definition, Region region)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");
            if (region == null) throw new System.ArgumentException("region cannot be null");

            int addr = Addresses[(int)AddressLabels.Regions] + region.Number * 0xC00;
            region.NumberOfRooms = file.ReadByte(addr);

            byte[] data;

            //data = file.ReadBlock(addr, 0x08);

            for (int i = 0; i < 16; i++)
            {
                data = file.ReadBlock(addr + 0x09 + (i * 5), 5);
                Room room = new Room
                {
                    Number = (region.Number * 16) + i + 16,
                    Name = TextDecoder.DecodePacked(file.ReadBlock(addr + 0x3F3 + (10 * i), 10)).Trim(),

                    WallPicture = data[0],
                    XPosition = data[2],
                    YPosition = data[3],
                    Width = data[1].Field(4, 7),
                    Height = data[1].Field(0, 3),

                    Deleted = false
                };
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

            //data = file.ReadBlock(addr, 0x9);
        }


        private void LoadResidentCreatures(Region region)
        {
            if (region == null) throw new System.ArgumentException("region cannot be null");

            int regionAddr = (Addresses[(int)AddressLabels.Regions] + region.Number * 0xC00);

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

            int addr = (Addresses[(int)AddressLabels.Regions] + region.Number * 0xC00);

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

            int WorldMapAddress = Addresses[(int)AddressLabels.WorldMap];
            int RegionAddress = Addresses[(int)AddressLabels.Regions];

            int addr = (RegionAddress + region.Number * 0xC00);
            int itemPointer = file.ReadByte(addr + 0x07) + (file.ReadByte(addr + 0x08) * 256);

            addr = addr + 0x3F3 + itemPointer;

            int byteCount;
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
                                int portalAddr = (RegionAddress + region.Number * 0xC00) + 0x4e3;

                                portalAddr += (item.Parameter * 2);

                                item.PortalDestinationRegion = file.ReadByte(portalAddr).Field(4, 7);
                                item.PortalDestinationRoom = file.ReadByte(portalAddr).Field(0, 3);
                                item.PortalDestinationY = file.ReadByte(portalAddr + 1).Field(0, 3);
                                item.PortalDestinationX = file.ReadByte(portalAddr + 1).Field(4, 7);

                                if (item.Item.OneWayPortal)
                                {
                                    if (item.PortalDestinationRegion == 0)
                                    {

                                        int baseAddr = WorldMapAddress + 0x20;
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
                addr = Addresses[(int)AddressLabels.Creatures] + (i * 15);
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

            if ((data[0x00] == 0) || (data[0x16] == 0))
            {
                cr.InUse = false;
            }
            else
            {
                cr.Picture = (byte)(data[0x16] - 2);
            }
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

            int CreatureAddress = Addresses[(int)AddressLabels.Creatures];

            Creature cr;

            for (int i = 0; i < 128; i++)
            {

                int addr = CreatureAddress + 0x100 + ((i / 6) * 0x100) + ((i % 6) * 37);

                cr = LoadCreature(CreatureAddress + 0x1F80 + (i * 0x0A), CreatureAddress + 0x1F00 + i, addr);

                // Add to list
                definition.CreatureList.Add(cr);
            }
        }

        private void LoadPlayers(GameDefinition definition)
        {
            if (definition == null) throw new System.ArgumentException("definiton cannot be null");

            int PlayerAddress = Addresses[(int)AddressLabels.AdventureData] + 0x2B;

            WorldMapCreature wmc;
            Creature cr;

            int pc = 0; // player count

            for (int i = 0; i < 4; i++)
            {

                int addr = PlayerAddress + (i * 37);

                cr = LoadCreature(PlayerAddress + 0x94 + (i * 0x0A), 0, addr);

                if (cr.InUse == true)
                {
                    // Add to list

                    string PlayerAppearingIn = "";
                    if (cr.Region == 0)
                    {
                        PlayerAppearingIn = string.Format("World Map {0},{1}", 
                            cr.XPosition, cr.YPosition);
                    }
                    else
                    {
                        Region PlayerRegion = definition.Regions[cr.Region - 1];
                        //PlayerAppearingIn = PlayerRegion.Name;
                        foreach (Room PlayerRoom in PlayerRegion.Rooms)
                        {
                            if (PlayerRoom.Number == ((cr.Region * 16) + cr.Room))
                            {
                                PlayerAppearingIn = string.Format("Region {0}, Room {1}, {2},{3}", 
                                      definition.Regions[cr.Region - 1]
                                    , definition.Regions[cr.Region - 1].Rooms[cr.Room]
                                    , cr.XPosition, cr.YPosition);
                            }
                        }
                    }
                    wmc = new WorldMapCreature
                    {
                        Creature = cr,
                        ChanceAppearing = 100,
                        AppearingIn = PlayerAppearingIn
                    };
                    definition.ActivePlayers.Add(wmc);
                    if (cr.Region == 0)
                    {
                        definition.WorldMapPlayers.Add(wmc);
                    }
                    else
                    {
                        Region region = definition.Regions[cr.Region - 1];
                        foreach (Room PlayerRoom in region.Rooms)
                        {
                            if (PlayerRoom.Number == (cr.Region * 16) + cr.Room)
                            {
                                PlayerRoom.RoomPlayers.Add(wmc);
                            }
                        }
                    }
                    pc++;
                }

            }
            definition.ActivePlayerCount = pc;

            pc = 0;
            PlayerAddress = Addresses[(int)AddressLabels.Creatures] + 0x1700;
            int i1 = 0, i2 = 0, j1 = 0, j2 = 0;

            cr = LoadCreature(PlayerAddress, 0, PlayerAddress + 0x200);
            while (cr.InUse)
            {
                wmc = new WorldMapCreature
                {
                    Creature = cr,
                    ChanceAppearing = 0,
                    AppearingIn = "In Retirement"
                };
                definition.RetiredPlayers.Add(wmc);
                pc++;

                if (pc > 33)
                {
                    break;
                }

                i1++;
                if (i1 > 25)
                {
                    i1 = 0;
                    j1++;
                }
                i2++;
                if (i2 > 6)
                {
                    i2 = 0;
                    j2++;
                }

                cr = LoadCreature(PlayerAddress + j1*0x100 + i1*0xA, 0, PlayerAddress + 0x200 + j2*0x100 + i2*0x25);
            }
            definition.RetiredPlayerCount = pc;
        }

        #endregion

    }
}

