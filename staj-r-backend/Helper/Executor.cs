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
        public async Task<IDictionary<string, List<object>>> execute(string query)
        {
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                List<IRecord> jsonsList1 = await cursor.ToListAsync();
                IDictionary<string, List<object>> dictionary = new Dictionary<string, List<object>>();
                foreach (IRecord item in jsonsList1)
                {
                    foreach (string key in item.Keys)
                    {
                        if (!dictionary.ContainsKey(key))
                        {
                            dictionary.Add(key, new List<object>());
                        }
                    }
                    foreach (var node in item.Values)
                    {
                        if (node.Value == null)
                        {
                            dictionary[node.Key].Add(null);
                        }
                        else if (node.Value.GetType().ToString() == "Neo4j.Driver.Internal.Types.Node")
                        {
                            dictionary[node.Key].Add(new NodeEntities((INode)node.Value));
                        }
                        else if (node.Value.GetType().ToString() == "Neo4j.Driver.LocalDate" || node.Value.GetType().ToString() == "Neo4j.Driver.LocalDateTime"
                            || node.Value.GetType().ToString() == "Neo4j.Driver.LocalTime" || node.Value.GetType().ToString() == "Neo4j.Driver.ZonedDateTime")
                        {
                            int year = ((LocalDate)node.Value).Year;
                            int month = ((LocalDate)node.Value).Month;
                            int day = ((LocalDate)node.Value).Day;
                            dictionary[node.Key].Add(new DateTime(year, month, day));
                        }
                        else
                        {
                            dictionary[node.Key].Add(node.Value);
                        }
                    }
                }
                return dictionary;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: ", ex);
            }
        }
        public async Task<IDictionary<string, object>> executeOneNode(string query)
        {
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                List<IRecord> jsonsList1 = await cursor.ToListAsync();
                IDictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (IRecord item in jsonsList1)
                {
                    foreach (string key in item.Keys)
                    {
                        if (!dictionary.ContainsKey(key))
                        {
                            dictionary.Add(key, new List<object>());
                        }
                    }
                    foreach (var node in item.Values)
                    {
                        if (node.Value == null)
                        {
                            dictionary[node.Key] = null;
                        }
                        else if (node.Value.GetType().ToString() == "Neo4j.Driver.Internal.Types.Node")
                        {
                            dictionary[node.Key] = new NodeEntities((INode)node.Value);
                        }
                        else if (node.Value.GetType().ToString() == "Neo4j.Driver.LocalDate" || node.Value.GetType().ToString() == "Neo4j.Driver.LocalDateTime"
                            || node.Value.GetType().ToString() == "Neo4j.Driver.LocalTime" || node.Value.GetType().ToString() == "Neo4j.Driver.ZonedDateTime")
                        {
                            int year = ((LocalDate)node.Value).Year;
                            int month = ((LocalDate)node.Value).Month;
                            int day = ((LocalDate)node.Value).Day;
                            dictionary[node.Key] = new DateTime(year, month, day);
                        }
                        else
                        {
                            dictionary[node.Key] = node.Value;
                        }
                    }
                }
                return dictionary;
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
                await (await session.RunAsync(query)).FetchAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////       
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#region denemeler




        public async Task<string> execute1(string query)
        {
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                List<string> jsonsList = await cursor.ToListAsync(x =>JsonSerializer.Serialize(x.Values.Values.ToList()[0]));
                return JsonSerializer.Serialize(jsonsList);
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: ", ex);
            }
        }
        public async Task<IDictionary<string, List<string>>> execute2(string query, string[] variables)
        {
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                List<IRecord> jsonsList1 = await cursor.ToListAsync();
                IDictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
                foreach(IRecord item in jsonsList1)
                {
                    foreach(string key in item.Keys)
                    {
                        if (!dictionary.ContainsKey(key))
                        {
                            dictionary.Add(key, new List<string>());
                        }
                    }
                    foreach(var node in item.Values)
                    {
                        dictionary[node.Key].Add(JsonSerializer.Serialize(node.Value));
                    }
                }
                return dictionary;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: ", ex);
            }
        }

        public async Task<IDictionary<string, string>> execute3(string query, string[] variables)
        {
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                List<IRecord> jsonsList1 = await cursor.ToListAsync();
                IDictionary<string, List<object>> primitive = new Dictionary<string, List<object>>();
                foreach (IRecord item in jsonsList1)
                {
                    foreach (string key in item.Keys)
                    {
                        if (!primitive.ContainsKey(key))
                        {
                            primitive.Add(key, new List<object>());
                        }
                    }
                    foreach (var node in item.Values)
                    {
                        primitive[node.Key].Add(node.Value);
                    }
                }
                IDictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (var item in primitive)
                {
                    dictionary.Add(item.Key, JsonSerializer.Serialize(item.Value));
                }
                return dictionary;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: ", ex);
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
        #endregion

        ~Executor()
        {
            session.CloseAsync();
            driver.CloseAsync();
        }
    }
}
