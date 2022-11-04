using staj_r_backend.Helper;
using staj_r_backend.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace staj_r_backend.Models
{
    public class LoginModel
    {
        Executor ex;
        public LoginModel()
        {
            ex = new Executor();
        }
        public async Task<User> login(string number, string encryptedPassword)
        {
            string pass = encryptedPassword;
            string query = $"MATCH(u:User)-[:MEMBER]->(r:Role) WHERE u.number = '{number}' AND u.password= '{pass}' RETURN " +
                $"COUNT(u) AS ct, " +
                $"u.name AS nm, " +
                $"u.surname AS sn, " +
                $"u.email AS em, " +
                $"u.department AS dep, " +
                $"ID(r) AS ri, " +
                $"r.name AS role, " +
                $"r.authorities AS auth";
            var qres = await ex.executeOneNode(query);
            if ((long)qres["ct"] == 0)
            {
                return null;
            }
            else
            {
                return new User()
                {
                    number = number,
                    name = (string)qres["nm"],
                    surname = (string)qres["sn"],
                    email = (string)qres["em"],
                    department = (string)qres["dep"],
                    roleID = (long)qres["ri"],
                    role = (string)qres["role"],
                    authorities = ((List<object>)qres["auth"]).Select(e => (string)e).ToList(),
                };
            }
        }
    }
}
