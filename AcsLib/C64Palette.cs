/*   This code adapted from the palette handling code in VICE, 
 *   the Versitile Commodore Emulator. The original code was
 *   written by Ettore Perazzoli <ettore@comm2000.it> and 
 *   Andreas Boose <viceteam@t-online-de>, and distributed
 *   under the terms of the GNU General Public Licence as
 *   published by the Free Software Foundation; either
 *   version 2 of the License, or (at your option) any later
 *   version.
 *   
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *   
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA
 *   02111-1307  USA.
 * 
 */
using System;
using System.IO;
using System.Drawing;

namespace AcsLib
{
    class C64Palette
    {
        public string[] PalColorName { get; set; }
        public Brush[] PalColor { get; set; }
        private StreamReader sr;

        public C64Palette()
        {
            PalColorName = new string[17];

            PalColorName[0] = "Black";
            PalColorName[1] = "White";
            PalColorName[2] = "Red";
            PalColorName[3] = "Cyan";
            PalColorName[4] = "Purple";
            PalColorName[5] = "Green";
            PalColorName[6] = "Blue";
            PalColorName[7] = "Yellow";
            PalColorName[8] = "Orange";
            PalColorName[9] = "Brown";
            PalColorName[10] = "Light Red";
            PalColorName[11] = "Dark Gray";
            PalColorName[12] = "Medium Gray";
            PalColorName[13] = "Light Green";
            PalColorName[14] = "Light Blue";
            PalColorName[15] = "Light Gray";

            PalColor = new Brush[17];

            // default colors taken from CCS palette
            PalColor[0] = new SolidBrush(Color.FromArgb(16, 16, 16));
            PalColor[1] = new SolidBrush(Color.FromArgb(255, 255, 255));
            PalColor[2] = new SolidBrush(Color.FromArgb(224, 64, 64));
            PalColor[3] = new SolidBrush(Color.FromArgb(96, 255, 255));

            PalColor[4] = new SolidBrush(Color.FromArgb(224, 96, 224));
            PalColor[5] = new SolidBrush(Color.FromArgb(64, 224, 64));
            PalColor[6] = new SolidBrush(Color.FromArgb(64, 64, 224));
            PalColor[7] = new SolidBrush(Color.FromArgb(255, 255, 64));

            PalColor[8] = new SolidBrush(Color.FromArgb(224, 160, 64));
            PalColor[9] = new SolidBrush(Color.FromArgb(156, 116, 72));
            PalColor[10] = new SolidBrush(Color.FromArgb(255, 160, 160));
            PalColor[11] = new SolidBrush(Color.FromArgb(84, 84, 84));

            PalColor[12] = new SolidBrush(Color.FromArgb(136, 136, 136));
            PalColor[13] = new SolidBrush(Color.FromArgb(160, 255, 160));
            PalColor[14] = new SolidBrush(Color.FromArgb(160, 160, 255));
            PalColor[15] = new SolidBrush(Color.FromArgb(192, 192, 192));

        }

        public void LoadPalette()
        {
            Brush[] tempColor = new Brush[17];

            int entryNum = 0;
            byte[] values = new byte[4];
            try
            {
                using (sr = new StreamReader("palette.vpl"))
                {
                    int lineNum = 0;
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        int i;

                        lineNum++;

                        if (line.Length == 0)
                        {
                            continue;
                        }

                        if (line[0] == '#')
                        {
                            continue;
                        }

                        line = line.Trim();
                        if (line.Length == 0)
                        {
                            continue;
                        }

                        char[] charSeparators = new char[] { ' ', '\t', '\v', '\f' };
                        string[] parts = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                        int partCount = parts.Length;
                        if (partCount != 4)
                        {
                            continue;
                        }
                        for (i = 0; i < 4; i++)
                        {
                            int value;
                            try
                            {
                                value = Convert.ToInt32(parts[i], 16);
                            }
                            catch (OverflowException)
                            {
                                continue;
                            }
                            values[i] = (byte)value;
                        }

                        Color entry = new Color();
                        try
                        {
                            entry = Color.FromArgb(values[0], values[1], values[2]);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }
                        tempColor[entryNum] = new SolidBrush(entry);
                        entryNum++;
                    }

                    sr.Close();
                }
            }
            catch (IOException)
            {
                return; // if file is not found, just use default palette
            }

            if (entryNum == 16)
            {
                PalColor = tempColor;
            }
        }
    }
}
