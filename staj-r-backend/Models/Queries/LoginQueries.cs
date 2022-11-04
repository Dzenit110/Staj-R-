namespace staj_r_backend.Models.Queries
{
    public class LoginQueries
    {
        public LoginQueries(long number)
        {

        }
        public static string loginQuery = $"MATCH(u:User) WHERE u.number = ";
    }
}
