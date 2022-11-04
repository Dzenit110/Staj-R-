using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using staj_r_backend.Controllers;
using staj_r_backend.Models.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace staj_r.Pages
{
    public class DownClass : PageModel
    {
        public async Task<IActionResult> OnGet(string filename)
        {
            Stream stree = await new DocumentController().getDailyReport(new DailyReport()
            {
                aciklama_GT6ExY2 = "Önder ",
                tarih_Rvt9hVm = new DateTime(2022, 10, 31),
                yapilan_is_QHt6wvC = "ALPCAN İÇİN",
            });
            return File(stree, "application/force-download", filename + ".docx");
        }
    }
}
