using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CMCMS
{
    class PasswordHash
    {
        public static String getHashedPw(string plainTextPw)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainTextPw);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
