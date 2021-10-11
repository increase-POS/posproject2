using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace POS.Classes
{

   public class APIResult
    {
            //public string Message { get; set; }
            //public string Status { get; set; }

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
            var encryptedToken = EncryptThenCompress(getToken);
      
             var myData = new
            {
                token = encryptedToken,
            };
            encryptedToken = HttpUtility.UrlPathEncode(encryptedToken);

            var client = new RestClient(Global.APIUri + method + "?token=" + encryptedToken);
            client.Encoding = Encoding.Unicode;
       
            #endregion
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
 
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json, charset=UTF-8,Encoding.UNICOD, charset=utf8_unicode_ci");
            request.AddHeader("Content-Encoding", "gzip, charset=utf-8, Encoding.ASSCI,charset=utf8_unicode_ci ");
            request.AddHeader("Accept-Encoding", "gzip, deflate");

            IRestResponse response = await client.ExecuteTaskAsync(request);
            var jsonString = response.Content.ToString();
            var Sresponse = JsonConvert.DeserializeObject<string>(jsonString);
            if(Sresponse != "")
            {
                var decryptedToken = DeCompressThenDecrypt(Sresponse);
                var jwtToken = new JwtSecurityToken(decryptedToken);
                var s = jwtToken.Claims.ToArray();
                IEnumerable<Claim> claims = jwtToken.Claims;
                string validAuth = claims.Where(f => f.Type == "scopes").Select(x => x.Value).FirstOrDefault();
                if (validAuth != null && s[2].Value == "-7") // invalid authintication
                    return null;                   
                return claims;
            }
            //if (Sresponse.Status == "Success")
            //{
            //    var decryptedToken = DeCompressThenDecrypt(Sresponse.Message);
            //    var jwtToken = new JwtSecurityToken(decryptedToken);
            //    var s = jwtToken.Claims.ToArray();
            //    IEnumerable<Claim> claims = jwtToken.Claims;
            //    return  claims;
            //}
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
            var encryptedToken = EncryptThenCompress(postToken);

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var client = new RestClient(Global.APIUri + method+"?token="+encryptedToken);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer "+ postToken);
            request.AddHeader("APIKey", Global.APIKey);
           // request.AddParameter("Message",postToken);

            IRestResponse response = client.Execute(request);
            var jsonString = response.Content.ToString();
            var Sresponse = JsonConvert.DeserializeObject<string>(jsonString);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var decryptedToken = DeCompressThenDecrypt(Sresponse);
                var jwtToken = new JwtSecurityToken(decryptedToken);
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
        #region encryption & decryption
        public static string Encrypt(string Text)
        {
            byte[] b = ConvertToBytes(Text);
            b = Encrypt(b);
            return ConvertToText(b);
        }
        private static byte[] ConvertToBytes(string text)
        {
            return System.Text.Encoding.Unicode.GetBytes(text);
        }
        public static byte[] Encrypt(byte[] ordinary)
        {
            BitArray bits = ToBits(ordinary);
            BitArray LHH = SubBits(bits, 0, bits.Length / 2);
            BitArray RHH = SubBits(bits, bits.Length / 2, bits.Length / 2);
            BitArray XorH = LHH.Xor(RHH);
            RHH = RHH.Not();
            XorH = XorH.Not();
            BitArray encr = ConcateBits(XorH, RHH);
            byte[] b = new byte[encr.Length / 8];
            encr.CopyTo(b, 0);
            return b;
        }
        public static string Decrypt(string EncryptedText)
        {
            byte[] b = ConvertToBytes(EncryptedText);
            b = Decrypt(b);
            return ConvertToText(b);
        }
        public static byte[] Decrypt(byte[] Encrypted)
        {
            BitArray enc = ToBits(Encrypted);
            BitArray XorH = SubBits(enc, 0, enc.Length / 2);
            XorH = XorH.Not();
            BitArray RHH = SubBits(enc, enc.Length / 2, enc.Length / 2);
            RHH = RHH.Not();
            BitArray LHH = XorH.Xor(RHH);
            BitArray bits = ConcateBits(LHH, RHH);
            byte[] decr = new byte[bits.Length / 8];
            bits.CopyTo(decr, 0);
            return decr;
        }
        private static string ConvertToText(byte[] ByteAarry)
        {
            return System.Text.Encoding.Unicode.GetString(ByteAarry);
        }
        private static BitArray ToBits(byte[] Bytes)
        {
            BitArray bits = new BitArray(Bytes);
            return bits;
        }
        private static BitArray SubBits(BitArray Bits, int Start, int Length)
        {
            BitArray half = new BitArray(Length);
            for (int i = 0; i < half.Length; i++)
                half[i] = Bits[i + Start];
            return half;
        }
        private static BitArray ConcateBits(BitArray LHH, BitArray RHH)
        {
            BitArray bits = new BitArray(LHH.Length + RHH.Length);
            for (int i = 0; i < LHH.Length; i++)
                bits[i] = LHH[i];
            for (int i = 0; i < RHH.Length; i++)
                bits[i + LHH.Length] = RHH[i];
            return bits;
        }
        #endregion

        #region Compress & Decompress
        public static byte[] Compress(byte[] bytData)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                Stream s = new GZipStream(ms, CompressionMode.Compress);
                s.Write(bytData, 0, bytData.Length);
                s.Close();
                byte[] compressedData = (byte[])ms.ToArray();
                return compressedData;

            }
            catch
            {
                return null;
            }
        }       
        public static byte[] DeCompress(byte[] bytInput)
        {
            //string strResult = "";
            //int totalLength = 0;
            //byte[] writeData = new byte[100000];

            //Stream s2 = new GZipStream(new MemoryStream(bytInput), CompressionMode.Decompress,true);

            ////try
            ////{
            //    while (true)
            //{
            //    int size = s2.Read(writeData, 0, writeData.Length);
            //    if (size > 0)
            //    {
            //        totalLength += size;
            //        strResult += System.Text.Encoding.Unicode.GetString(writeData, 0, size);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //s2.Close();
            //return Encoding.Unicode.GetBytes(strResult);
            Stream ms = new MemoryStream(bytInput);
            Stream decodedStream = new MemoryStream();
            byte[] buffer = new byte[4096];

            using (Stream inGzipStream = new GZipStream(ms, CompressionMode.Decompress,true))
            {
                int bytesRead;
                while ((bytesRead = inGzipStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    decodedStream.Write(buffer, 0, bytesRead);
                }
                using (var memoryStream = new MemoryStream())
                {
                    decodedStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            
            //}
            //    catch
            //    {
            //        return null;
            //    }
        }

        #endregion
        #region reverse string
        static string ReverseString(string str)
        {
            int Length;
            string reversestring = "";
            Length = str.Length - 1;
            while (Length >= 0)
            {
                reversestring = reversestring + str[Length];
                Length--;
            }
            return reversestring;
        }
        #endregion
        public static string EncryptThenCompress(string text)
        {
            string str1 = Encrypt(text);
            //var bytes = Encoding.Unicode.GetBytes(text);

            //string str2 = Compress(text);
            //string str2 = Encoding.Unicode.GetString(bytes1);
            //return str2;
          var str2 = ReverseString(str1);
            var bytes = Encoding.UTF8.GetBytes(str2);
            return (Encoding.UTF8.GetString(bytes));
        }

        public static string DeCompressThenDecrypt(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            text = Encoding.UTF8.GetString(bytes);
            string reversedStr = ReverseString(text);
            //var bytes = Encoding.Unicode.GetBytes(reversedStr);
            //var bytes1 = DeCompress(bytes);
            //string str = Encoding.Unicode.GetString(bytes1);
            return( Decrypt(reversedStr));
        }
    }

}
