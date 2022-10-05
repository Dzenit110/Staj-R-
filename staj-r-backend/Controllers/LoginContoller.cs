using staj_r_backend.Models;
using staj_r_backend.Models.QueryHandlers;
using staj_r_backend.Models.Queries;
using staj_r_backend.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace staj_r_backend.Controllers
{
    public class LoginContoller
    {
        public async Task<User> checkTokenController(string token)
        {
            Helper.Token.Token tk = new Helper.Token.Token();
            TokenEntity decrypted = tk.decrypt(token);
            LoginModel lm = new LoginModel();
            return await lm.login(decrypted.number, decrypted.password);
        }
    }
}
