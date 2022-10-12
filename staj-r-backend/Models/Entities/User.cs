using System;
using System.Collections.Generic;
namespace staj_r_backend.Models.Entities
{
    public class User
    {
        public string number { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string department { get; set; }
        public List<char> roles { get; set; }
    }
}
