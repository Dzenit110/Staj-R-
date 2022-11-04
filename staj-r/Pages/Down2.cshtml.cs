using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace staj_r.Pages
{
    public class Down2Model : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public Down2Model(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<IActionResult> OnGet(string stree, string filename)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(stree);
            MemoryStream stream = new MemoryStream(byteArray);
            return File(stream, "application/force-download", filename + ".docx");
        }
    }
}
