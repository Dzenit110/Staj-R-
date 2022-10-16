using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using System.Text.Json;
using staj_r_backend.Helper;
using staj_r_backend.Models.Entities;

namespace staj_r_backend.Models.QueryHandlers
{
    public class PhoneHandlers
    {
        
        /*
        public async Task<List<Phone>> getPhonesHandler(string query, string variable)
        {
            try
            {
                Executor executor = new Executor();
                IResultCursor cursor = await executor.execute(query);
                List<string> res = await cursor.ToListAsync(record => record[variable].As<string>());
                List<Phone> liste = new List<Phone>();
                foreach (string item in res)
                {
                    liste.Add(JsonSerializer.Deserialize<Phone>(item));
                }
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: ", ex);
            }
        }
        */
    }
}
