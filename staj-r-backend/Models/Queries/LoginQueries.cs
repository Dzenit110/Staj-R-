using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_r_backend.Models.Queries
{
    public class LoginQueries
    {
        public LoginQueries(long number)
        {

        }
        public static string loginQuery = $"MATCH(u:User) WHERE u.number = ";
    }
}
