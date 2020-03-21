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


using System.ComponentModel;

namespace AcsLib
{
    public class SpellAction
    {
        public enum ActionParameterType
        {
            Music,
            Message,
            Item,
            VictimStat,
            ChangeLifeForcePower,
            Creature,
            None
        }

        public enum SpellActionType : int
        {
            [DescriptionAttribute("Do nothing")]
            Nothing = 0,
            [DescriptionAttribute("Kill anyone but owner of")]
            KillAnyButOwnerOf = 1,
            [DescriptionAttribute("Summon or Banish Creature")]
            SummonBanish = 2,
            [DescriptionAttribute("Increase Magical Defense, but not above")]
            IncreaseMagicDefense = 3,
            [DescriptionAttribute("Decrease Magical Defense, but not below")]
            DecreaseMagicDefense = 4,
            [DescriptionAttribute("Increase Victim's Stat")]
            IncreaseStat = 5,
            [DescriptionAttribute("Decrease Victim's Stat")]
            DecreaseStat = 6,
            [DescriptionAttribute("Change Power of victim by")]
            ChangePower = 7,
            [DescriptionAttribute("Change life force of victim by")]
            ChangeLifeForce = 8,
            [DescriptionAttribute("Give To Victim one ")]
            Give = 9,
            [DescriptionAttribute("Display long message")]
            DisplayMessage = 10,
            [DescriptionAttribute("Play music")]
            PlayMusic = 11,
            [DescriptionAttribute(" Rid room of every uncarried")]
            RidRoomOfUnCarried = 12,
            [DescriptionAttribute(" Add to room one")]
            AddToRoom = 13,
            [DescriptionAttribute("Activate all things at this place")]
            ActivateAllThings = 14
        }

        public SpellActionType TypeOfSpellAction { get; set; }
        public byte Parameter { get; set; }

        public int ChangeAmount
        {
            get
            {
                int i = Parameter.Field(0, 5);
                if (Parameter.BitField(7)) i = -1 * i;
                return i;
            }
        }

        public bool ChangeTemporary
        {
            get
            {
                return Parameter.BitField(6);
            }
        }

        public ActionParameterType ParameterType
        {
            get
            {
                switch (TypeOfSpellAction)
                {
                    case SpellActionType.KillAnyButOwnerOf:
                    case SpellActionType.Give:
                    case SpellActionType.AddToRoom:
                    case SpellActionType.RidRoomOfUnCarried:
                        return ActionParameterType.Item;
                    case SpellActionType.IncreaseStat:
                    case SpellActionType.DecreaseStat:                  
                        return ActionParameterType.VictimStat;
                    case SpellActionType.ChangeLifeForce:
                    case SpellActionType.ChangePower:
                        return ActionParameterType.ChangeLifeForcePower;
                    case SpellActionType.SummonBanish:
                        return ActionParameterType.Creature;
                    case SpellActionType.DisplayMessage:
                        return ActionParameterType.Message;
                    case SpellActionType.PlayMusic:
                        return ActionParameterType.Music;
                  
                    default:
                        return ActionParameterType.None;
                }
            }
        }

        public override string ToString()
        {           
            return ActionTypeDescription;
        }


        public string ActionTypeDescription
        {
            get { return TypeOfSpellAction.ToDescription(); }
        }


    }
}
