using System;
using System.Collections.Generic;
using System.Text;

namespace AcsViewer
{
    public class TextDecoder
    {   
        string[] characters = {" ","A","B","C","D","E","F","G", 
                               "H","I","J","K","L","M","N","O",
                               "P","Q","R","S","T","U","V","W",
                               "X","Y","Z","1","2","3","4","5",
                               "6","7","8","9"," "," "," "," "};

        List<byte> data = new List<byte>();

        public void AddByte(byte b) {
            data.Add(b);
        }

        public string Decode()
        {
            var text = new StringBuilder();
            int value;
            int c1, c2, c3;

            for (int i = 0; i < data.Count; i += 2)
            {
                value = data[i + 1] * 256 + data[i];
                c1 = (int)(value / 1600);
                value -= c1 * 1600;

                c2 = (int)(value / 40);
                c3 = value - (c2 * 40);

                //if (c1 > 39) c1 = 0;
                //if (c2 > 39) c2 = 0;
                //if (c3 > 39) c3 = 0;

                text.Append(characters[c1]);
                text.Append(characters[c2]);
                text.Append(characters[c3]);
            }
            return text.ToString();
        }
    }
}
