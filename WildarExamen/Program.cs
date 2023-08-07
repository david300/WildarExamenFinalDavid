using System;

namespace WildarExamen
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] arrayToCompress = { 170, 170, 170, 170, 2, 1 };
            byte[] compressed;
            Compressor._8Zip _zip = new Compressor._8Zip(arrayToCompress);
            compressed = _zip.Compress();

            foreach (var item in compressed)
            {
                Console.WriteLine(item);
            }
        }
    }
}
