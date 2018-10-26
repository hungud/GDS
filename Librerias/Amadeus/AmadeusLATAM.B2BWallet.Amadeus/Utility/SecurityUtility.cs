// <copyright file="SecurityUtility.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Amadeus.Utility
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Clase que permite trabajar con algunas funcionalidades a nivel de seguridad
    /// </summary>
    public class SecurityUtility
    {
        #region "Public Methods"

        /// <summary>
        /// Permite cifrar contenido de un tipo string a partir de una clave.
        /// </summary>
        /// <param name="plainText">Texto a ser cifrado.</param>
        /// <param name="passPhrase">Clave con la cual es posible cifrar un texto.</param>
        /// <returns>Texto cifrado.</returns>
        public string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(GeneralUtility.ToGuid(GeneralUtility.Reverse(passPhrase)).ToString().Substring(1,16));
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(GeneralUtility.ToGuid(passPhrase).ToString());
            PasswordDeriveBytes password = new PasswordDeriveBytes(System.Convert.ToBase64String(toEncodeAsBytes), null);
            byte[] keyBytes = password.GetBytes(32);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        /// <summary>
        /// Permite descifrar contenido de un tipo string a partir de una clave.
        /// </summary>
        /// <param name="cipherText">Texto a ser descifrado.</param>
        /// <param name="passPhrase">Clave con la cual es posible descifrar el texto cifrado.</param>
        /// <returns>Texto descifrado.</returns>
        public string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(GeneralUtility.ToGuid(GeneralUtility.Reverse(passPhrase)).ToString().Substring(1, 16));
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(GeneralUtility.ToGuid(passPhrase).ToString());
            PasswordDeriveBytes password = new PasswordDeriveBytes(System.Convert.ToBase64String(toEncodeAsBytes), null);
            byte[] keyBytes = password.GetBytes(32);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        #endregion "Public Methods"
    }
}
