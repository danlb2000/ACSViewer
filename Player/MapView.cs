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

namespace AcsViewer
{
    public class MapView
    {
        const int TILESWIDE = 15;
        const int TILESHIGH = 10;

        const int TILESCALE = 2;

        const int TILERAWSIZE = 16;

        int mapX = 0, mapY = 0;
        int playerX = 0, playerY = 0;

        private Bitmap bmp;

        private GameDefinition defenition;

        public MapView(GameDefinition defenition)
        {
            this.defenition = defenition;
            bmp = new Bitmap(TILESWIDE * TILERAWSIZE * TILESCALE, TILESHIGH * TILERAWSIZE * TILESCALE);
        }

        public void PlayerPosition(int x, int y)
        {
            playerX = x;
            playerY = y;

            mapX = playerX - 7;
            mapY = playerY - 5;

            if (mapX < 0) mapX  = 0;
            if (mapY < 0) mapY = 0;
            if (mapX > 25) mapX = 25;
            if (mapY > 30) mapY = 30;

            UpdateMap();

        }

        public void UpdateMap()
        {
            Graphics gr = Graphics.FromImage(bmp);
            gr.Clear(Color.White);
            for (int y = 0; y < TILESHIGH; y++)
            {
                for (int x = 0; x < TILESWIDE; x++)
                {
                    int tile = defenition.TerrainTypes[defenition.WorldMap[x + mapX , y + mapY]].Picture;
                   gr.DrawImage(defenition.Pictures[tile], x * TILERAWSIZE * TILESCALE, y * TILERAWSIZE * TILESCALE, TILERAWSIZE * TILESCALE+1, TILERAWSIZE * TILESCALE+1);
                    // gr.DrawImageUnscaled(defenition.Pictures[tile], x * TILERAWSIZE * TILESCALE, y * TILERAWSIZE * TILESCALE);
                }
            }

            gr.DrawImage(defenition.Pictures[64], (playerX - mapX) * TILERAWSIZE * TILESCALE, (playerY - mapY)  * TILERAWSIZE * TILESCALE, TILERAWSIZE * TILESCALE + 1, TILERAWSIZE * TILESCALE + 1);

        }

        public void Render(Graphics gr)
        {
            gr.DrawImage(bmp, 0, 0,bmp.Width,bmp.Height);
        }

    }
}
