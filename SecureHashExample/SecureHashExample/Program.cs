using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureHashExample
{
    /// <summary>
    /// Retirado da questão:
    /// You are developing a method named GetHash that will return a hash value for a file.
    /// You need to return the cryptographic hash of the bytes contained in the fileBytes variable.
    /// </summary>
    class Program
    {
        static void Main( string[] args )
        {
            byte[] byteArray = GetHash( @"..\..\file.txt", "SHA" );

            for ( int i = 0; i < byteArray.Length; i++ )
            {
                Console.Write( byteArray[i] );
            }

            Console.ReadKey();
        }

        public static byte[] GetHash( string fileName, string algorithmType )
        {
            //Valores possíveis para o algorithmType
            ///SHA
            ///SHA1
            ///System.Security.Cryptography.SHA1
            ///System.Security.Cryptography.HashAlgorithm
            ///MD5
            ///System.Security.Cryptography.MD5
            ///SHA256
            ///SHA-256
            ///System.Security.Cryptography.SHA256
            ///SHA384
            ///SHA-384
            ///System.Security.Cryptography.SHA384
            ///SHA512
            ///SHA-512
            ///System.Security.Cryptography.SHA512

            var hasher = HashAlgorithm.Create( algorithmType );
            var fileBytes = System.IO.File.ReadAllBytes( fileName );

            hasher.ComputeHash( fileBytes );
            return hasher.Hash;
        }


    }
}
