using System;

namespace POMExample.Utils
{
    class FilePathUtils
    {

        public static string GetAbsolutePath(string fileName) {
           return AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "bin" }, StringSplitOptions.None)[0] + fileName;
        }
    }
}
