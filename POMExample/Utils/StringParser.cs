using POMExample.PageObjects;
using System;

namespace POMExample.Utils
{
    class StringParser
    {
        public static String GetSecureCode(String code)
        {
            String secureCode = code.Remove(6, 6).Insert(6, "******");
            Page.GetLog().Info("Secured code: " + secureCode + ", was formed");
            return secureCode;
        }
    }
}
