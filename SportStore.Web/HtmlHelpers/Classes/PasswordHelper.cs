using System;
using System.Security.Cryptography;
using System.Text;

namespace SportStore.Web.HtmlHelpers.Classes
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa szyfrująca / deszyfrująca hasło
    /// Data:   07.11.15
    /// </summary>
    public class PasswordHelper
    {
        public static string Encrypt(string plainText)
        {
            if (plainText == null)
                throw new ArgumentNullException("plainText");

            var data = Encoding.Unicode.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string cipher)
        {
            if (cipher == null)
                throw new ArgumentNullException("cipher");

            byte[] data = Convert.FromBase64String(cipher);
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.LocalMachine);

            return Encoding.Unicode.GetString(decrypted);
        }
    }
}