using System;
using System.Security.Cryptography;

namespace Domain.Entities
{
    public class Password
    {
        private const int SaltByteSize = 24;
        private const int HashByteSize = 20;
        private const int PBKDF2Iterations = 10000;
        private const int IterationIndex = 0;
        private const int SaltIndex = 1;
        private const int PBKDF2Index = 2;

        public Password(string password)
        {
            Hash = HashPassword(password);
        }

        public virtual string Hash { get; protected set; }

        public virtual bool IsValid(string password)
        {
            char[] delimiter = { ':' };
            var split = Hash.Split(delimiter);
            var iterations = Int32.Parse(split[IterationIndex]);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[PBKDF2Index]);

            var testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static string HashPassword(string password)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            var salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);

            var hash = PBKDF2(password, salt, PBKDF2Iterations, HashByteSize);
            return string.Format("{0}:{1}:{2}", PBKDF2Iterations, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt) { IterationCount = iterations };
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}