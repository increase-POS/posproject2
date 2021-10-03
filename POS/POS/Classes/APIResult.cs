using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace POS.Classes
{

   public class APIResult
    {
            public string Message { get; set; }
            public string Status { get; set; }

        private static string Secret = "EREMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        public static async Task<IEnumerable<Claim>> getList(string method,Dictionary<string,string> parameters = null )
        {
            #region generate token to send it to api
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                            (securityKey, SecurityAlgorithms.HmacSha256Signature);

            //  Finally create a Token
            var header = new JwtHeader(credentials);
            var nbf = DateTime.UtcNow.AddSeconds(-1);
            var exp = DateTime.UtcNow.AddSeconds(120);
            var payload = new JwtPayload(null, "", new List<Claim>(), nbf, exp);

            if(parameters != null)
            for (int i = 0; i < parameters.Count; i++)
            {
                payload.Add(parameters.Keys.ToList()[i], parameters.Values.ToList()[i]);
            }

            var token = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use post it to api
            string getToken = handler.WriteToken(token);
            #endregion
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var client = new RestClient(Global.APIUri + method + "?token=" + getToken);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
           request.AddHeader("authorization", "Bearer "+getToken);
            request.AddHeader("APIKey", Global.APIKey);
          
            IRestResponse response = await client.ExecuteTaskAsync(request);
            var jsonString = response.Content.ToString();
            var Sresponse = JsonConvert.DeserializeObject<APIResult>(jsonString);

            if (Sresponse.Status == "Success")
            {
                var jwtToken = new JwtSecurityToken(Sresponse.Message);
                var s = jwtToken.Claims.ToArray();
                IEnumerable<Claim> claims = jwtToken.Claims;
                return  claims;
            }
            return null;
        }

        public static int post(string method, Dictionary<string,string> parameters)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                            (securityKey, SecurityAlgorithms.HmacSha256Signature);

            //  Finally create a Token
            var header = new JwtHeader(credentials);
            var nbf = DateTime.UtcNow.AddSeconds(-1);
            var exp = DateTime.UtcNow.AddSeconds(120);
            var payload = new JwtPayload(null, "", new List<Claim>(), nbf, exp);
          
            for (int i = 0; i < parameters.Count; i++)
            {
                payload.Add(parameters.Keys.ToList()[i], parameters.Values.ToList()[i]);    
            }
            //
            var token = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use post it to api
            string postToken = handler.WriteToken(token);

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var client = new RestClient(Global.APIUri + method+"?token="+postToken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer "+ postToken);
            request.AddHeader("APIKey", Global.APIKey);
           // request.AddParameter("Message",postToken);

            IRestResponse response = client.Execute(request);
            var jsonString = response.Content.ToString();
            var Sresponse = JsonConvert.DeserializeObject<APIResult>(jsonString);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jwtToken = new JwtSecurityToken(Sresponse.Message);
                var s = jwtToken.Claims.ToArray();
                IEnumerable<Claim> claims = jwtToken.Claims;
                foreach (Claim c in claims)
                {
                    if (c.Type == "scopes")
                    {
                        return int.Parse(c.Value);
                    }
                }
                return 0;
            }
            return 0;
        }
    }

}
