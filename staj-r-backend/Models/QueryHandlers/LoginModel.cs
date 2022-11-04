namespace staj_r_backend.Models.QueryHandlers
{
    //public class LoginModel
    //{
    //    /*
    //    public async Task<User> login(long number, string password)
    //    {
    //        try
    //        {
    //            password = new Md().toMd5(password);
    //            Executor executor = new Executor();
    //            string query = $"MATCH (u:User) WHERE u.number = {number} AND u.password = {password}" +
    //                $"RETURN u, COUNT(u) AS c";
    //            IResultCursor cursor = await executor.execute(query);
    //            IRecord record = await cursor.SingleAsync();
    //            if(record["c"].As<int>() == 0)
    //            {
    //                throw new Exception("User cannot find");
    //            }
    //            List<string> res = await cursor.ToListAsync(record => record["u"].As<string>());
    //            return JsonSerializer.Deserialize<User>(res[0]);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Hata: ", ex);
    //        }
    //    }
    //    */
    //}
}
