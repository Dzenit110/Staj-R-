using System;
using System.Text.Json;
using System.Threading.Tasks;
using staj_r_backend;
using staj_r_backend.Controllers;
using staj_r_backend.Helper;
using staj_r_backend.Helper.Token;
using staj_r_backend.Models.Entities;
using staj_r_backend.Models;
using staj_r_backend.Models.Queries;
using staj_r_backend.Models.QueryHandlers;
using System.Collections.Generic;
using System.Linq;

namespace staj_r_backend_test
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var y = new Token().encrypt(new TokenEntity()
            {
                number = "adanamerkez",
                password = "5425454",
                expiresOn = DateTime.Now,
            });
            var x = new Token().decrypt(y);
            var z = (x.expiresOn - DateTime.Now);
            string q = (x.expiresOn - DateTime.Now).Hours.ToString()+" : "+ (x.expiresOn - DateTime.Now).Minutes.ToString()+" : "+ (x.expiresOn - DateTime.Now).Seconds.ToString();
        }
    }
}
