using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Security
{

    public class PwsCipher : IPasswordCipher
    {
        private readonly int _saltBytes = 24;
        private readonly int _hashBytes = 24;
        private readonly int _pbkdf2Iterations = 1717;
        private const int SaltIndex = 0;
        private const int Pbkdf2Index = 1;
        private const int IterationIndex = 2;
        private readonly string _seperator = "#b4ngu1#";
        public PwsCipher()
        {

        }
        /// <summary>
        /// Crea un hash con PBKDF2 de la contraseña.
        /// </summary>
        /// <param name="password">Contraseña para aplicar el cifrado.</param>
        /// <returns>Contraseña cifrada.</returns>
        public string Encrypt(string password)
        {
            // Generar Salt Aleatorio
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[_saltBytes];
            csprng.GetBytes(salt);

            // Cifra la contraseña
            var hash = Pbkdf2(password, salt, _pbkdf2Iterations, _hashBytes);
            var result = string.Concat(Convert.ToBase64String(salt), _seperator, Convert.ToBase64String(hash), _seperator, _pbkdf2Iterations);
            return result;
        }
        public string Decrypt(string passwordEncrypt)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Valida la contraseña a partir de la contraseña cifrada correctamente.
        /// </summary>
        /// <param name="password">Contraseña a verificar.</param>
        /// <param name="passwordHash">Contraseña cifrada correctamente.</param>
        /// <returns>Verdadero si la contraseña es la correcta, falso de lo contrario.</returns>
        public bool ValidatePassword(string password, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordHash)) return false;
            var split = passwordHash.Split(new[] { _seperator }, StringSplitOptions.None);
            if (split.Count() < 2) return false;
            var iterations = int.Parse(split[IterationIndex]);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[Pbkdf2Index]);
            var testHash = Pbkdf2(password, salt, iterations, hash.Length);
            var result = SlowEquals(hash, testHash);
            return result;
        }

        #region Private

        private static bool SlowEquals(IReadOnlyList<byte> a, IReadOnlyList<byte> b)
        {
            var diff = (uint)a.Count ^ (uint)b.Count;
            for (var i = 0; i < a.Count && i < b.Count; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt) { IterationCount = iterations };
            return pbkdf2.GetBytes(outputBytes);
        }

        #endregion

    }
}
