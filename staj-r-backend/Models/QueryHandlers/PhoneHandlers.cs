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
