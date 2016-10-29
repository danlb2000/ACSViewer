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
using AcsViewer.Player;
using System.Drawing;
using System.Windows.Forms;

namespace AcsViewer
{
    public class GameEngine
    {
        private GameDefinition definition;
        private IGameController controller;

        private enum State
        {
            WorldMap,
            Room
        }

        public GameEngine(GameDefinition definition)
        {
            this.definition = definition;

            definition.PlayerX = definition.WorldMapStartX;
            definition.PlayerY = definition.WorldMapStartY;

            controller = new WorldMapController(definition);
 

        }

        public void KeyPressed(Keys keycode)
        {
            if (controller == null) return;
            var stageChange = controller.KeyPressed(keycode);

             if (stageChange)
            {
                if (definition.PlayerOnWorldMap)
                {
                    controller = new WorldMapController(definition);                   
                }
                else 
                {
                    var roomController = new RoomController(definition);
                    roomController.UpdatePlayerLocation();
                    controller = roomController;
                }
            }
        }

        public void Render(Graphics gr)
        {
            if (controller == null) return;
            controller.Render(gr);

        }

    
      

    }
}
