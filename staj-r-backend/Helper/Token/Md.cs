using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace staj_r_backend.Helper.Token
{
    public class Md
    {
        public string toMd5(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] arr = Encoding.UTF8.GetBytes(password);
            arr = md5.ComputeHash(arr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in arr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

    }
}
