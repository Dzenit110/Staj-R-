using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using SpassByMyurga;

namespace staj_r_backend.Helper
{
    public class PasswordHelper
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

        public string encrypt(string password)
        {
            SpassEnc enc = new SpassEnc(password);
            return enc.getPass40(7452100);
        }

        public string generatePass()
        {
            string chars = "QWERTYUOPASDIFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890~`!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/";
            string pass = "";
            for (int i = 0; i < 12; i++)
            {
                pass += chars[new Random().Next(chars.Length - 1)];
            }
            return pass;
        }

    }
}
