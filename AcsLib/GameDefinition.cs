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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace AcsLib
{
    public class GameDefinition
    {

        public enum SystemType
        {
            PC,
            C64,
            Apple,
            Amiga
        }

        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public int PlayerRegion { get; set; }
        public int PlayerRoom { get; set; }

        public SystemType System { get; set; }

        public string Name { get; set; }


        public string Byline { get; set; }
        public string IntroText { get; set; }
        public string Theme { get; set; }

        public Collection<Thing> Things { get; set; }
        public Collection<Creature> CreatureList { get;  }
        public Collection<WorldMapCreature> ActivePlayers { get; }
        public int ActivePlayerCount { get; set; }
        public Collection<WorldMapCreature> RetiredPlayers { get; }
        public int RetiredPlayerCount { get; set; }

        public int PaletteSize { get; set; }
        public Bitmap[] Pictures { get; set; }
        public SolidBrush[] Colors { get; set; }
        public string[] ColorNames { get; set; }

        public int NumberOfPictures { get; set; }
        public Terrain[] TerrainTypes { get; set; }

        public Region[] Regions { get; set; }
        public string[] CreatureClassNames { get; set; }  

        public string[] LongMessages { get; set; }

        public WorldMapPortal[] WorldMapPortals { get; set; }

        public enum WorldMapWrapType: int
        {
            [DescriptionAttribute("is not permitted")]
            NotPermitted = 0,
            [DescriptionAttribute("leads to opposite edge")]
            WrapsAround = 1
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional")]
        public byte[,] WorldMap { get; set; }
        public WorldMapCreature[] WorldMapCreatures { get; set; }
        public Collection<WorldMapCreature> WorldMapPlayers { get; }
        public string WorldMapName { get; set; }
        public int WorldMapStartX { get; set; }
        public int WorldMapStartY { get; set; }
        public WorldMapWrapType TypeWorldMapWrap { get; set; }
        public string WorldMapWrapTypeDescription 
        { 
            get { return TypeWorldMapWrap.ToDescription(); }
        }

        public int NumberOfRegions { get; set; }

        //public Collection<string> FinishGameNames { get; set; }

        public GameDefinition()
        {
            Pictures = new Bitmap[128];
            Colors = Enumerable.Repeat(new SolidBrush(Color.Black), 32).ToArray();
            ColorNames = new string[32];
            WorldMap = new Byte[40, 40];
            LongMessages = new string[255];
            //FinishGameNames = new Collection<String>();
            TerrainTypes = new Terrain[16];
            WorldMapCreatures = new WorldMapCreature[8];
            WorldMapPortals = new WorldMapPortal[32];
            WorldMapPlayers = new Collection<WorldMapCreature>();
            Things = new Collection<Thing>();
            CreatureList = new Collection<Creature>();
            ActivePlayers = new Collection<WorldMapCreature>();
            ActivePlayerCount = 0;
            RetiredPlayers = new Collection<WorldMapCreature>();
            RetiredPlayerCount = 0;
            Regions = new AcsLib.Region[15];
            CreatureClassNames = new string[8];
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void MoveToWorldMap(int x, int y)
        {
            PlayerRegion = 0;
            PlayerX = x;
            PlayerY = y;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void MoveToRoom(int region, int room, int x, int y)
        {
            PlayerRegion = region;
            PlayerRoom = room;
            PlayerX = x;
            PlayerY = y;
        }

        public bool PlayerOnWorldMap
        {
            get
            {
                if (PlayerRegion == 0) return true;
                return false;
            }
        }
    }
}
