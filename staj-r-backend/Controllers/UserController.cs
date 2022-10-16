using staj_r_backend.Helper;
using staj_r_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_r_backend.Controllers
{
    public class UserController
    {
        //Departman bilgisi varsa kullanılır.
        public async Task<bool> register(string number, string name, string surname, string email, string department, List<int> rolesID)
        {
            try
            {
                return await registerCommon(number, name, surname, email, department, rolesID);
            }
            catch
            {
                return false;
            }
        }
        //Departman bilgisi yoksa kullanılır.
        public async Task<bool> register(string number, string name, string surname, string email, List<int> rolesID)
        {
            try
            {
                string department = number.Substring(2, 4);
                return await registerCommon(number, name, surname, email, department, rolesID);
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> registerCommon(string number, string name, string surname, string email, string department, List<int> rolesID)
        {
            PasswordHelper ph = new PasswordHelper();
            string password = ph.generatePass();
            string encrypted = ph.encrypt(password);
            //password değeri email ile gönderilecek
            UserModel um = new UserModel();
            return await um.registerModel(number,name,surname,email,password,department,rolesID);
        }

        public async Task<bool> createRole(string name, List<string> authorities) 
        {
            try
            {
                UserModel um = new UserModel();
                return await um.createRole(name, authorities);
            }
            catch
            {
                return false;
            }
        }
    }
}
