using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIdeGraaf.Helpers
{
    public interface IEncryptor
    {
        string Hash(string input);
    }
    public static class Encryptor
    {
        public static string Hash(string input, string salt)
        {
            using (var algorith = SHA256.Create())
            {
                var hash = algorith.ComputeHash(Encoding.ASCII.GetBytes(input + salt));
                var output = "";
                foreach (var piece in hash)
                {
                    output += piece.ToString("x2");
                }

                return output;
            }
        }
    }
}
