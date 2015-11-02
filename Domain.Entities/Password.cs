using System;
using System.Security.Cryptography;

namespace Domain.Entities
{
    public class Password
    {
        private const int SaltByteSize = 32;
        private const int HashByteSize = 64;
        private const int PBKDF2Iterations = 10000;
        private const int IterationIndex = 0;
        private const int SaltIndex = 1;
        private const int PBKDF2Index = 2;

        private const int GeneratedPasswordLenght = 8;

        protected Password()
        {
        }

        public Password(string password)
            : this()
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
            var salt = new byte[SaltByteSize];
            new RNGCryptoServiceProvider().GetBytes(salt);

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

        public virtual string GenerateNewPassword()
        {
            const string charactersArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var bytes = new byte[GeneratedPasswordLenght * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);

            var result = new char[GeneratedPasswordLenght];
            for (var i = 0; i < GeneratedPasswordLenght; i++)
            {
                var value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = charactersArray[(int)(value % (uint)charactersArray.Length)];
            }

            var newPassword = new string(result);

            Hash = HashPassword(newPassword);

            return newPassword;
        }
    }
}