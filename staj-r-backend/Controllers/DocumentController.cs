using staj_r_backend.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using staj_r_backend.Controllers.Documents;
using System.Threading.Tasks;
using System.IO;
using ConvertApiDotNet;

namespace staj_r_backend.Controllers
{
    public class DocumentController
    {
        private static List<string> secrets = new List<string>
        {
            "kOCZJfono8n7jjwS",
            "alWHagP5z9HVgvPd",
            "CxHMXWgYhcAXVqSO",
            "28gXqbrxbgNg28OQ",
            "tWj4kIfC4ryGbiNx",
            "VzBUddNe693Px7di",
            "nYKkPAHdnvbmzOHg",
            "xlki0bX3xe5ndFEr",
            "stK35LEUnutFwJ0B",
            "GcUvcBlHNYMr1yHh",
            "lS3GznxUCyzBQoTm",
            "rxvaLnjy8p9gCB2i",
            "tVn2VnJ7sLXQbVki",
            "HTa6lvBMOzwA7BJW",
        };

        private async Task<Stream> xmlToDocx(IDocument doc)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(doc.xml));
            var convertApi = new ConvertApi(secrets[new Random().Next(secrets.Count)]);
            var convertres = await convertApi.ConvertAsync("xml", "docx", new ConvertApiFileParam(stream, "dailyReport.xml"));
            var outputStream = await convertres.Files[0].FileStreamAsync();
            return outputStream;
        }
        public async Task<Stream> getDailyReport(DailyReport dr)
        {
            DailyReportXML drx = new DailyReportXML(dr);
            return await xmlToDocx(drx);
        }
    }
}
