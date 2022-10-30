using staj_r_backend.Models;
using staj_r_backend.Models.QueryHandlers;
using staj_r_backend.Models.Queries;
using staj_r_backend.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using staj_r_backend.Helper.Token;
using System;
using staj_r_backend.Helper;

namespace staj_r_backend.Controllers
{
    public class LoginContoller
    {       
        public async Task<Result<UserWToken>> checkTokenController(string token)
        {
            try
            {
                Helper.Token.Token tk = new Helper.Token.Token();
                TokenEntity decrypted = tk.decrypt(token);
                if (decrypted.expiresOn <= DateTime.Now)
                {
                    return new Result<UserWToken>();
                }
                LoginModel lm = new LoginModel();
                string encrypted = new PasswordHelper().encrypt(decrypted.password);
                User us = await lm.login(decrypted.number, encrypted);
                if(us == null){
                    return new Result<UserWToken>();
                }
                else
                {
                    return new Result<UserWToken>()
                    {
                        isSuccess = true,
                        value = new UserWToken
                        {
                            token = token,
                            tokenExpiresOn = decrypted.expiresOn,
                            user = us,
                        },
                    };
                }
            }
            catch
            {
                return new Result<UserWToken>();
            }
        }
        public async Task<Result<UserWToken>> loginWithoutToken(string number, string password)
        {
            try
            {
                string encrypted = new PasswordHelper().encrypt(password);
                LoginModel lm = new LoginModel();
                User us = await lm.login(number, encrypted);
                if(us != null)
                {
                    TokenResult tokenres = new Token().encrypt(new TokenEntity
                    {
                        number = number,
                        password = password,
                        expiresOn = DateTime.Now,
                    });

                    UserWToken uwt = new UserWToken
                    {
                        token = tokenres.token,
                        tokenExpiresOn = tokenres.tokenExpiresOn,
                        user = us,
                    };
                    return new Result<UserWToken>
                    {
                        isSuccess = true,
                        value = uwt,
                    };
                }
                else
                {
                    return new Result<UserWToken>();
                }
            }
            catch
            {
                return new Result<UserWToken>();
            }            
        }
        
    }
}






/*
  
  
  
  
  
 
 try
            {

            }
            catch
            {
                return new Result<UserWToken>
                {
                    isSuccess = false,
                    value = null,
                };
            }





*/