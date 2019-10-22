using System;
using System.Collections.Generic;
using System.Text;

namespace Crypto
{
    public static class TCPConnection
    {
        /*

 1 - sending public key RSA
 2 - sending file name
 3 - request for AES key generation
 4 - encrypted text with AES
 5 - encrypted AES with RSA
 6 - end connection
     */

        public const int PUBLIC_KEY = 1;
        public const int FILE_NAME_HEADER = 2;
        public const int GET_SESSION_KEY = 3;
        public const int ENCRYPTED_AES_WITH_RSA = 5;

    }
}
