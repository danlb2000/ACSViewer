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

    public static class MyExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static bool BitField(this byte b, int bit)
        {
            byte mask = (byte)(0x01 << bit);
            if ((b & mask) > 0)
                return true;
            else
                return false;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static byte Field(this byte b, byte startBit, byte endBit)
        {
            byte mask = 0;
            for (byte i = startBit; i <= endBit; i++)
            {
                mask = (byte)(mask | (0x01 << i));
            }

            b = (byte)(b & mask);
            b = (byte)(b >> startBit);
            return b;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static string CollapseSpace(this string s)
        {
            if (s == null) throw new System.ArgumentException("s cannot be null");

            StringBuilder s2 = new StringBuilder();

            bool whitespace = false;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s.Substring(i, 1);
                if (string.IsNullOrWhiteSpace(c))
                {
                    if (!whitespace)
                    {
                        whitespace = true;
                        s2.Append(" ");
                    }
                    whitespace = true;
                }
                else
                {
                    s2.Append(c);
                    whitespace = false;
                }
  
            }
            return s2.ToString();
        }
    }
}
