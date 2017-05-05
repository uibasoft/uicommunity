using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Comunes.Security
{
    public interface IPasswordCipher
    {
        /// <summary>
        /// Crea un Hash de cifrado para la contraseña.
        /// </summary>
        /// <param name="password">Contraseña a generar su correspondiente hash.</param>
        /// <returns>Retorna la contraseña cifrada.</returns>
        string Encrypt(string password);
        /// <summary>
        /// Descifra la contraseña a partir de la contraseña cifrada.
        /// </summary>
        /// <param name="passwordEncrypt"> Contraseña cifrada.</param>
        /// <returns>Retorna la contraseña descrifada.</returns>
        string Decrypt(string passwordEncrypt);
        /// <summary>
        /// Determina la valides de la contraseña a partir de su codigo Hash.
        /// </summary>
        /// <param name="password">Contraseña sin cifrar.</param>
        /// <param name="passwordHash">Contraseña cifrada.</param>
        /// <returns>Determina la valides de la contraseña. Devuelve verdadero si la contraseña es valida.</returns>
        bool ValidatePassword(string password, string passwordHash);
    }
}
