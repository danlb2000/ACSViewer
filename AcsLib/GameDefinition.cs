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
using System.Drawing;

namespace AcsLib
{
    public class GameDefinition
    {

        public enum FileType
        {
            PC,
            C64
        }

        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public int PlayerRegion { get; set; }
        public int PlayerRoom { get; set; }

        public FileType TypeOfFile { get; set; }

        public string Name { get; set; }


        public string Byline { get; set; }
        public string IntroText { get; set; }

        public Collection<Thing> Things { get; set; }
        public Collection<Creature> CreatureList { get;  }

        public Bitmap[] Pictures { get; set; }

        public int NumberOfPictures { get; set; }
        public Terrain[] TerrainTypes { get; set; }

        public Region[] Regions { get; set; }
        public string[] CreatureClassNames { get; set; }  

        public string[] LongMessages { get; set; }

        public WorldMapPortal[] WorldMapPortals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional")]
        public byte[,] WorldMap { get; set; }
        public WorldMapCreature[] WorldMapCreatures { get; set; }
        public string WorldMapName { get; set; }
        public int WorldMapStartX { get; set; }
        public int WorldMapStartY { get; set; }

        public int NumberOfRegions { get; set; }

        public Collection<string> FinishGameNames { get; set; }

        public GameDefinition()
        {
            Pictures = new Bitmap[128];
            WorldMap = new Byte[40, 40];
            LongMessages = new string[80];
            FinishGameNames = new Collection<String>();
            TerrainTypes = new Terrain[16];
            WorldMapCreatures = new WorldMapCreature[8];
            WorldMapPortals = new WorldMapPortal[32];
            Things = new Collection<Thing>();
            CreatureList = new Collection<Creature>();
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
