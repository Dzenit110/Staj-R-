using staj_r_backend.Helper;
using staj_r_backend.Models;
using staj_r_backend.Models.Entities;
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
        public async Task<bool> register(string number, string name, string surname, string email, string department, int roleID)
        {
            try
            {
                return await registerCommon(number, name, surname, email, department, roleID);
            }
            catch
            {
                return false;
            }
        }
        //Departman bilgisi yoksa kullanılır.
        public async Task<bool> register(string number, string name, string surname, string email, int roleID)
        {
            try
            {
                string department = number.Substring(2, 4);
                return await registerCommon(number, name, surname, email, department, roleID);
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> registerCommon(string number, string name, string surname, string email, string department, int roleID)
        {
            PasswordHelper ph = new PasswordHelper();
            string password = ph.generatePass();
            string encrypted = ph.encrypt(password);
            string message = $"Merhaba {name}!<br>Staj-R kullanıcı kaydınız başarılı bir şekilde yapılmıştır. Sisteme okul numaranız ve bu e-postada yer alan " +
                "parolanız ile giriş yapabilirsiniz.<br>" +
                $"<br><br><b>PAROLANIZI KİMSEYLE PAYLAŞMAYINIZ!</b><br><br><br>Parolanız: {password}<br><br>" +
                $"Hemen sisteme giriş yapmak için <a href=\"www.stajr.azurewebsites.net/stajR\">buraya</a> tıklayınız.";
            await SendMail.sendMail(email, "Staj-R Kullanıcı Kaydınız", message);
            UserModel um = new UserModel();
            return await um.registerModel(number, name, surname, email, encrypted, department, roleID);
        }

        public async Task<List<UserModel.role_auth>> getRoles()
        {
            try
            {
                UserModel um = new UserModel();
                var res = await um.getRoles();
                return res;
            }
            catch
            {
                return null;
            }
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
        public async Task<List<UserModel.userList>> getUsers(string number)
        {
            try
            {
                UserModel um = new UserModel();
                return await um.getUsers(number);
            }
            catch
            {
                return null;
            }
        }
        #region Kullanıcılar sayfası popup
        public async Task<Dictionary<int,string>> getRolesForDropdown(string number)
        {
            try
            {
                UserModel um = new UserModel();
                return await um.getRolesForDropDown(number);
            }
            catch
            {
                return null;
            }
        }  
        public async Task<bool> updateRole(string number, int roleID)
        {
            try
            {
                UserModel um = new UserModel();
                return await um.updateRole(number, roleID);
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> updateEmail(string number, string email)
        {
            try
            {
                UserModel um = new UserModel();
                return await um.updateEmail(number, email);
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> updatePassword(string number)
        {
            try
            {
                PasswordHelper ph = new PasswordHelper();
                string password = ph.generatePass();
                string encrypted = ph.encrypt(password);
                UserModel um = new UserModel();
                List<string> list = await um.updatePassword(number, encrypted);
                string name = list[0];
                string email = list[1];
                string message = $"Merhaba {name}!<br>Staj-R kullanıcı parolanız sıfırlanmıştır. Sisteme okul numaranız ve bu e-postada yer alan yeni" +
                    "parolanız ile giriş yapabilirsiniz.<br>" +
                    $"<br><br><b>PAROLANIZI KİMSEYLE PAYLAŞMAYINIZ!</b><br><br><br>Parolanız: {password}<br><br>" +
                    $"Hemen sisteme giriş yapmak için <a href=\"www.stajr.azurewebsites.net/stajR\">buraya</a> tıklayınız.";
                await SendMail.sendMail(email, "Staj-R Şifre Değişikliği", message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
