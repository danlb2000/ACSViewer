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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcsLib;

namespace AcsLibTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestThingLoader
    {
        static private GameDefinition definition;

        public TestThingLoader()
        {
        }

        #region Additional test attributes
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContextInstance)
        {
            GameLoader loader = new GameLoader();
            definition = loader.LoadGame(Config.TestFilePath);
        }

        #endregion

        [TestMethod]
        public void TestRoomFloor()
        {
            Assert.AreEqual("EMPTY FLOOR", definition.Things[126].Name, "Thing 127 name wrong");
            Assert.AreEqual(Thing.ThingType.RoomFloor, definition.Things[126].TypeOfThing, "Thing 127 type wrong");
            Assert.AreEqual(15, definition.Things[126].AcsMayAdd, "Things 127 ACS may add wrong");
            Assert.AreEqual(1, definition.Things[126].Picture, "Thing 127 picture wrong");
        }

        [TestMethod]
        public void TestTreasure()
        {
            Assert.AreEqual("GRAIN", definition.Things[0].Name, "Thing 1 name wrong");
            Assert.AreEqual(60, definition.Things[0].Weight, "Thing 1 weight wrong");
            Assert.AreEqual(10, definition.Things[0].Value, "Thing 1 value wrong");
            Assert.AreEqual(15, definition.Things[0].AcsMayAdd, "Thing 1 ACS may add wrong");
            Assert.AreEqual(20, definition.Things[0].Picture, "Thing 1 picture wrong");
            Assert.IsFalse(definition.Things[0].DisappearsAfterUser, "Thing 1 disappears after use wrong");

            Assert.AreEqual(-1000, definition.Things[47].Weight, "Thing 48 weight wrong");
        }

        [TestMethod]
        public void TestMagicItem()
        {
            Assert.AreEqual("FAERY JEWEL", definition.Things[5].Name, "Thing 6 name wrong");
            Assert.AreEqual(Thing.ThingType.MagicItem, definition.Things[5].TypeOfThing, "Thing 6 type wrong");
            Assert.AreEqual(15, definition.Things[5].Weight, "Thing 6 weight wrong");
            Assert.AreEqual(300, definition.Things[5].Value, "Thing 6 value wrong");
            Assert.AreEqual(7, definition.Things[5].AcsMayAdd, "Thing 6 ACS may add wrong");
            Assert.AreEqual(41, definition.Things[5].Picture, "Thing 6 picture wrong");
            Assert.AreEqual("  THE JEWEL SPARKLES ENTICINGLY WITH A   LOVELY BRILLIANCE.  YOU FEEL ENTRANCED  AND RELUCTANT TO TRAVEL ANY FURTHER.   ", definition.Things[5].SpellCastMessage, "Spell cast message");
            Assert.IsFalse(definition.Things[5].DisappearsAfterUser, "Thing 6 disappears after use wrong");
            Assert.AreEqual(SpellAction.SpellActionType.DecreaseStat, definition.Things[5].Action.TypeOfSpellAction, "Thing 6 spell action wrong");
            Assert.AreEqual(3, definition.Things[5].Action.Parameter, "Thing 6 action parameter wrong");
            Assert.IsTrue(definition.Things[5].InvokedWhenItemIsPickedUp, "Thing 6 invoked when picked up wrong");
            Assert.IsFalse(definition.Things[5].InvokedWhenOwnerUsesItem, "Thing 6 invoked when used wrong");
            Assert.IsFalse(definition.Things[5].InvokedWhenItemIsDropped, "Thing 6 invoked when dropped");

            Assert.AreEqual(SpellAction.SpellActionType.ChangeLifeForce, definition.Things[6].Action.TypeOfSpellAction, "Thing 7 spell action wrong");
            Assert.AreEqual(86, definition.Things[6].Action.Parameter, "Thing 7 action parameter wrong");
            Assert.AreEqual(22, definition.Things[6].Action.ChangeAmount, "Thing 7 change amount wrong");
            Assert.IsTrue(definition.Things[6].Action.ChangeTemporary, "Thing 7 change temporary wrong");
            Assert.IsFalse(definition.Things[6].InvokedWhenItemIsPickedUp, "Thing 7 InvokedWhenItemIsPickedUp is wrong");
            Assert.IsFalse(definition.Things[6].InvokedWhenOwnerUsesItem, "Thing 7 InvokedWhenOwnerUsesItem is wrong");
            Assert.IsTrue(definition.Things[6].InvokedWhenItemIsDropped, "Thing 7 InvokedWhenItemIsDropped is wrong");

            Assert.AreEqual(SpellAction.SpellActionType.SummonBanish, definition.Things[53].Action.TypeOfSpellAction, "Thing 54 spell action wrong");
        }

        [TestMethod]
        public void TestMissileWeapon()
        {
            Assert.AreEqual("ROCK", definition.Things[3].Name, "Thing 4 name wrong");
            Assert.AreEqual(25, definition.Things[3].Weight, "Thing 4 weight wrong");
            Assert.AreEqual(1, definition.Things[3].Value, "Thing 4 value wrong");
            Assert.AreEqual(15, definition.Things[3].AcsMayAdd, "Thing 4 ACS may add wrong");
            Assert.AreEqual(56, definition.Things[3].Picture, "Thing 4 picture wrong");
            Assert.AreEqual(4, definition.Things[3].Range, "Thing 4 range wrong");
            Assert.AreEqual(2, definition.Things[3].Power, "Thing 4 power wrong");
            Assert.AreEqual(-20, definition.Things[3].AttackAdjustment, "Thing 4 attack adjusment wrong");
            Assert.AreEqual(0, definition.Things[3].ChanceOfBreaking, "Thing 4 chance of breaking wrong");
            Assert.IsTrue(definition.Things[3].DisappearsAfterUser, "Thing 4 disappears after use wrong");
            Assert.IsFalse(definition.Things[3].Magic, "Thing 4 magic is wrong");
            Assert.IsTrue(definition.Things[3].UsedByAnyone, "Thing 4 used by anyone wrong");

            Assert.AreEqual(5, definition.Things[10].Power, "Thing 11 power wrong");
            Assert.AreEqual(20, definition.Things[10].AttackAdjustment, "Thing 11 attack adjustment wrong");
            Assert.IsFalse(definition.Things[10].UsedByAnyone, "Thing 11 UserByAnyone wrong");
            Assert.IsFalse(definition.Things[10].DisappearsAfterUser, "Thing 11 disappears after use wrong");
            Assert.IsTrue(definition.Things[10].Magic, "Thing 11 magic is wrong");
        }


        [TestMethod]
        public void TestMeleeWeapon()
        {
            Assert.AreEqual("LARGE BONE", definition.Things[1].Name, "Thing 2 name wrong");
            Assert.AreEqual(Thing.ThingType.MeleeWeapon, definition.Things[1].TypeOfThing, "Thing 2 type wrong");
            Assert.AreEqual(65, definition.Things[1].Weight, "Thing 2 weight wrong");
            Assert.AreEqual(3, definition.Things[1].Value, "Thing 2 value wrong");
            Assert.AreEqual(15, definition.Things[1].AcsMayAdd, "Thing 2 ACS may add wrong");
            Assert.AreEqual(52, definition.Things[1].Picture, "Thing 2 picture wrong");
            Assert.AreEqual(3, definition.Things[1].Power, "Thing 2 power wrong");
            Assert.AreEqual(-10, definition.Things[1].AttackAdjustment, "Thing 2 attack adjusment wrong");
            Assert.AreEqual(14, definition.Things[1].ChanceOfBreaking, "Thing 2 chance of breaking wrong");
            Assert.IsFalse(definition.Things[1].DisappearsAfterUser, "Thing 2 disappears after use wrong");
            Assert.IsFalse(definition.Things[1].Magic, "Thing 2 magic is wrong");
            Assert.IsTrue(definition.Things[1].UsedByAnyone, "Thing 2 used by anyone wrong");

            Assert.IsFalse(definition.Things[14].UsedByAnyone, "Thing 15 used by anyone wrong");
            Assert.IsTrue(definition.Things[14].Magic, "Thing 15 magic is wrong");
        }

        [TestMethod]
        public void TestArmor()
        {
            Assert.AreEqual("BILLOWY SHIRT", definition.Things[51].Name, "Thing 52 name wrong");
            Assert.AreEqual(Thing.ThingType.Armor, definition.Things[51].TypeOfThing, "Thing 52 type wrong");
            Assert.AreEqual(18, definition.Things[51].Weight, "Thing 52 weight wrong");
            Assert.AreEqual(64, definition.Things[51].Value, "Thing 52 value wrong");
            Assert.AreEqual(1, definition.Things[51].AcsMayAdd, "Thing 52 ACS may add wrong");
            Assert.AreEqual(1, definition.Things[51].Power, "Thing 52 power wrong");
            Assert.AreEqual(45, definition.Things[51].Picture, "Thing 52 picture wrong");
            Assert.AreEqual(-5, definition.Things[51].AttackAdjustment, "Thing 52 attack adjusment wrong");
            Assert.AreEqual(15, definition.Things[51].ChanceOfBreaking, "Thing 52 chance of breaking wrong");
            Assert.IsFalse(definition.Things[51].DisappearsAfterUser, "Thing 52 disappears after use wrong");
            Assert.IsFalse(definition.Things[51].Magic, "Thing 52 magic is wrong");
            Assert.IsTrue(definition.Things[51].UsedByAnyone, "Thing 52 used by anyone wrong");

            Assert.IsFalse(definition.Things[13].UsedByAnyone, "Thing 14 used by anyone wrong");
            Assert.AreEqual(0, definition.Things[13].AttackAdjustment, "Thing 14 attack adjusment wrong");
            Assert.AreEqual(0, definition.Things[13].ChanceOfBreaking, "Thing 14 chance of breaking wrong");
            Assert.IsTrue(definition.Things[13].Magic, "Thing 14 magic is wrong");
        }

        [TestMethod]
        public void TestMagicSpell()
        {
            Assert.AreEqual("STONE GAZE", definition.Things[8].Name, "Thing 9 name wrong");
            Assert.AreEqual(Thing.ThingType.MagicSpell, definition.Things[8].TypeOfThing, "Thing 9 type wrong");
            Assert.AreEqual(0, definition.Things[8].Picture, "Thing 9 picture wrong");
            Assert.AreEqual(0, definition.Things[8].AcsMayAdd, "Thing 9 ACS may add wrong");
            Assert.AreEqual(3, definition.Things[8].Power, "Thing 9 power to case wrong");
            Assert.AreEqual(SpellAction.SpellActionType.DecreaseStat, definition.Things[8].Action.TypeOfSpellAction, "Thing 9 spell action wrong");
            Assert.IsTrue(definition.Things[8].DisappearsAfterUser, "Thing 9 disappears after use wrong");
            Assert.AreEqual(3, definition.Things[8].Action.Parameter, "Thing 9 action parameter wrong");
            Assert.AreEqual("   THE WITHERING GAZE OF THE HORRIBLE     BEAST MAKES YOUR BLOOD RUN COLD AND     YOUR LIMBS STIFFEN IN SHEER TERROR.   ", definition.Things[8].SpellCastMessage, "Spell cast message wrong");

            Assert.AreEqual(-2, definition.Things[15].Action.ChangeAmount, "Thing 16 ChangeAmount wrong");
            Assert.IsFalse(definition.Things[15].Action.ChangeTemporary, "Thing 15 ChangeTrmporary wrong");

            Assert.AreEqual(SpellAction.SpellActionType.PlayMusic, definition.Things[44].Action.TypeOfSpellAction, "Thing 45 action wrong");
            Assert.AreEqual(12, definition.Things[44].Action.Parameter, "Thing 45 action parameter wrong");
        }

        [TestMethod]
        public void TestPortal()
        {
            Assert.AreEqual("REGAL DOORWALL", definition.Things[18].Name, "Thing 19 name wrong");
            Assert.AreEqual(Thing.ThingType.Portal, definition.Things[18].TypeOfThing, "Thing 19 type wrong");
            Assert.AreEqual(15, definition.Things[18].AcsMayAdd, "Thing 19 ACS may add wrong");
            Assert.AreEqual(19, definition.Things[18].Picture, "Thing 19 picture wrong");
            Assert.IsTrue(definition.Things[18].OneWayPortal, "Thing 19 one way wrong");
            Assert.AreEqual(Thing.PortalAccessType.SpecificItem, definition.Things[18].PortalAccess, "Thing 19 access type wrong");
            Assert.AreEqual(18, definition.Things[18].PortalActionParameter, "Thing 19 access parameter wrong");
            Assert.AreEqual("", definition.Things[18].WhyCannotPassMessage, "Thing 19 why can't pass message wrong");
            Assert.IsTrue(definition.Things[18].DestroyThingNeededToMove, "Thing 19 destroys thing wrong");
            Assert.IsFalse(definition.Things[19].DisappearsAfterUser, "Thing 19 disappears after use wrong");

            Assert.IsFalse(definition.Things[77].OneWayPortal, "Thing 78 one way wrong");
            Assert.AreEqual(Thing.PortalAccessType.AnyoneMayPass, definition.Things[77].PortalAccess, "Thing 78 portal access wrong");

        }

        [TestMethod]
        public void TestSpace()
        {
            Assert.AreEqual("DEADLY FIRE", definition.Things[70].Name, "Thing 71 name wrong");
            Assert.AreEqual(Thing.ThingType.Space, definition.Things[70].TypeOfThing, "Thing 71 type wrong");
            Assert.AreEqual(2, definition.Things[70].AcsMayAdd, "Things 71 ACS may add wrong");
            Assert.AreEqual(57, definition.Things[70].Picture, "Thing 71 picture wrong");
            Assert.AreEqual(Thing.PortalAccessType.InvokeSpell, definition.Things[70].PortalAccess, "Thing 71 portal action type wrong");
            Assert.AreEqual(SpellAction.SpellActionType.ChangeLifeForce, definition.Things[70].Action.TypeOfSpellAction, "Thing 71 spell action type wrong");
            Assert.AreEqual(0x94, definition.Things[70].Action.Parameter, "Thing 71 spell action param wrong");
            Assert.AreEqual("     THE FIRE BURNS WITH A SEVERELY       PUNISHING INTENSITY.  FERVENTLY YOU     PRAY FOR RELEASE FROM THE AWFUL PAIN. ", definition.Things[70].SpellCastMessage, "Thing 71 spell cast message wrong");
            Assert.IsFalse(definition.Things[70].DisappearsAfterUser, "Thing 71 disappears after use wrong");

            Assert.IsTrue(definition.Things[85].DisappearsAfterUser, "Thing 86 disappears after use wrong");

            Assert.AreEqual(Thing.PortalAccessType.SpecificItem, definition.Things[116].PortalAccess, "Thing 117 portal access wrong");
            Assert.IsTrue(definition.Things[116].WhyCannotPassMessage.Contains("HORRIBLE"), "Thing 117 why cant pass message wrong");
        }

        [TestMethod]
        public void TestCustomSpace()
        {
            Assert.AreEqual("DEATH'S GATE", definition.Things[69].Name, "Thing 70 name wrong");
            Assert.AreEqual(Thing.ThingType.CustomSpace, definition.Things[69].TypeOfThing, "Thing 70 type wrong");
            Assert.AreEqual(0, definition.Things[69].AcsMayAdd, "Things 70 ACS may add wrong");
            Assert.AreEqual(39, definition.Things[69].Picture, "Thing 70 picture wrong");
            Assert.AreEqual(Thing.ChooseWhenPutIntoRoomType.Object, definition.Things[69].ChooseWhenPutIntoRoom, "Thing 70 choose object wrong");
            Assert.AreEqual(Thing.CustomSpaceAccessType.SpecificItem, definition.Things[69].CustomSpaceAccess, "Thing 70 access type wrong");
            Assert.AreEqual(SpellAction.SpellActionType.PlayMusic, definition.Things[69].Action.TypeOfSpellAction, "Thing 70 spell action type wrong");
            Assert.AreEqual(22, definition.Things[69].Action.Parameter, "Thing 70 spell action param wrong");
            Assert.IsFalse(definition.Things[69].DestroyThingNeededToMove, "Thing 70 destroy thing needed wrong");
            Assert.AreEqual("", definition.Things[69].SpellCastMessage, "Things 70 spell cast message wrong");
            Assert.IsFalse(definition.Things[69].DisappearsAfterUser, "Thing 70 disappears after use wrong");

            Assert.AreEqual(SpellAction.SpellActionType.KillAnyButOwnerOf, definition.Things[75].Action.TypeOfSpellAction, "Thing 76 spell action type wrong");

        }

        [TestMethod]
        public void TestObstacle()
        {
            Assert.AreEqual("DOALL OASIS H2O", definition.Things[16].Name, "Thing 17 name wrong");
            Assert.AreEqual(Thing.ThingType.Obstacle, definition.Things[16].TypeOfThing, "Thing 17 type wrong");
            Assert.AreEqual(0, definition.Things[16].AcsMayAdd, "Things 17 ACS may add wrong");
            Assert.AreEqual(0, definition.Things[16].Picture, "Thing 17 picture wrong");
            Assert.AreEqual(Thing.BumpActionType.InvokeSpell, definition.Things[16].BumpAction, "Thing 17 bump action wrong");
            Assert.AreEqual(SpellAction.SpellActionType.ActivateAllThings, definition.Things[16].Action.TypeOfSpellAction, "Thing 17 action is wrong");
            Assert.IsFalse(definition.Things[16].DisappearsAfterUser, "Thing 17 disappeats after use wrong");
            Assert.AreEqual("  YOU CAREFULLY POUR A PORTION OF WATER FROM THE OASIS INTO A SEALABLE WHITE CUPPROVIDED BY A FRIENDLY DESERT TRIBE.    ", definition.Things[16].SpellCastMessage, "Things 17 spell cast message wrong");

            Assert.AreEqual(Thing.BumpActionType.Closed, definition.Things[19].BumpAction, "Thing 20 bump action wrong");
        }

        [TestMethod]
        public void TestCustomObstacle()
        {
            Assert.AreEqual("POWER CHANGER", definition.Things[21].Name, "Thing 22 name wrong");
            Assert.AreEqual(Thing.ThingType.CustomObstacle, definition.Things[21].TypeOfThing, "Thing 22 type wrong");
            Assert.AreEqual(0, definition.Things[21].AcsMayAdd, "Things 22 ACS may add wrong");
            Assert.AreEqual(23, definition.Things[21].Picture, "Thing 22 picture wrong");
            Assert.AreEqual(Thing.ChooseWhenPutIntoRoomType.SpellModifier, definition.Things[21].ChooseWhenPutIntoRoom, "thing 22 choose object wrong");
            Assert.AreEqual(SpellAction.SpellActionType.ChangePower, definition.Things[21].Action.TypeOfSpellAction, "Thing 22 spell action type wrong");
            Assert.IsFalse(definition.Things[21].DisappearsAfterUser, "Thing 22 disappears after use wrong");
            Assert.AreEqual("", definition.Things[21].SpellCastMessage, "Thing 22 spell cast message wrong");

            Assert.AreEqual(SpellAction.SpellActionType.DisplayMessage, definition.Things[123].Action.TypeOfSpellAction, "Thing 124 spell action type wrong");
            Assert.IsTrue(definition.Things[123].DisappearsAfterUser, "Thing 124 disappears after use wrong");
        }

        [TestMethod]
        public void TestStore()
        {
            Assert.AreEqual("STORE", definition.Things[82].Name, "Thing 83 name wrong");
            Assert.AreEqual(Thing.ThingType.Store, definition.Things[82].TypeOfThing, "Thing 83 type wrong");
            Assert.AreEqual(15, definition.Things[82].AcsMayAdd, "Things 83 ACS may add wrong");
            Assert.AreEqual(17, definition.Things[82].Picture, "Thing 83 picture wrong");
        }



    }
}
