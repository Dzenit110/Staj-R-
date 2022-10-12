using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using System.Text.Json;
using staj_r_backend.Models.Entities;

namespace staj_r_backend.Helper
{
    public class Executor
    {

        IDriver driver;
        IAsyncSession session;

        public Executor()
        {
            driver = GraphDatabase.Driver("neo4j+s://aa0402bf.databases.neo4j.io", AuthTokens.Basic("neo4j", "9C4fhCdcl0krjwTgb7vZNAvuW8FQrv4YsPN7cRfGOuE"));
            session = driver.AsyncSession(o => o.WithDatabase("neo4j"));
        }
        public async Task<IResultCursor> execute(string query)
        {
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                return cursor;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: ", ex);
            }
        }

        public async Task<bool> executeReturnless(string query)
        {
            try
            {
                await session.RunAsync(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<string>> moreVariableOneNode(string query, List<string> variables)
        {
            List<string> jsons = new List<string>();
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                await cursor.FetchAsync();
                List<object> currents = new List<object>();
                foreach (string variable in variables)
                {
                    currents.Add(cursor.Current[variable]);
                }
                List<string> result = new List<string>();
                foreach (object current in currents)
                {
                    result.Add(JsonSerializer.Serialize(current));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: ", ex);
            }
        }

        public async Task<string> oneVariableOneNode(string query, string variable)
        {
            try
            {

                IResultCursor cursor = await session.RunAsync(query);
                await cursor.FetchAsync();
                var current = cursor.Current[variable];
                string result = JsonSerializer.Serialize(current);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Executor/ExecuteOneJson metodunda hata: ", ex);
            }
        }

        public async Task<List<string>> oneVariableMoreNodes(string query, string variable)
        {
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                List<IRecord> records = await cursor.ToListAsync();
                List<string> jsons = new List<string>();
                foreach (IRecord record in records)
                {
                    jsons.Add(JsonSerializer.Serialize(record.Values[variable]));
                }
                return jsons;
            }
            catch (Exception ex)
            {
                throw new Exception("Executor/ExecuteOneJson metodunda hata: ", ex);
            }
        }

        public async Task<List<List<string>>> moreVariableMoreNodes(string query, List<string> variables)
        {
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                List<IRecord> records = await cursor.ToListAsync();
                List<List<string>> result = new List<List<string>>();
                foreach (string variable in variables)
                {
                    List<string> jsons = new List<string>();
                    foreach (IRecord record in records)
                    {

                        jsons.Add(JsonSerializer.Serialize(record.Values[variable]));

                    }
                    result.Add(jsons);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Executor/ExecuteOneJson metodunda hata: ", ex);
            }
        }


        ~Executor()
        {
            session.CloseAsync();
            driver.CloseAsync();
        }
    }
}
