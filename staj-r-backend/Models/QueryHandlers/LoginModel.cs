using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using System.Text.Json;
using staj_r_backend.Helper;
using staj_r_backend.Helper.Token;
using staj_r_backend.Models.Entities;

namespace staj_r_backend.Models.QueryHandlers
{
    public class LoginModel
    {
        public async Task<List<User>> login(long number, string password)
        {
            try
            {
                password = new Md().toMd5(password);
                Executor executor = new Executor();
                string query = $"MATCH (u:User) WHERE u.number = {number} AND u.password = {password}" +
                    $"RETURN u, COUNT(u) AS c";
                IResultCursor cursor = await executor.execute(query);
                List<string> res = await cursor.ToListAsync(record => record["u"].As<string>());
                List<User> liste = new List<User>();
                foreach (string item in res)
                {
                    liste.Add(JsonSerializer.Deserialize<User>(item));
                }
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: ", ex);
            }
        }
    }
}
