using System;
using System.Security.Cryptography;
using System.Text;

namespace OutsourceSystem.Common.Helpers
{
    public static class Cryptography
    {
        public static string CreateMD5(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static string ToBase64(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            var bytes = Encoding.Default.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
    }
}