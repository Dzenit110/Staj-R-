using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Jose;
using Newtonsoft.Json;
using System.Text.Json;
using staj_r_backend.Models.Entities;

namespace staj_r_backend.Helper.Token
{
    public class Token
    {

        private readonly byte[] secretKey = new byte[] { 3, 234, 131, 182, 25, 29, 145, 80, 73, 196, 31, 218, 82, 59, 105, 110, 3, 2, 90, 147, 100, 103, 156, 208, 86, 236, 187, 141, 94, 98, 59, 190};
        public TokenResult encrypt(TokenEntity user)
        {
            DateTime expire = DateTime.Now.AddHours(2);
            var payload = new Dictionary<string, object>
            {
                { "number", user.number },
                { "password", user.password },
                { "expiresOn", expire}
            };
            string token = JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
            user.expiresOn = expire;
            return new TokenResult
            {
                token = token,
                tokenEntity = user,
                tokenExpiresOn = expire,
            };
        }
        public string encryptUserWToken(UserWToken uwt)
        {
            //var payload = uwt.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary(prop => prop.Name, prop => (string)prop.GetValue(uwt, null));
            return JWT.Encode(System.Text.Json.JsonSerializer.Serialize(uwt), secretKey, JwsAlgorithm.HS256);
        }
        public UserWToken decryptUserWToken(string token)
        {
            var payload = JWT.Decode(token, secretKey, JwsAlgorithm.HS256);
            return System.Text.Json.JsonSerializer.Deserialize<UserWToken>(payload);
        }
        public TokenResult encrypt(Dictionary<string, object> payload)
        {
            DateTime expire = DateTime.Now.AddHours(2);
            if (payload.ContainsKey("expiresOn"))
            {
                payload.Remove("expiresOn");
            }
            payload.Add("expiresOn", expire);
            string token = JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
            return new TokenResult
            {
                tokenEntity = new TokenEntity
                {
                    number = (string)payload["number"],
                    password = (string)payload["password"],
                    expiresOn = expire,
                },
                token = token,
                tokenExpiresOn = expire,
            };
        }

        public TokenEntity decrypt(string token)
        {
            var payload = JWT.Decode(token, secretKey, JwsAlgorithm.HS256);
            return JsonConvert.DeserializeObject<TokenEntity>(payload);
        }
    }
    public record TokenResult
    {
        public TokenEntity tokenEntity { get; set; }
        public string token { get; set; }
        public DateTime tokenExpiresOn { get; set; }
    }
}
