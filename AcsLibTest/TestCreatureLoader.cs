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
    public class TestCreatureLoader
    {

        static private GameDefinition definition;

        public TestCreatureLoader()
        {
        }

         [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContextInstance) {
            GameLoader loader = new GameLoader();
            definition = loader.LoadGame(Config.TestFilePath);
        }

         [TestMethod]
         public void TestCreature1()
         {
             Assert.AreEqual("CROCODILE", definition.CreatureList[0].Name, "Creature 1 name wrong");
             Assert.AreEqual(90, definition.CreatureList[0].Picture, "Creature 1 picture wrong");
             Assert.AreEqual(0, definition.CreatureList[0].Class, "Creature 1 class wrong");
             Assert.AreEqual(12, definition.CreatureList[0].Constitution, "Creature 1 constitution wrong");
             Assert.AreEqual(14, definition.CreatureList[0].LifeForce, "Creature 1 life force wrong");
             Assert.AreEqual(8, definition.CreatureList[0].Wisdom, "Creature 1 wisdom wrong");
             Assert.AreEqual(14, definition.CreatureList[0].Power, "Creature 1 power wrong");
             Assert.AreEqual(6, definition.CreatureList[0].Dexterity, "Creature 1 dexterity wrong");
             Assert.AreEqual(0, definition.CreatureList[0].ArmorSkill, "Creature 1 armor skill wrong");
             Assert.AreEqual(0, definition.CreatureList[0].MissileSkill, "Creature 1 missile skill wrong");
             Assert.AreEqual(0, definition.CreatureList[0].DodgeSkill, "Creature 1 dodge skill wrong");
             Assert.AreEqual(35, definition.CreatureList[0].MeleeSkill, "Creature 1 melee skill wrong");
             Assert.AreEqual(15, definition.CreatureList[0].ParrySkill, "Creature 1 parry skill wrong");
             Assert.AreEqual(0, definition.CreatureList[0].Wealth, "Creature 1 wealth wrong");
             Assert.AreEqual(4, definition.CreatureList[0].Speed, "Creature 1 speed wrong");
             Assert.AreEqual(61, definition.CreatureList[0].ReadiedArmor, "Creature 1 armor wrong");
             Assert.AreEqual(37, definition.CreatureList[0].ReadiedWeapon, "Creature 1 weapon wrong");

             Assert.AreEqual(1, definition.CreatureList[0].Possessions[37], "Creature 1 possession 37 wrong");
             Assert.AreEqual(1, definition.CreatureList[0].Possessions[61], "Creature 1 possession 61 wrong");
             Assert.AreEqual(1, definition.CreatureList[0].Possessions[80], "Creature 1 possession 80 wrong");
         }

         [TestMethod]
         public void TestCreature2()
         {
             Assert.AreEqual("BAT", definition.CreatureList[1].Name, "Creature 2 name wrong");
             Assert.AreEqual(0, definition.CreatureList[1].Class, "Creature 2 class wrong");
             Assert.AreEqual(5, definition.CreatureList[1].Constitution, "Creature 2 constitution wrong");
         }

    }
}
