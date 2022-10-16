using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using staj_r_backend.Models.Entities;
using System.IO;

namespace staj_r_backend.Helper
{
    class CsvReader
    {
        public List<User> readCsv(string path, string name, string surname, string email, string number, List<string> authorities)
        {
            string[] array = File.ReadAllLines(path);
            string[] columns = array[0].Split(",");
            int namec = 0;
            int surnamec = 0;
            int emailc = 0;
            int numberc = 0;
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i].ToLower() == "isim" || columns[i].ToLower() == "name")
                {
                    namec = i;
                }
                if (columns[i].ToLower() == "soyisim" || columns[i].ToLower() == "surname")
                {
                    surnamec = i;
                }
                if (columns[i].ToLower() == "eposta" || columns[i].ToLower() == "email")
                {
                    emailc = i;
                }
                if (columns[i].ToLower() == "numara" || columns[i].ToLower() == "number")
                {
                    numberc = i;
                }
            }
            List<User> liste = new List<User>();
            for (int i = 1; i < array.Length; i++)

            {
                string[] arrrow = array[i].Split(',');
                liste.Add(new User
                {
                    name = arrrow[namec],
                    surname = arrrow[surnamec],
                    email = arrrow[emailc],
                    number = arrrow[numberc],
                    department = arrrow[numberc].Substring(2, 4),
                    authorities = authorities,
                    password = createPass()
                });
            }
            return liste;
        }
        public string createPass()
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
