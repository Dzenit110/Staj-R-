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
using System.Net.Mail;
using System.Net;
using System.Reflection;
using Neo4j.Driver;

namespace staj_r_backend_test
{
    public class Program
    {
        enum varas
        {
            adana = 2, bursa = 3
        }
        static async Task Main(string[] args)
        {
            Executor ex = new Executor();
            var y = await ex.executeOneNode($"RETURN false");
        }
        


    }

    class y
    {
        public string q { get; set; }
        public string a { get; set; }
        public yardakul c { get; set; }
        public enum yardakul{
            kuddus, yardak, fırusi, fuzuli
        }
    }
   
}
