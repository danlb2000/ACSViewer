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
    public class Region
    {
        public string Name { get; set; }
        public Collection<Room> Rooms { get; }
        public int Number { get; set; }
        public Collection<Creature> RandomCreatures { get;  }
        public Collection<Creature> RoomCreatures { get;  }
        public byte[] StoreItems { get; set; }

        public int NumberOfRooms { get; set; }

        public byte E3 { get; set; }
        public byte E4 { get; set; }

        public Region()
        {
            Rooms = new Collection<Room>();
            RandomCreatures = new Collection<Creature>();
            RoomCreatures = new Collection<Creature>();
            StoreItems = new byte[81];
        }

        public override string ToString()
        {
            return Name;
        }

        public Room Room(int roomNumber)
        {
            if (roomNumber > Rooms.Count)
                return null;
            else
                return Rooms[roomNumber];
        }
    }
}
