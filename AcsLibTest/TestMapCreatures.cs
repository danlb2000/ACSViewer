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
    public class TestMapCreatures
    {
        static private GameDefinition definition;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContextInstance)
        {
            GameLoader loader = new GameLoader();
            definition = loader.LoadGame(Config.TestFilePath);
        }

        [TestMethod]
        public void TestCreature1()
        {
            Assert.AreEqual("CROCODILE", definition.WorldMapCreatures[0].Creature.Name, "Name 0 wrong");
            Assert.AreEqual(4, definition.WorldMapCreatures[0].AppearingInTerrain, "Terrain 0 wrong");
            Assert.AreEqual(10, definition.WorldMapCreatures[0].ChanceAppearing, "Chance Appearing 0 wrong");
            Assert.AreEqual(12, definition.WorldMapCreatures[0].Creature.Constitution, "Constitution 0 wrong");
            Assert.AreEqual(Creature.StrategyAggressionType.Aggressive, definition.WorldMapCreatures[0].Creature.StrategyAggression, "StrategyAggression 0 wrong");

            Assert.AreEqual("ENRAGED HIPPO", definition.WorldMapCreatures[7].Creature.Name, "Name 7 wrong");
            Assert.AreEqual(5, definition.WorldMapCreatures[7].AppearingInTerrain, "Terrain 7 wrong");
            Assert.AreEqual(15, definition.WorldMapCreatures[7].ChanceAppearing, "Chance Appearing 7 wrong");
            Assert.AreEqual(17, definition.WorldMapCreatures[7].Creature.Constitution, "Constitution 7 wrong");
            Assert.AreEqual(Creature.StrategyAggressionType.Aggressive, definition.WorldMapCreatures[7].Creature.StrategyAggression, "StrategyAggression 7 wrong");
        }

    }
}
