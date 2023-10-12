using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace jwttoken1
{
    public class KeyGenerator
    {
        public static string GenerateHmacSha256Key()
        {
            using (var hmac = new HMACSHA256())
            {
                byte[] keyBytes = hmac.Key;
                return Convert.ToBase64String(keyBytes);
            }
        }

        public static string GenerateHmacSha512Key()
        {
            using (var hmac = new HMACSHA512())
            {
                byte[] keyBytes = hmac.Key;
                string base64Key = Convert.ToBase64String(keyBytes);
                return base64Key;
            }
        }
    }
}
