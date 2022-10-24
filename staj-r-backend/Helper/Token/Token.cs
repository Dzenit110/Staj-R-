using System;
using System.Collections.Generic;
using Jose;
using Newtonsoft.Json;
using staj_r_backend.Models.Entities;

namespace staj_r_backend.Helper.Token
{
    public class Token
    {

        private readonly byte[] secretKey = new byte[] { 3, 234, 131, 182, 25, 29, 145, 80, 73, 196, 31, 218, 82, 59, 105, 110, 3, 2, 90, 147, 100, 103, 156, 208, 86, 236, 187, 141, 94, 98, 59, 190};
        public string encrypt(TokenEntity user)
        {
            var payload = new Dictionary<string, object>
            {
                { "number", user.number },
                { "password", user.password },
                { "expiresOn", DateTime.Now.AddHours(2)}
            };
            return JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
        }
        public string encrypt(Dictionary<string, object> payload)
        {
            if (payload.ContainsKey("expiresOn"))
            {
                payload.Remove("expiresOn");
            }
            payload.Add("expiresOn", DateTime.Now.AddHours(2));
            return JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
        }

        public TokenEntity decrypt(string token)
        {
            var payload = JWT.Decode(token, secretKey, JwsAlgorithm.HS256);
            return JsonConvert.DeserializeObject<TokenEntity>(payload);
        }
    }
}
