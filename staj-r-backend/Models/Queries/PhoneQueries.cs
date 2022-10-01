namespace staj_r_backend.Models.Queries
{
    public class PhoneQueries
    {
        public static string getPhonesQueryString { get; } = "MATCH (p:PHONE) RETURN apoc.convert.toJson(properties(p)) AS n";
        public static string getPhonesVariable { get; } = "n";
    }
}
