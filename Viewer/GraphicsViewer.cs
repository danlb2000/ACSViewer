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
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace AcsViewer
{
    public partial class GraphicsViewer : Form
    {
        //private Bitmap[] PaletteColors = Enumerable.Repeat(new Bitmap(16, 16), 32).ToArray();
        private Bitmap[] PaletteColors = Enumerable.Range(1, 32).Select(i => new Bitmap(16, 16)).ToArray();
        private Bitmap Palette = new Bitmap(246, 148);
        
        private Bitmap TerBmp = new Bitmap(288, 48);
        private Bitmap ThiBmp = new Bitmap(288, 96);
        private Bitmap CreBmp = new Bitmap(288, 96);

        public GameDefinition Definition { get; set; }
        private int picNum = 0;
        private int picWidth = 16;
        private int picHeight = 16;

        private const int CELLSIZE = 24;
        public GraphicsViewer()
        {
            InitializeComponent();
        }

        private void UpdateGraphics()
        {
            int xStart, yStart, width, height, rows, cols, spacing;

            Graphics gr = Graphics.FromImage(Palette);
            for (int i=0; i < Definition.PaletteSize; i++)
            {
                gr = Graphics.FromImage(PaletteColors[i]);
                gr.Clear(Definition.Colors[i].Color);
            }

            xStart = 49;
            yStart = 0;
            width = 64;
            height = 64;
            rows = 2;
            cols = 2;
            spacing = 20;

            switch (Definition.PaletteSize)
            {
                case 6:
                    xStart = 17;
                    cols = 3;
                    break;
                case 32:
                    xStart = 0;
                    yStart = 0;
                    width = 16;
                    height = 16;
                    rows = 4;
                    cols = 8;
                    spacing = 12;
                    break;
            }

            int palNum = 0;
            gr = Graphics.FromImage(Palette);
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            Font palFont = new Font("Microsoft Sans Serif", 8.25F);
            StringFormat palSF = new StringFormat();
            palSF.Alignment = StringAlignment.Center;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (palNum < Definition.PaletteSize)
                    {
                        gr.DrawImage(PaletteColors[palNum], 
                            xStart + (col*width) + (col*spacing), 
                            yStart + (row*width) + (row*spacing), 
                            width, height);
                        if (Definition.PaletteSize < 10)
                        {
                            SolidBrush palBrush = new SolidBrush(
                                GetContrastColor(Definition.Colors[palNum].Color));
                            RectangleF palRect = new RectangleF(
                                xStart + (col * width) + (col * spacing) + 1,
                                yStart + (row * width) + (row * spacing) + 22,
                                62, 23);
                            gr.DrawString(Definition.ColorNames[palNum], palFont, palBrush,
                                palRect, palSF);
                        }
                        palNum++;
                    }
                }
            }

            int tempPicNum = 0;
            int x, y;
            //int xStart, yStart;

            xStart = 4;
            yStart = 4;
            if (Definition.System == GameDefinition.SystemType.Apple)
            {
                picWidth = 14;
                xStart = 6;
            }

            gr = Graphics.FromImage(TerBmp);
            gr.Clear(Definition.Colors[0].Color);
            for (y = yStart; y < CELLSIZE * 2; y += CELLSIZE)
            {
                for (x = xStart; x < CELLSIZE * 12; x+= CELLSIZE)
                {
                    if (tempPicNum < 16)
                    {
                        gr.DrawImageUnscaled(Definition.Pictures[tempPicNum], x, y);
                        tempPicNum++;
                    }
                }
            }

            gr = Graphics.FromImage(ThiBmp);
            gr.Clear(Definition.Colors[0].Color);
            for (y = yStart; y < CELLSIZE * 4; y += CELLSIZE)
            {
                for (x = xStart; x < CELLSIZE * 12; x += CELLSIZE)
                {
                    if (tempPicNum < 64)
                    {
                        gr.DrawImageUnscaled(Definition.Pictures[tempPicNum], x, y);
                        tempPicNum++;
                    }
                }
            }

            gr = Graphics.FromImage(CreBmp);
            gr.Clear(Definition.Colors[0].Color);
            for (y = yStart; y < CELLSIZE * 4; y += CELLSIZE)
            {
                for (x = xStart; x < CELLSIZE * 12; x += CELLSIZE)
                {
                    if (tempPicNum < Definition.NumberOfPictures)
                    {
                        gr.DrawImageUnscaled(Definition.Pictures[tempPicNum], x, y);
                        tempPicNum++;
                    }
                }
            }

            // Draw box around selected graphic
            int picBase = 64;
            if (picNum < 16)
            {
                gr = Graphics.FromImage(TerBmp);
                picBase = 0;
            }
            if (picNum >= 16 && picNum < 64)
            {
                gr = Graphics.FromImage(ThiBmp);
                picBase = 16;
            }
            x = (xStart-1) + ((picNum - picBase) % 12) * CELLSIZE;
            y = (yStart-1) + ((int)((picNum - picBase) / 12)) * CELLSIZE;
            var pen = new Pen(new SolidBrush(Color.Cyan));
            gr.DrawRectangle(pen, x, y, (picWidth+2), (picHeight+2));

            this.Refresh();
        }

        private void SelectGraphic(int imageNum, int x, int y)
        {
            int picBase = 0;
            int tempPicNum = 0;

            switch (imageNum)
            {
                case 1:
                    picBase = 0;
                    break;
                case 2:
                    picBase = 16;
                    break;
                case 3:
                    picBase = 64;
                    break;
            }

            tempPicNum = picBase + y * 12 + x;

            switch (imageNum)
            {
                case 1:
                    if (tempPicNum > 15) tempPicNum = -1;
                    break;
                case 2:
                    if (tempPicNum < 16 || tempPicNum > 63) tempPicNum = -1;
                    break;
                case 3:
                    if (tempPicNum < 64 || tempPicNum > Definition.NumberOfPictures - 1) tempPicNum = -1;
                    break;
            }

            if (tempPicNum >= 0)
            {
                picNum = tempPicNum;
                UpdateSelectedGraphic();
            }
        }

        private Color GetContrastColor(Color fill)
        {
            float red = fill.R;
            float green = fill.G;
            float blue = fill.B;

            // formula from https://stackoverflow.com/questions/3942878/how-to-decide-font-color-in-white-or-black-depending-on-background-color
            if ((red * 0.99 + green * 0.587 + blue * 0.114) > 150)
                return Color.Black;
            else
                return Color.White;
        }

        private void pbTerrain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(TerBmp, 0, 0, 288, 48);
        }
        private void pbTerrain_MouseDown(object sender, MouseEventArgs e)
        {
            int x = (int)(e.X / CELLSIZE);
            int y = (int)(e.Y / CELLSIZE);

            SelectGraphic(1, x, y);
        }

        private void pbThings_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(ThiBmp, 0, 0, 288, 96);
        }
        private void pbThings_MouseDown(object sender, MouseEventArgs e)
        {
            int x = (int)(e.X / CELLSIZE);
            int y = (int)(e.Y / CELLSIZE);

            SelectGraphic(2, x, y);
        }

        private void pbCreatures_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(CreBmp, 0, 0, 288, 96);
        }
        private void pbCreatures_MouseDown(object sender, MouseEventArgs e)
        {
            int x = (int)(e.X / CELLSIZE);
            int y = (int)(e.Y / CELLSIZE);

            SelectGraphic(3, x, y);
        }

        private void pbPalette_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Palette, 0, 0, 246, 148);
        }

        private void pbGraphic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (Definition.Pictures[picNum] != null) e.Graphics.DrawImage(Definition.Pictures[picNum], 0, 0, 64, 64);
        }

        public void UpdateSelectedGraphic()
        {
            UINumber.Text = picNum.ToString();
            UpdateGraphics();
        }

        private void GraphicsViewer_Load(object sender, System.EventArgs e)
        {
            UpdateSelectedGraphic();
        }

        private void UIPrevious_Click(object sender, EventArgs e)
        {
            if (picNum > 0) picNum -= 1;
            UpdateSelectedGraphic();
        }

        private void UINext_Click(object sender, EventArgs e)
        {
            if ((picNum + 1) < Definition.NumberOfPictures) picNum += 1;
            UpdateSelectedGraphic();
        }

        private void UINumber_KeyUp(object sender, KeyEventArgs e)
        {
            int num;
            if (int.TryParse(UINumber.Text, out num))
            {
                if (num >= 0 && num < Definition.NumberOfPictures)
                {
                    picNum = num;
                    UpdateSelectedGraphic();
                }
            }
        }
    }
}
