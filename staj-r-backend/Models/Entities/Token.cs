using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_r_backend.Models.Entities
{
    public class Token
    {
        public long number { get; set; }

        public string password { get; set; }

        public DateTime tokenExpiresOn { get; set; }
    }
}
