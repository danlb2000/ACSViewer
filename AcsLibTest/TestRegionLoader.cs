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
    public class TestRegionLoader
    {
        static private GameDefinition definition;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContextInstance)
        {           
            GameLoader loader = new GameLoader();
            definition = loader.LoadGame(Config.TestFilePath);

        }

        [TestMethod]
        public void TestRegionNames()
        {
            Assert.AreEqual("ANCIENT VALLEY", definition.Regions[0].Name, "Region 1 name wrong");
            Assert.AreEqual("SIPPAR CITY", definition.Regions[1].Name, "Region 2 name wrong");
            Assert.AreEqual("GIZEH", definition.Regions[11].Name, "Region 12 name wrong");
            Assert.AreEqual("REGION15", definition.Regions[14].Name, "Region 15 name wrong");
        }

        [TestMethod]
        public void TestRooms()
        {
            Room room = definition.Regions[0].Rooms[0];
            Assert.AreEqual("RIVER VALLEY", room.Name, "Region 1 Room 0 wrong name");
            Assert.AreEqual(10, room.Height, "Region 1 Room 0 wrong Height");
            Assert.AreEqual(15,room.Width,"Region 1 Room 0 wrong Width");
            Assert.AreEqual(24, room.XPosition, "Region 1 Room 0 Xpos wrong");
            Assert.AreEqual(14, room.YPosition, "Region 1 Room 0 Ypos wrong");
            Assert.AreEqual(3, room.WallPicture, "Region 1 Room 0 wall picture wrong");

            room = definition.Regions[0].Rooms[1];
            Assert.AreEqual("SMALL CAVE", room.Name, "Region 1 Room 1 wrong name");
            Assert.AreEqual(4, room.Height, "Region 1 Room 1 wrong Height");
            Assert.AreEqual(7, room.Width, "Region 1 Room 1 wrong Width");
            Assert.AreEqual(38, room.XPosition, "Region 1 Room 1 Xpos wrong");
            Assert.AreEqual(16, room.YPosition, "Region 1 Room 1 Ypos wrong");
            Assert.AreEqual(27, room.WallPicture, "Region 1 Room 1 wall picture wrong");

             room = definition.Regions[11].Rooms[0];
            Assert.AreEqual("GIZEH", room.Name, "Region 12 Room 0 wrong name");
            Assert.AreEqual(9, room.Height, "Region 12 Room 0 wrong Height");
            Assert.AreEqual(11, room.Width, "Region 12 Room 0 wrong Width");
            Assert.AreEqual(48, room.XPosition, "Region 12 Room 0 Xpos wrong");
            Assert.AreEqual(13, room.WallPicture, "Region 12 Room 0 wall picture wrong");

        }

        [TestMethod]
        public void TestLastRegion()
        {
            Room room = definition.Regions[14].Rooms[0];
            Assert.AreEqual("ROOM1", room.Name, "Region 14 Room 0 wrong name");
            Assert.AreEqual(5, room.Height, "Region 14 Room 0 wrong Height");
            Assert.AreEqual(6, room.Width, "Region 14 Room 0 wrong Width");
            Assert.AreEqual(39, room.XPosition, "Region 14 Room 0 Xpos wrong");
            Assert.AreEqual(19, room.YPosition, "Region 14 Room 0 Ypos wrong");
            Assert.AreEqual(19, room.WallPicture, "Region 14 Room 0 wall picture wrong");

             room = definition.Regions[14].Rooms[15];
            Assert.AreEqual("TEST16", room.Name, "Region 14 Room 0 wrong name");
            Assert.AreEqual(6, room.Height, "Region 14 Room 0 wrong Height");
            Assert.AreEqual(6, room.Width, "Region 14 Room 0 wrong Width");
            Assert.AreEqual(52, room.XPosition, "Region 14 Room 0 Xpos wrong");
            Assert.AreEqual(7, room.YPosition, "Region 14 Room 0 Ypos wrong");
            Assert.AreEqual(19, room.WallPicture, "Region 14 Room 0 wall picture wrong");
        }

        [TestMethod]
        public void TestRoomContents()
        {
            Room room = definition.Regions[0].Rooms[0];
            Assert.AreEqual(121, room.RoomItems[0].ItemNumber, "River Valley Item 0 number wrong");
            Assert.AreEqual(8, room.RoomItems[0].XPosition, "River Valley Item 0 xpos wrong");
            Assert.AreEqual(8, room.RoomItems[0].YPosition, "River Valley Item 0 ypos wrong");
        }

        [TestMethod]
        public void TestRoomPortals()
        {
            Room room = definition.Regions[0].Rooms[0];
            Assert.AreEqual(36, room.RoomItems[0].PortalDestinationX, "River Valley portal 0 xpos wrong");
            Assert.AreEqual(4, room.RoomItems[0].PortalDestinationY, "River Valley portal 0 ypos wrong");

            Assert.AreEqual(11, room.RoomItems[10].PortalDestinationX, "River Valley portal 10 xpos wrong");
            Assert.AreEqual(6, room.RoomItems[10].PortalDestinationY, "River Valley portal 10 ypos wrong");

            room = definition.Regions[11].Rooms[0];
            Assert.AreEqual(1, room.RoomItems[0].PortalDestinationX, "Gizha portal 0 xpos wrong");
            Assert.AreEqual(21, room.RoomItems[0].PortalDestinationY, "Gizha portal 0 ypos wrong");
            Assert.IsTrue(room.RoomItems[0].WorldMapDestination, "Gizha portal 0 WorldMapDestination wrong");
        }

        [TestMethod]
        public void TestRandomCreatures()
        {
            Region region = definition.Regions[0];
            Room room = region.Rooms[0];

            Assert.AreEqual("BEAR",region.RandomCreatures[0].Name, "Region 1 Random Creature 0 name wrong");
            Assert.AreEqual(30, region.RandomCreatures[0].MeleeSkill, "Bear meleeskill wrong");
            Assert.AreEqual(6, region.RandomCreatures[0].Speed, "Bear speed wrong");

            Assert.AreEqual(10, room.RandomCreatureChance, "Region 1 Room 0 Random Creature chance wrong");
            Assert.AreEqual(1,room.RandomCreatureNumber,"Region 1 Room 0 random creature number wrong");

            Assert.AreEqual("RAT", region.RandomCreatures[1].Name, "Region 1 Random Creature 1 name wrong");
            Assert.AreEqual(45, region.RandomCreatures[1].DodgeSkill, "Rat dodgekill wrong");
            Assert.AreEqual(6, region.RandomCreatures[1].Speed, "Rat speed wrong");

            region = definition.Regions[2];

            Assert.AreEqual("COMMON THIEF", region.RandomCreatures[0].Name, "Region 3 Random Creature 0 name wrong");
            Assert.AreEqual(10, region.RandomCreatures[0].DodgeSkill, "Rat dodgekill wrong");
            Assert.AreEqual(12, region.RandomCreatures[0].Power, "Rat power wrong");
            
        }

        [TestMethod]
        public void TestResidentCreatures()
        {
            Region region = definition.Regions[0];
            Assert.AreEqual("FERAL RAT", region.Rooms[2].RoomCreatures[0].Name, "Region 0, Resident creature 0 name wrong");
            Assert.AreEqual(3, region.Rooms[2].RoomCreatures[0].Constitution, "Region 0, Resident creature 0 constitution wrong");
            Assert.AreEqual(45, region.Rooms[2].RoomCreatures[0].DodgeSkill, "Region 0, Resident creature 0 dodge skill wrong");
            Assert.AreEqual(3, region.Rooms[2].RoomCreatures[0].XPosition, "Region 0, Resident creature 0 xpos wrong");
            Assert.AreEqual(3, region.Rooms[2].RoomCreatures[0].YPosition, "Region 0, Resident creature 0 ypos wrong");
        

            region = definition.Regions[11];
            Assert.AreEqual("BEAR", region.Rooms[3].RoomCreatures[0].Name, "Region 11, Resident creature 0 name wrong");
            Assert.AreEqual(16, region.Rooms[3].RoomCreatures[0].Constitution, "Region 11, Resident creature 0 constitution wrong");
            Assert.AreEqual(15, region.Rooms[3].RoomCreatures[0].DodgeSkill, "Region 11, Resident creature 0 dodge skill wrong");
            Assert.AreEqual(9, region.Rooms[3].RoomCreatures[0].XPosition, "Region 11, Resident creature 0 xpos wrong");
            Assert.AreEqual(2, region.Rooms[3].RoomCreatures[0].YPosition, "Region 11, Resident creature 0 ypos wrong");
        }
    }
}
