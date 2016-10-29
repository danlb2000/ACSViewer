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
    public class RoomView
    {
        const int TILESWIDE = 15;
        const int TILESHIGH = 10;

        const int TILESCALE = 2;

        const int TILERAWSIZE = 16;

        private Bitmap bmp;

        private byte[,] map = new byte[16, 16];


        public byte floorTile;
        public byte wallPicture;

        private Room room = null;
        private GameDefinition definition = null;

        public RoomView(GameDefinition defenition)
        {
            this.definition = defenition;
            bmp = new Bitmap(TILESWIDE * TILERAWSIZE * TILESCALE, TILESHIGH * TILERAWSIZE * TILESCALE);
        }

        public void SetPlayerPosition(int x, int y)
        {
            definition.PlayerX = x;
            definition.PlayerY = y;
            UpdateImage();
        }

        public void SetRoom(int regionNum, int roomNum)
        {
            room = definition.Regions[regionNum-1].Room(roomNum);
            DrawRoom(room);
        }

        public void UpdateImage()
        {
            Graphics gr = Graphics.FromImage(bmp);

            for (int y = 0; y <= 15; y++)
            {
                for (int x = 0; x <= 15; x++)
                {
                    if (map[x, y] <= definition.Pictures.GetUpperBound(0) && definition.Pictures[map[x, y]] != null)
                    {
                        gr.DrawImage(definition.Pictures[map[x, y]], x * TILERAWSIZE * TILESCALE, y * TILERAWSIZE * TILESCALE, TILERAWSIZE * TILESCALE + 1, TILERAWSIZE * TILESCALE + 1);
                    }
                }
            }

            gr.DrawImage(definition .Pictures[64], (definition.PlayerX) * TILERAWSIZE * TILESCALE, (definition.PlayerY ) * TILERAWSIZE * TILESCALE, TILERAWSIZE * TILESCALE + 1, TILERAWSIZE * TILESCALE + 1);

        }

        private void ClearMap(byte tile)
        {
            for (int y = 0; y <= 15; y++)
            {
                for (int x = 0; x <= 15; x++)
                {
                    map[x, y] = tile;
                }
            }
        }


        public void DrawRoom(Room room)
        {
            floorTile = (byte)definition.Things[126].Picture;
            wallPicture = room.WallPicture;
            ClearMap(floorTile);

            DrawHLine(0, 0, room.Width - 1, wallPicture, floorTile);
            DrawHLine(0, room.Height - 1, room.Width, wallPicture, floorTile);
            DrawVLine(0, 0, room.Height - 1, wallPicture, floorTile);
            DrawVLine(room.Width - 1, 0, room.Height, wallPicture, floorTile);

            foreach (RoomItem item in room.RoomItems)
            {
                if (map[item.XPosition, item.YPosition] == floorTile || map[item.XPosition, item.YPosition] == wallPicture)
                    map[item.XPosition, item.YPosition] = (byte)(item.Item.Picture);
            }

            foreach (Creature creature in room.RoomCreatures)
            {
                if (map[creature.XPosition, creature.YPosition] == floorTile || map[creature.XPosition, creature.YPosition] == wallPicture)
                    map[creature.XPosition, creature.YPosition] = (byte)(creature.Picture);
            }


            UpdateImage();
        }

        private void DrawHLine(int x1, int y1, int width, byte tile, byte floorTile)
        {
            for (int x = x1; x < x1 + width; x++) if (map[x, y1] == floorTile) map[x, y1] = tile;
        }

        private void DrawVLine(int x1, int y1, int height, byte tile, byte floorTile)
        {
            for (int y = y1; y < y1 + height; y++) if (map[x1, y] == floorTile) map[x1, y] = tile;
        }

        public void Render(Graphics gr)
        {
            gr.DrawImage(bmp, 0, 0,bmp.Width,bmp.Height);
        }

    }
}
