using System;
//using System.Drawing;
//using System.Security.Cryptography;
//using System.Windows.Media.Media3D;

namespace JTfy
{
    public class RNGCryptoServiceProvider
    {
        private readonly Random random = new Random();

        public void GetBytes(byte[] buffer) => random.NextBytes(buffer);
    }
}