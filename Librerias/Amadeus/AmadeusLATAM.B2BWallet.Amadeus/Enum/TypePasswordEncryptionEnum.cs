using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusLATAM.B2BWallet.Amadeus.Enum
{
    /// <summary>
    /// Enumeración que permite determinar la formula de encriptacion para obtener el Password Digest en Header 4
    /// PasswordBase64 = Base64( SHA1( Base64.Decode($NONCE) + $TIMESTAMP + SHA1( Base64.Decode($PASSWORD) ) ) )
    /// PasswordClear = Base64( SHA1( Base64.Decode($NONCE) + $TIMESTAMP + SHA1( $PASSWORD) ) )
    /// </summary>
    public enum TypePasswordEncryptionEnum
    {
        PasswordBase64 = 0, 
        PasswordClear = 1 
    }
}
