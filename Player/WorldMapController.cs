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
using System.Drawing;
using System.Windows.Forms;

namespace AcsViewer.Player
{
    public class WorldMapController: GameControllerBase 
    {

        private MapView mapView;
     

        public WorldMapController(GameDefinition definition)
        {
            this.definition = definition;

            mapView = new MapView(definition);
            mapView.PlayerPosition(definition.PlayerX, definition.PlayerY);
            mapView.UpdateMap();      
        }

        public override bool KeyPressed(Keys keycode)
        {
            var changeState = false;

            switch (keycode)
            {
                case Keys.Up:
                    changeState = MovePlayer(MoveDirection.North);
                    break;
                case Keys.Down:
                    changeState = MovePlayer(MoveDirection.South);
                    break;
                case Keys.Right:
                    changeState = MovePlayer(MoveDirection.East);
                    break;
                case Keys.Left:
                    changeState = MovePlayer(MoveDirection.West);
                    break;

            }

            return changeState;
        }

        public bool MovePlayer(MoveDirection direction)
        {
            int nx = definition.PlayerX;
            int ny = definition.PlayerY;

            switch (direction)
            {
                case MoveDirection.North:
                    ny--;
                    break;
                case MoveDirection.South:
                    ny++;
                    break;
                case MoveDirection.East:
                    nx++;
                    break;
                case MoveDirection.West:
                    nx--;
                    break;
            }

            if (!CheckMoveBoundry(nx, ny)) return false;
            if (!CanMoveToWorldMapSpace(nx, ny)) return false;

            var portal = PortalAtLocation(nx, ny);
            if (portal != null)
            {
                return HandleWorldMapPortal(portal);
            }
            else
            {
                definition.PlayerX = nx;
                definition.PlayerY = ny;
                mapView.PlayerPosition(definition.PlayerX, definition.PlayerY);
                return false;
            }

        }

        private bool HandleWorldMapPortal(WorldMapPortal portal)
        {
            if (portal.TypeOfPortal == WorldMapPortal.PortalType.WorldMapDestination)
            {
                definition.PlayerX = portal.MapDestinationX;
                definition.PlayerY = portal.MapDestinationY;
                return false;
            }
            else
            {
                MoveToRoom(portal.DestinationRegion, portal.DestinationRoom, portal.RoomDestinationX, portal.RoomDestinationY);
                return true;
            }
        }

        private void MoveToRoom(int region, int room, int startX, int startY)
        {
            definition.PlayerRoom = room;
            definition.PlayerRegion = region;
            definition.PlayerX = startX;
            definition.PlayerY = startY;
           
        }

        private bool CheckMoveBoundry(int x, int y)
        {
            if (x < 0 || x > 39 || y < 0 || y > 39) return false;
            return true;
        }

        private bool CanMoveToWorldMapSpace(int x, int y)
        {
            var terrain = definition.TerrainTypes[definition.WorldMap[x, y]];
            if (terrain.TypeOfTerrain == Terrain.TerrainType.OpenToAll) return true;
            if (terrain.TypeOfTerrain == Terrain.TerrainType.Impassible) return false;

            return true;
        }

        private WorldMapPortal PortalAtLocation(int x, int y)
        {
            foreach (WorldMapPortal portal in definition.WorldMapPortals)
            {
                if (portal.TypeOfPortal != WorldMapPortal.PortalType.NotUsed && portal.TypeOfPortal != WorldMapPortal.PortalType.Destination
                    && portal.XPosition == x && portal.YPosition == y)
                    return portal;
            }
            return null;
        }

        public override void Render(Graphics gr)
        {
            mapView.Render(gr);
        }

    }
}
