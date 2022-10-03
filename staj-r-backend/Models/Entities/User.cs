using System;
using System.Collections.Generic;
namespace staj_r_backend.Models.Entities
{
    public class User
    {
        public long number { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public DateTime registrationYear { get; set; }
        public List<string> roles { get; set; }
        public DateTime tokenExpiresOn { get; set;}
    }
}
