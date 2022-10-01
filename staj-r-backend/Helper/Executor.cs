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

        ~Executor()
        {
            session.CloseAsync();
            driver.CloseAsync();
        }
    }
}
