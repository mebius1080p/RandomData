using System;
using System.IO;
using System.Security.Cryptography;

namespace RandomData
{
    class Program
    {
        static void Main(string[] args)
        {
            string mb = args[0];
            int numMB = 0;
            bool isNumConversionSuccess = int.TryParse(mb, out numMB);
            if (!isNumConversionSuccess)
            {
                Console.WriteLine("enter number arg");
                return;
            }
            int byteSize = numMB * 1024 * 1024;
            byte[] bytes = new byte[byteSize];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(bytes);

            using (FileStream fs = new FileStream("random.data", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
