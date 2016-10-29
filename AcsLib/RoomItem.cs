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


using System.Globalization;

namespace AcsLib
{
    public class RoomItem
    {
        public byte XPosition { get; set; }
        public byte YPosition { get; set; }
        public byte ItemNumber { get; set; }
        public Thing Item { get; set; }
        public byte Parameter { get; set; }

        public byte PortalDestinationRegion { get; set; }
        public byte PortalDestinationRoom { get; set; }
        public byte PortalDestinationX { get; set; }
        public byte PortalDestinationY { get; set; }

        public bool WorldMapDestination { get; set; }

        public override string ToString()
        {
            if (Item == null) return "";
            return string.Format(CultureInfo.CurrentCulture,"{0} ({1})", Item.Name, Parameter.ToString(CultureInfo.CurrentCulture));
        }

    }
}
