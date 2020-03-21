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


using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AcsLib
{
    public class Room
    {
        public bool Deleted { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public byte XPosition { get; set; }
        public byte YPosition { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte WallPicture { get; set; }

        public byte RandomCreatureChance { get; set; }
        public byte RandomCreatureNumber { get; set; }

        public Collection<RoomItem> RoomItems { get; }
        public Collection<Creature> RoomCreatures { get;  }
        public Collection<WorldMapCreature> RoomPlayers { get; }

        public Room()
        {
            RoomItems = new Collection<RoomItem>();
            RoomCreatures = new Collection<Creature>();
            RoomPlayers = new Collection<WorldMapCreature>();
        }

        public override string ToString()
        {
            return Name;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public Collection<RoomItem> GetItemsAtLocation(int x, int y)
        {
            var list = new Collection<RoomItem>();
            foreach(RoomItem item in RoomItems)
            {
                if (item.XPosition == x && item.YPosition == y) list.Add(item);
            }
            return list;
        }

    }
}
