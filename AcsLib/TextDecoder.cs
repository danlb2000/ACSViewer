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


using System.Text;

namespace AcsLib
{
    public static class TextDecoder
    {   
        static readonly string[] characters = {" ","A","B","C","D","E","F","G", 
                               "H","I","J","K","L","M","N","O",
                               "P","Q","R","S","T","U","V","W",
                               "X","Y","Z","1","2","3","4","5",
                               "6","7","8","9",".",",","-","'"};

        public static string DecodeAscii(byte[] data)
        {
            if (data == null) throw new System.ArgumentException("data cannot be null");

            var text = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < 32)
                    text.Append((char)(0x40 + data[i]));
                else
                    text.Append((char)data[i]);
            
            }
            return text.ToString();
        }


        public static string DecodePacked(byte[] data)
        {
            if (data == null) throw new System.ArgumentException("data cannot be null");

            var text = new StringBuilder();
            int value;
            int c1, c2, c3;

            for (int i = 0; i < data.Length; i += 2)
            {
                value = data[i + 1] * 256 + data[i];
                c1 = (int)(value / 1600);
                value -= c1 * 1600;

                c2 = (int)(value / 40);
                c3 = value - (c2 * 40);

                if (c1 > characters.GetUpperBound(0)) break;
                if (c2 > characters.GetUpperBound(0)) break;
                if (c3 > characters.GetUpperBound(0)) break;

                text.Append(characters[c1]);
                text.Append(characters[c2]);
                text.Append(characters[c3]);
            }
            return text.ToString();
        }
    }
}
