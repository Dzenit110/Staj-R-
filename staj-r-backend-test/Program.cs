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

namespace staj_r_backend_test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //CREATE(b: Role{ name: "Kurum Yetkilisi", authorities: ["j","k"]})
            await new UserModel().createRole("Kurum Yetkilisi", new List<string> { "j", "k" });
        }
    }
}
