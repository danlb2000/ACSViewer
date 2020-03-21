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
using System.ComponentModel;
using System.Globalization;

namespace AcsLib
{
    public class Thing
    {

        #region "enums"

        public enum BumpActionType : int
        {
            [DescriptionAttribute("Simple Obstacle, Closed to Travel")]
            Closed=0,
            [DescriptionAttribute("Bumping Into Obstacle Invokes Spell")]
            InvokeSpell=1
        }

        public enum ChooseWhenPutIntoRoomType : int
        {
            None=0,
            Object = 1,
            SpellModifier = 2
        }

        public enum CustomSpaceAccessType : int
        {   
            
            [DescriptionAttribute("Invoke spell when thing dropped here"),
             UsageDescriptionAttribute("Spell if one drops a {0} - {1}")]
            InvokeDropHere = 0,
            [DescriptionAttribute("Invoke spell when someone moves here"),
             UsageDescriptionAttribute("Spell if you move here")]
            InvokeMoveHere = 1,
            [DescriptionAttribute("Open to owner of a specific thing"),
             UsageDescriptionAttribute("Open if you have a {0} - {1}")]
            SpecificItem = 2,
            [DescriptionAttribute("Open to those who don't own a"),
             UsageDescriptionAttribute("Open if you don't have a {0} - {1}")]
            DoesNotOwn = 3
        }

        public enum PortalAccessType : int
        {
            [DescriptionAttribute("Anyone may pass, no spell invoked"),
             UsageDescriptionAttribute("")]
            AnyoneMayPass = 0,
            [DescriptionAttribute("Invoke spell when someone moves here"),
             UsageDescriptionAttribute("")]
            InvokeSpell = 1,
            [DescriptionAttribute("Open to owner of a specific item"),
             UsageDescriptionAttribute("")]
            SpecificItem = 2,
            [DescriptionAttribute("Open to those who don't own a"),
             UsageDescriptionAttribute("")]
            DoNotOwn = 3
        }

      
        public enum ThingType : int
        {
            [DescriptionAttribute("Room Floor")]
            RoomFloor = 0,
            [DescriptionAttribute("Treasure")]
            Treasure = 1,
            [DescriptionAttribute("Magic Item")]
            MagicItem = 2,
            [DescriptionAttribute("Missile Weapon")]
            MissileWeapon = 3,
            [DescriptionAttribute("Melee Weapon")]
            MeleeWeapon = 4,
            [DescriptionAttribute("Armor")]
            Armor = 5,
            [DescriptionAttribute("Magic Spell")]
            MagicSpell = 6,
            [DescriptionAttribute("Portal")]
            Portal = 7,
            [DescriptionAttribute("Space")]
            Space = 8,
            [DescriptionAttribute("Custom Space")]
            CustomSpace = 9,
            [DescriptionAttribute("Obstacle")]
            Obstacle = 10,
            [DescriptionAttribute("Custom Obstacle")]
            CustomObstacle = 11,
            [DescriptionAttribute("Store")]
            Store = 12,
            [DescriptionAttribute("Thing Type 13")]
            ThingType13 = 13,
            [DescriptionAttribute("Thing Type 14")]
            ThingType14 = 14,
            [DescriptionAttribute("Undefined")]
            Undefined = 15
        }

        #endregion

        public string ThingTypeDescription
        {
            get { return TypeOfThing.ToDescription(); }
        }

        public string PortalAccessTypeDescription
        {
            get { return PortalAccess.ToDescription(); }
        }

        public string CustomSpaceAccessTypeDescription
        {
            get { return CustomSpaceAccess.ToDescription(); }
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public ThingType TypeOfThing { get; set; }
        public byte Picture { get; set; }   
        public int AcsMayAdd { get; set; }

        public bool DisappearsAfterUser { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public int Power { get; set; }
        public Thing AccessThing { get; set; }
        public bool HasPicture { get; set; }

        public int Range { get; set; }

        public int ChanceOfBreaking { get; set; }
        public int AttackAdjustment { get; set; }
        
        public bool UsedByAnyone { get; set; }
        public bool Magic { get; set; }

        public SpellAction Action { get; set; }
        public bool InvokedWhenOwnerUsesItem { get; set; }
        public bool InvokedWhenItemIsDropped { get; set; }
        public bool InvokedWhenItemIsPickedUp { get; set; }

        //Portal
        public bool OneWayPortal { get; set; }
        public PortalAccessType PortalAccess { get; set; }
        public int PortalActionParameter { get; set; }

        //Custom Space
        public CustomSpaceAccessType CustomSpaceAccess { get; set; }
        public ChooseWhenPutIntoRoomType ChooseWhenPutIntoRoom { get; set; }
        public bool DestroyThingNeededToMove { get; set; }

        public BumpActionType  BumpAction { get; set; }

        public string WhyCannotPassMessage { get; set; }
        public string SpellCastMessage { get; set; } 

        public Thing()
        {
            Action = new SpellAction();
            TypeOfThing = ThingType.Undefined;
            Name = "";
            HasPicture = true;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "({0} - {1}) {1}", Number, Name);
        }

        //public string[] Description()
        //{
        //    var lines = new string[3];
        //    lines[0] = "";
        //    lines[1] = "";
        //    lines[2] = "";

        //    switch (this.TypeOfThing)
        //    {
        //        case ThingType.CustomSpace:
        //            lines[0] = String.Format(CultureInfo.CurrentCulture,CustomSpaceAccess.UsageDescription(),"test");
        //            break;
        //    }
         
        //    return lines;
        //}

        public string GetUsageDescription()
        {
            string desc = "";
            switch (this.TypeOfThing)
            {
                case ThingType.Portal:
                    desc = PortalAccess.UsageDescription();
                    break;
                case ThingType.CustomSpace:
                case ThingType.CustomObstacle:
                    if (ChooseWhenPutIntoRoom == ChooseWhenPutIntoRoomType.Object)
                    {
                        desc = CustomSpaceAccess.UsageDescription();
                    }
                    if (ChooseWhenPutIntoRoom == ChooseWhenPutIntoRoomType.SpellModifier)
                    {
                        switch (Action.ParameterType)
                        {
                            case SpellAction.ActionParameterType.Music:
                                desc = "Play music: {0} - {1}";
                                break;
                            case SpellAction.ActionParameterType.VictimStat:
                            case SpellAction.ActionParameterType.ChangeLifeForcePower:
                                desc = Action.ActionTypeDescription + " ({0}): {1}";
                                break;
                            case SpellAction.ActionParameterType.Creature:
                            case SpellAction.ActionParameterType.Item:
                                desc = Action.ActionTypeDescription + " {0} - {1}";
                                break;
                        }
                    }
                    break;
            }
            return desc;
        }
    }
}
