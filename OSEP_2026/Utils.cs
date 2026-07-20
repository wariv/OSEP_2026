using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSEP_2026
{
    public static class Utils
    {
        private static readonly Random Random = new Random();

        public static string GenerateRandomString(int length)
        {
            string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(charset[Random.Next(charset.Length)]);
            }

            return sb.ToString();


        }
    }
}
