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
    public class TestGeneral
    {

        static private GameDefinition definition;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContextInstance)
        {
            GameLoader loader = new GameLoader();
            definition = loader.LoadGame(Config.TestFilePath);
        }

        [TestMethod]
        public void TestName()
        {
            Assert.AreEqual("  RIVERS OF LIGHT", definition.Name);
        }

        [TestMethod]
        public void TestByLine()
        {
            Assert.AreEqual("    STUART SMITH", definition.Byline);
        }

        [TestMethod]
        public void TestIntroduction()
        {
            Assert.AreEqual("   ARE WE EACH DESTINED TO LIVE FOR ONE BRIEF LIFETIME?  CAN ANYPERSON LIVE ETERNALLY, OR LIVE  AGAIN?  THERE ARE SOME IN THE   OLD WORLDS OF BABYLONIA AND     EGYPT WHO PROFESS TO KNOW THESE ANSWERS.  YOU MAY MEET THEM ON  YOUR OWN QUEST FOR ETERNAL LIFE.", definition.IntroText);
        }

    }
}
