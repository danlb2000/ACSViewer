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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcsLibTest
{
    [TestClass]
    public class TestWorldMap
    {

        static private GameDefinition definition;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContextInstance)
        {
            GameLoader loader = new GameLoader();
            definition = loader.LoadGame(Config.TestFilePath);
        }

        [TestMethod]
        public void Terrain()
        {
            Assert.AreEqual("DEEP WATER",definition.TerrainTypes[0].Name,"Name 1 wrong");
            Assert.AreEqual(0,definition.TerrainTypes[0].Picture,"Picture 1 wrong");
            Assert.AreEqual(0,definition.TerrainTypes[0].TerrainNumber,"Terrain number 1 wrong");
            Assert.AreEqual(AcsLib.Terrain.TerrainType.Impassible,definition.TerrainTypes[0].TypeOfTerrain,"Terrain type 1 wrong");

            Assert.AreEqual(AcsLib.Terrain.TerrainType.OpenToOwnerOf,definition.TerrainTypes[4].TypeOfTerrain,"Terrain type 5 wrong");
            Assert.AreEqual(80,definition.TerrainTypes[4].TypeParameter,"Parameter 5 wrong");

        }
        
        [TestMethod]
        public void MapName() {
            Assert.AreEqual("THE FERTILE CRESCENT", definition.WorldMapName, "World map name wrong");
        }

        [TestMethod]
        public void Portals()
        {
            Assert.AreEqual(WorldMapPortal.PortalType.RoomDestination, definition.WorldMapPortals[0].TypeOfPortal, "Dest type wrong");
            Assert.AreEqual(1, definition.WorldMapPortals[0].DestinationRegion, "Dest region wrong");
            Assert.AreEqual(0, definition.WorldMapPortals[0].DestinationRoom, "Dest room wrong");
            Assert.AreEqual(8, definition.WorldMapPortals[0].RoomDestinationX, "Dest X wrong");
            Assert.AreEqual(8, definition.WorldMapPortals[0].RoomDestinationY, "Dest Y wrong");
            Assert.AreEqual(36, definition.WorldMapPortals[0].XPosition, "XPos wrong");
            Assert.AreEqual(4, definition.WorldMapPortals[0].YPosition, "YPos wrong");

            Assert.AreEqual(WorldMapPortal.PortalType.NotUsed, definition.WorldMapPortals[31].TypeOfPortal, "Port 31: Dest type wrong");
        }

    }
}
