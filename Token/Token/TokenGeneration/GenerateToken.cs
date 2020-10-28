using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Token.Models;

namespace Token.TokenGeneration
{
    public class GenerateToken
    {

        private static string Secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";

        //create a token
        public static string tokenGenerate(User user)
        {
            //set claims
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            claims.Add(new Claim(ClaimTypes.Name, user.Name + " " + user.Fmaily));
            claims.Add(new Claim(ClaimTypes.MobilePhone, user.Phone));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            
            
            var key = Encoding.ASCII.GetBytes
               ("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
            //Generate Token for user 
            var JWToken = new JwtSecurityToken(
                issuer: "http://localhost:44388/",
                audience: "http://localhost:44388/",
                claims: claims,
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                //Using HS256 Algorithm to encrypt Token  
                signingCredentials: new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return token;

            


        }

        //retrieve user information by token
        public static List<object> TokenToInfo(string Token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var info = handler.ReadJwtToken(Token);
                List<object> result = new List<object>();
                foreach (var v in info.Payload)
                {
                    result.Add(v.Value);
                }
                return result;
            }
            catch (Exception E)
            {
                throw E;
            }

            
        }

        //User Claims
        //private static IEnumerable GetUserClaims(User user)
        //{
        //    IEnumerable claims = new Claim[]
        //            {
        //            new Claim("FullName",user.Name+" "+user.Fmaily),
        //            new Claim("Phone",user.Phone),
        //            new Claim("Email",user.Email),
        //            new Claim("UserName",user.UserName),
        //            };
        //    return claims;
        //}
    }
}