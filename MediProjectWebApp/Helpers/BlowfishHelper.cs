using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MediProjectWebApp.Helpers
{
    public static class BlowfishHelper
    {
        public static string EncryptBlowfish(string plainText, string key)
        {
            var engine = new BlowfishEngine();
            var blockCipher = new PaddedBufferedBlockCipher(engine);
            var keyBytes = Encoding.UTF8.GetBytes(key);

            blockCipher.Init(true, new KeyParameter(keyBytes));

            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] outputBytes = new byte[blockCipher.GetOutputSize(inputBytes.Length)];
            int length = blockCipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            blockCipher.DoFinal(outputBytes, length);

            return Convert.ToBase64String(outputBytes);
        }
    }
}