using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

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
            //Stream stree = await new DocumentController().getDailyReport(new DailyReport()
            //{
            //    aciklama_GT6ExY2 = "Önder ",
            //    tarih_Rvt9hVm = new DateTime(2022, 10, 31),
            //    yapilan_is_QHt6wvC = "ALPCAN İÇİN",
            //});
            //StreamReader reader = new StreamReader(stree);
            //string res = reader.ReadToEnd();
            //Token tkn = new Token();
            //UserWToken uwt = new UserWToken()
            //{
            //    token = "eykodfsjıdjsfjsdljdlckjlvdf",
            //    tokenExpiresOn = DateTime.Now,
            //    user = new User()
            //    {
            //        authorities = new List<string>
            //        {
            //            "a", "b", "c", "d"
            //        },
            //        department = "dsıfdsf",
            //        email = "fdksfjdopsjfsd",
            //        surname = "sdklfdjsdf",
            //        name = "djsfhsfdfdsf",
            //        number = "547456165",
            //        role = "dlfjsdjfpsodf",
            //        roleID = 74,
            //    }
            //};
            //var a = tkn.encryptUserWToken(uwt);
            //var b = tkn.decryptUserWToken(a);

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