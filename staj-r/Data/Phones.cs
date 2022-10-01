using staj_r_backend;
using staj_r_backend.Controllers;
using staj_r_backend.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace staj_r.Data
{
    public class Phones
    {
        private PhoneControllers phoneControllers;

        public Phones()
        {
            phoneControllers = new PhoneControllers();
        }
        public async Task<List<Phone>> getPhones()
        {
            return await phoneControllers.getPhones();
        }
    }
}
