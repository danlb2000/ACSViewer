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
    public class RoomController : GameControllerBase
    {

        private RoomView roomView;
        private Room room;

        public RoomController(GameDefinition definition)
        {
            this.definition = definition;
            roomView = new RoomView(definition);
        }

        public void UpdatePlayerLocation()
        {
            roomView.SetRoom(definition.PlayerRegion, definition.PlayerRoom);
            roomView.SetPlayerPosition(definition.PlayerX, definition.PlayerY);
            room = definition.Regions[definition.PlayerRegion-1].Room(definition.PlayerRoom);
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

            if (CheckCollision(nx, ny)) return true;

            if (!CheckCanMove(nx, ny)) return false;

            roomView.SetPlayerPosition(nx, ny);    

            return false;

        }

        private bool CheckCanMove(int nx, int ny)
        {
            foreach (RoomItem item in room.RoomItems)
            {
                if (item.XPosition != nx || item.YPosition != ny) continue;
                switch (item.Item.TypeOfThing)
                {
                    case Thing.ThingType.Obstacle:
                        if (item.Item.BumpAction == Thing.BumpActionType.Closed) return false;
                        break;
                }
            }
            return true;
        }

        private bool CheckCollision(int nx, int ny)
        {
            foreach(RoomItem item in room.RoomItems)
            {
                if (item.XPosition != nx || item.YPosition != ny) continue;
               switch(item.Item.TypeOfThing)
                {
                    case Thing.ThingType.Portal:
                        if (item.WorldMapDestination)
                            definition.MoveToWorldMap(item.PortalDestinationX, item.PortalDestinationY);
                        else
                            definition.MoveToRoom(item.PortalDestinationRegion,item.PortalDestinationRoom, item.PortalDestinationX, item.PortalDestinationY);
                      
                        return true;                        
                }
            }

            return false;
        }

        public override void Render(Graphics gr)
        {
            roomView.Render(gr);
        }

    }
}

