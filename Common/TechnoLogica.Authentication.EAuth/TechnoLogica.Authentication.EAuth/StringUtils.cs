using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TechnoLogica.Authentication.EAuth
{
    public static class StringUtils
    {

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var result = Convert.ToBase64String(plainTextBytes);
            return result;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            var result = Encoding.UTF8.GetString(base64EncodedBytes);
            return result;
        }

    }
}
