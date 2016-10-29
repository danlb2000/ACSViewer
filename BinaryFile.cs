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

public class BinaryFile
{
    private byte[] data;

    private int _length;
    
    public int Length
    {
        get { return _length; }
    }

    public void Load(string filename)
    {
        System.IO.FileInfo info = new FileInfo(filename);
        _length = (int)info.Length;

        data = new Byte[_length];

        FileStream fs = new FileStream(filename, FileMode.Open);
        BinaryReader br = new BinaryReader(fs);

        data = br.ReadBytes(_length);
        br.Close();
        fs.Close();
    }

    public byte ReadByte(long addr)
    {
        if (addr > _length - 1) throw new Exception("Byte is beyond the end of the file");
        return data[addr];
    }
}
