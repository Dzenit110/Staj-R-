using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using staj_r_backend.Models.Entities;
using staj_r_backend.Helper;

namespace staj_r_backend.Models
{
    public class UserModel
    {
        public async Task<bool> registerModel(string number, string name, string surname, string email, string password, string department, List<int> rolesID)
        {
            try
            {
                string roles = "[";
                for (int j = 0; j < rolesID.Count; j++)
                {
                    if (j == rolesID.Count - 1)
                    {
                        roles += $"'{rolesID[j]}'";
                    }
                    else
                    {
                        roles += $"'{rolesID[j]}',";
                    }
                }
                string query = $"CREATE(u:User{{number:'{number}', name:'{name}', surname: '{surname}', rolesID ={roles}, email:'{email}',password:'{password}', department:'{department}'}})";
                Executor ex = new Executor();
                return await ex.executeReturnless(query);
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> createRole(string name, List<string> authorities)
        {
            try
            {
                string auth = "[";
                for (int j = 0; j < authorities.Count; j++)
                {
                    if (j == authorities.Count - 1)
                    {
                        auth += $"'{authorities[j]}'";
                    }
                    else
                    {
                        auth += $"'{authorities[j]}',";
                    }
                }
                auth += "]";
                string query = "CREATE(n:Role{name:'"+name+"', authorities:"+auth+"})";
                Executor ex = new Executor();
                return await ex.executeReturnless(query); 
            }
            catch
            {
                return false;
            }

        }
    }
}
