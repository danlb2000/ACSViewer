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
    public class Creature
    {
        public enum Stat : System.Int32
        {
            Constitution = 0,
            Strength = 1,
            Dexterity = 2,
            Speed = 3,
            Wisdom = 4,
            DodgeSkill = 5,
            ParrySkill = 6,
            ArmorSkill = 7,
            MeleeSkill = 8,
            MissileSkill = 9
        }

        public enum StrategyBraveType : System.Int32
        {
            [DescriptionAttribute("Cautious")]
            Cautious = 0,
            [DescriptionAttribute("Brave")]
            Brave = 1
        }

        public enum StrategyAggressionType : System.Int32
        {
            [DescriptionAttribute("Peaceful")]
            Peaceful = 0,
            [DescriptionAttribute("Aggressive")]
            Aggressive = 1,
        }

        public enum StrategyAlignmentType : System.Int32 
        {
            [DescriptionAttribute("Thief")]
            Thief = 0,
            [DescriptionAttribute("Neutral")]
            Neutral = 1,
            [DescriptionAttribute("Enemy")]
            Enemy = 2,
            [DescriptionAttribute("Friend")]
            Friend = 3
        }

        public enum DefenseType : System.Int32
        {
            [DescriptionAttribute("No magical defense")]
            NoMagicalDefense = 0,
            [DescriptionAttribute("Non-magical weapons do half damage")]
            NonMagicDoHalfDamage = 1,
            [DescriptionAttribute("Only magic weapons do damage")]
            OnlyMagicWeaponsDamage = 2,
            [DescriptionAttribute("Magic weapons do half damage")]
            MagicDoHalfDamage = 3
        }

        public string DefenseTypeName
        {
            get { return SpecialDefense.ToDescription(); }
        }

        public string StrategyBraveName
        {
            get { return StrategyBrave.ToDescription(); }
        }

        public string StrategyAggressionName
        {
            get { return StrategyAggression.ToDescription(); }
        }

        public string StrategyAlignmentName
        {
            get { return StrategyAlignment.ToDescription(); }
        }

        public bool InUse { get; set; }
        public string Name { get; set; }
        public byte Class { get; set; }
        public byte Picture { get; set; }
        public byte Constitution { get; set; }
        public byte LifeForce { get; set; }
        public byte Wisdom { get; set; }
        public byte Power { get; set; }
        public byte Strength { get; set; }
        public byte Size { get; set; }
        public byte Dexterity { get; set; }
        public byte ArmorSkill { get; set; }
        public byte MissileSkill { get; set; }
        public byte DodgeSkill { get; set; }
        public byte MeleeSkill { get; set; }
        public byte ParrySkill { get; set; }
        public int Wealth { get; set; }
        public byte Speed { get; set; }
        public DefenseType SpecialDefense { get; set; }
        public byte ReadiedWeapon { get; set; }
        public byte ReadiedArmor { get; set; }
        public bool MimicPowers { get; set; }
        public byte AcsAdds { get; set; }
        public byte[] Possessions { get; set; }

        public byte XPosition { get; set; }
        public byte YPosition { get; set; }
        public byte Room { get; set; }
        public byte Region { get; set; }

        public StrategyBraveType StrategyBrave { get; set; }
        public StrategyAggressionType StrategyAggression { get; set; }
        public StrategyAlignmentType StrategyAlignment { get; set; }

        public Creature()
        {
            Possessions = new byte[81];
        }

        public override string ToString()
        {
            if (!InUse) return "";
            return Name;
        }
    }
}
