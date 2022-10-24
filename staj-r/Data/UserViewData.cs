using staj_r_backend.Controllers;
using System.Collections.Generic;
using staj_r_backend.Models;
using System.Threading.Tasks;

namespace staj_r.Data
{
    public class UserViewData
    {
        #region Testte
        

        #endregion
        #region Bitenler
        UserController uc;

        public UserViewData()
        {
            uc = new UserController();
        }

        public async Task<List<UserModel.userList>> getUsers(string token)
        {
            string number = getFromToken(token).number;
            return await uc.getUsers(number);
        }
        
        public async Task<List<UserModel.role_auth>> getRoles()
        {
            return await uc.getRoles();
        }
        #region Kullanıcılar Sayfası Popup
        public async Task<Dictionary<int,string>> getRolesForDropdown(string token)
        {
            string number = getFromToken(token).number;
            return await uc.getRolesForDropdown(number);
        }
        public async Task<bool> updateRole(string number, int roleID)
        {
            return await uc.updateRole(number, roleID);
        }
        public async Task<bool> updateEmail(string number, string email)
        {
            return await uc.updateEmail(number, email);
        }
        public async Task<bool> updatePassword(string number)
        {
            return await uc.updatePassword(number);
        }
        #endregion

        #endregion
        #region Ek Metotlar
        private staj_r_backend.Models.Entities.TokenEntity getFromToken(string token)
        {
            return new staj_r_backend.Helper.Token.Token().decrypt(token);
        }

        //Örn:      string number = getFromToken(token).number;
        #endregion
    }
}
