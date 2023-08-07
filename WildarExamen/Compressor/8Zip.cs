using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildarExamen.Compressor
{
    class _8Zip
    {
        private byte[] toCompress { get; set; }
        public _8Zip()
        {

        }

        public _8Zip(byte[] toCompress)
        {
            this.toCompress = toCompress;
        }

        public _8Zip(List<byte> toCompress)
        {
            this.toCompress = toCompress.ToArray();
        }

        public byte[] Compress()
        {
            int compressedSize = 0;
            //Calculo el tamaño del array previamente
            for (int i = 1; i < toCompress.Length; i++)
            {
                if ((i + 1) < toCompress.Length && toCompress[i] != toCompress[i + 1])
                {
                    compressedSize += 2; //Sumo de a dos, ya que es cantidad, valor
                }
            }
            compressedSize += 2; // Contar el último valor y cantidad

            byte[] compressed = new byte[compressedSize];
            byte arrayCount = 0;
            byte count = 1;
            byte value = 0;
            for (byte i = 0; i < toCompress.Length; i++)
            {
                if (count == 1)
                    value = toCompress[i];

                if ((i + 1) != toCompress.Length)
                {
                    if (toCompress[i + 1] == value)
                    {
                        //Si el siguiente valor es igual al actual, entonces, aumento el contador
                        count++;
                    }
                    else
                    {
                        //Sino, agrego al array y aumento en 2 el contador
                        compressed[arrayCount] = count;
                        compressed[arrayCount + 1] = value;

                        arrayCount += 2;
                        count = 1;
                    }
                }
                else
                {
                    //estamos en el último
                    //Sino, agrego al array y aumento en 2 el contador
                    compressed[arrayCount] = count;
                    compressed[arrayCount + 1] = value;

                    arrayCount += 2;
                }
            }
            return compressed;
        }
    }
}
