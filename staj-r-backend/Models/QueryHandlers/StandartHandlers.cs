using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using System.Text.Json;
using staj_r_backend.Helper;

namespace staj_r_backend.Models.QueryHandlers
{
    public class StandartHandlers
    {
        //Geri dönüş alınmasına ihtiyaç olmayan metotlar için kullanılır. 
        //Çalışıp çalışmama durumuna göre true/false döndürür.
        public async Task<bool> runReturnless(string query)
        {
            try
            {
                Executor executor = new Executor();
                return await executor.executeReturnless(query);
            }
            catch
            {
                return false;
            }
        }

        //Birden fazla string değişkenin tek tek istendiği durumlar için kullanılır.
        //Listede gönderilen değişkenleri sırasıyla yeni bir listede döndürür.
        public async Task<List<string>> singleValueString(string query, List<string> variables)
        {
            try
            {
                Executor executor = new Executor();
                IResultCursor cursor = await executor.execute(query);
                IRecord record = await cursor.SingleAsync();
                List<string> result = new List<string>();
                foreach (string item in variables)
                {
                    result.Add(record[item].As<string>());
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> singleValueString(string query, string variable)
        {
            try
            {
                Executor executor = new Executor();
                IResultCursor cursor = await executor.execute(query);
                IRecord record = await cursor.SingleAsync();
                return record[variable].As<string>();
            }
            catch
            {
                throw;
            }
        }
    }
}
