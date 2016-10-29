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
using System.Globalization;

namespace AcsLib
{
    public class Terrain
    {
        public enum TerrainType : int
        {
              [DescriptionAttribute("Impassible Terrain")]
              Impassible = 0,
              [DescriptionAttribute("Open to travel by all")]
              OpenToAll = 1,
              [DescriptionAttribute("Only open owners of")]
              OpenToOwnerOf = 2,
              [DescriptionAttribute("Triggers the spell")]
              TriggersSpell = 3

        }

        public int TerrainNumber { get; set; }
        public int Picture { get; set; }
        public string Name { get; set; }
        public TerrainType TypeOfTerrain { get; set; }
        public int TypeParameter { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "({0}) {1}", TerrainNumber, Name);
        }
    }
}
