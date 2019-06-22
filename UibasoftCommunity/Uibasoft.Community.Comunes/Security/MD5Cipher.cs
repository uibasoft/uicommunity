using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Security
{

    public class MD5Cipher : IPasswordCipher
    {
        public MD5Cipher()
        {

        }
        public string Decrypt(string passwordEncrypt)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Crea un hash MD5 de la contraseña.
        /// </summary>
        /// <param name="password">Contraseña para aplicar el cifrado.</param>
        /// <returns>Contraseña cifrada.</returns>
        public string Encrypt(string password)
        {
            return HashMD5(password);
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
            var md5Hash = HashMD5(password);
            var result = (md5Hash.ToLower() == passwordHash.ToLower());
            return result;
        }

        private string HashMD5(string input)
        {
            var hash = new StringBuilder();
            var md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }

}
