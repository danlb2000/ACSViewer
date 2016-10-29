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

using System.Drawing;
using System.Windows.Forms;
using AcsLib;

namespace AcsViewer
{
    public partial class RegionViewer : Form
    {
        private const int CELLSIZE = 8;

        private Bitmap bmp = new Bitmap(640, 640);
        private AcsLib.Region region;
        private Room selectedRoom = null;

        public GameDefinition Definition { get; set; }


        public AcsLib.Region DisplayRegion
        {
            set
            {
                region = value;
                UpdateMap(value);
            }
        }


        public RegionViewer()
        {
            InitializeComponent();
        }

        public void UpdateMap(AcsLib.Region region)
        {
            this.Text = "Region " + region.Name;
            Graphics gr = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(Color.Black);

            gr.Clear(Color.White);
            foreach (Room room in region.Rooms)
            {
                if (room.Deleted) continue;
                gr.FillRectangle(brush, room.XPosition * CELLSIZE, room.YPosition * CELLSIZE, room.Width * CELLSIZE, CELLSIZE);
                gr.FillRectangle(brush, room.XPosition * CELLSIZE, room.YPosition * CELLSIZE, CELLSIZE, room.Height * CELLSIZE);
                gr.FillRectangle(brush, room.XPosition * CELLSIZE, room.YPosition * CELLSIZE + room.Height * CELLSIZE - CELLSIZE, room.Width * CELLSIZE, CELLSIZE);
                gr.FillRectangle(brush, room.XPosition * CELLSIZE + room.Width * CELLSIZE - CELLSIZE, room.YPosition * CELLSIZE, CELLSIZE, room.Height * CELLSIZE);
            }

            this.Refresh();
        }

        private void UIMap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0, 640, 640);
        }

        private void UIMap_MouseDown(object sender, MouseEventArgs e)
        {
            int x = (int)(e.X / CELLSIZE);
            int y = (int)(e.Y / CELLSIZE);

            foreach (Room room in region.Rooms)
            {
                if (x >= room.XPosition && x <= room.XPosition + room.Width
                    && y >= room.YPosition && y <= room.YPosition + room.Height)
                {
                    UIRoom.Text =  string.Format("[{0}] {1}",room.Number,room.Name);
                    selectedRoom = room;
                    break;
                }
            }

        }

        private void UIMap_DoubleClick(object sender, System.EventArgs e)
        {
            if (selectedRoom == null) return;
            var viewer = new RoomViewer(Definition, region, selectedRoom);
            viewer.MdiParent = this.MdiParent;
            viewer.Show();
        }

    }
}
