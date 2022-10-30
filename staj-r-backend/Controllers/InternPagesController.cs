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
    public class InternPagesController
    {
        private static InternPagesModel ipm = new InternPagesModel();
        private static Token tokenClass = new Token();

        public static async Task<bool> manageApplyingDates(string token, internships en, internDateForDeps dates, bool isNewEra)
        {
            try
            {
                TokenEntity tken = tokenClass.decrypt(token);
                return await ipm.manageApplyingDates(tken.number, en, dates, isNewEra);
            }
            catch
            {
                return false;
            }
        }
    }
}



/* 
 
 
 public static async Task<bool> manageApplyingDates(string number, internships en, internDateForDeps dates, bool isNewEra)
        {
            try
            {

            }
            catch
            {
                return false;
            }
            
        }


*/