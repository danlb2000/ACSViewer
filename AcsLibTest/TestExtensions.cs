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
    public class TestExtensions
    {
        [TestMethod]
        public void TestBitField()
        {
            byte b = 0x41;

            Assert.IsTrue(b.BitField(6));
            Assert.IsFalse(b.BitField(7));
            Assert.IsTrue(b.BitField(0));
        }

        [TestMethod]
        public void TestField()
        {
            byte b = 0x43;

            Assert.AreEqual(3, b.Field(0, 1));
            Assert.AreEqual(1, b.Field(6, 7));
            Assert.AreEqual(3, b.Field(0, 3));
        }
    }
}
