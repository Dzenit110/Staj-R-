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
using System.Net.Http;
using System.IO;
using ConvertApiDotNet;
using System.Text;
using Microsoft.JSInterop;

namespace staj_r_backend_test
{
    public class Program
    {
        enum varas
        {
            adana = 2, bursa = 3
        }

        private static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("https://back.onlineconvertfree.com/api/external/api/add-convert/"),
        };
        static async Task Main(string[] args)
        {

            
            //var res = await UserController.registerDepManager("456154854", "Deneme İsmi", "Deneme Soyismi", "4513", "kixede8546@ilusale.com");
            DocumentController dc = new DocumentController();
            DailyReport dr = new DailyReport()
            {
                aciklama_GT6ExY2 = "Önder ",
                tarih_Rvt9hVm = new DateTime(2022, 10, 31),
                yapilan_is_QHt6wvC = "ALPCAN İÇİN",
            };
            SaveStreamAsFile(@"C:\Users\CASPER\Desktop\SON DOCX\", await dc.getDailyReport(dr), "ALPCN.docx");
        }


        public static void SaveStreamAsFile(string filePath, Stream inputStream, string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(filePath);
            if (!info.Exists)
            {
                info.Create();
            }

            string path = Path.Combine(filePath, fileName);
            using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
            {
                inputStream.CopyTo(outputFileStream);
            }
        }

    }

}


/*
 private static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("https://back.onlineconvertfree.com/api/external/api/add-convert/"),
        };
        static async Task Main(string[] args)
        {
            string file = File.ReadAllText(@"C:\Users\CASPER\Desktop\DENEMELER\StajKabul.xml");
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(file));
            var convertApi = new ConvertApi("stK35LEUnutFwJ0B");
            var convertres = await convertApi.ConvertAsync("xml","doc", new ConvertApiFileParam(stream, "test.xml"));
            var outputStream = await convertres.Files[0].FileStreamAsync();
            SaveStreamAsFile(@"C:\Users\CASPER\Desktop\DENEMELER\", outputStream, "yenidoc");
        }


        public static void SaveStreamAsFile(string filePath, Stream inputStream, string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(filePath);
            if (!info.Exists)
            {
                info.Create();
            }

            string path = Path.Combine(filePath, fileName);
            using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
            {
                inputStream.CopyTo(outputFileStream);
            }
        }
*/