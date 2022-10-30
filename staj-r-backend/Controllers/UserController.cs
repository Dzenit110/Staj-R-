using staj_r_backend.Helper;
using staj_r_backend.Helper.Token;
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
        public static async Task<bool> registerOther(string number, string name, string surname, string email, string token, int roleID)
        {
            try
            {
                string uNumber = new Token().decrypt(token).number;
                return await registerCommon(number, name, surname, email, null, roleID, uNumber);
            }
            catch
            {
                return false;
            }
        }
        //Departman bilgisi yoksa kullanılır.
        public static async Task<bool> registerDepManager(string number, string name, string surname, string department, string email, int roleID)
        {
            try
            {
                return await registerCommon(number, name, surname, email, department, roleID, null);
            }
            catch
            {
                return false;
            }
        }

        //uNumber: İşlemi gerçekleştiren kullanıcının numarasıdır. =>
        private static async Task<bool> registerCommon(string number, string name, string surname, string email, string department, int roleID, string uNumber)
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
            return await um.registerModel(number, name, surname, email, encrypted, department, roleID, uNumber);
        }

        public static async Task<Result<List<role_auth>>> getRoles()
        {
            try
            {
                UserModel um = new UserModel();
                var res = await um.getRoles();
                if(res == null)
                {
                    return new Result<List<role_auth>>(false);
                }
                return new Result<List<role_auth>>()
                {
                    isSuccess = true,
                    value = res,
                };
            }
            catch
            {
                return new Result<List<role_auth>>();
            }
        }
        public static async Task<bool> createRole(string name, List<string> authorities) 
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
        public static async Task<Result<List<userList>>> getUsers(string number)
        {
            try
            {
                UserModel um = new UserModel();
                var qres = await um.getUsers(number);
                if(qres == null)
                {
                    return new Result<List<userList>>(false);
                }
                else
                {
                    return new Result<List<userList>>()
                    {
                        isSuccess = true,
                        value = qres,
                    };
                }
            }
            catch
            {
                return new Result<List<userList>>(false);
            }
        }
        #region Kullanıcılar sayfası popup
        public static async Task<Result<Dictionary<int,string>>> getRolesForDropdown(string number)
        {
            try
            {
                UserModel um = new UserModel();
                var res = await um.getRolesForDropDown(number);
                if (res == null)
                {
                    return new Result<Dictionary<int, string>>(false);
                }
                else
                {
                    return new Result<Dictionary<int, string>>
                    {
                        isSuccess = true,
                        value = res,
                    };

                }                
            }
            catch
            {
                return new Result<Dictionary<int, string>>(false);
            }
        }  
        public static async Task<bool> updateRole(string number, int roleID)
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
        public static async Task<bool> updateEmail(string number, string email)
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
        public static async Task<bool> updatePassword(string number)
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
