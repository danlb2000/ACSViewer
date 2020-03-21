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

using System;
using System.IO;

namespace AcsLib
{

    public class BinaryFile
    {
        private byte[] data;
        private int _length;

        //public int Offset { get; set; }

        public int Length
        {
            get { return _length; }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public void Load(string fileName)
        {
            System.IO.FileInfo info = new FileInfo(fileName);
            _length = (int)info.Length;

            data = new Byte[_length];

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    data = br.ReadBytes(_length);
                }
            }
        }

        public byte ReadByte(int address)
        {
            //address += Offset;
            if (address > _length - 1) throw new ArgumentOutOfRangeException("address","Byte is beyond the end of the file");
            return data[address];
        }

        public byte[] ReadBlock(int address, int length)
        {
            byte[] block = new Byte[length];
            for (int i = 0; i < length; i++) block[i] = ReadByte(address++);

            return block;
        }
    }
}
