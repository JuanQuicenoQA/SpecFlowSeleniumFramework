using System;
using System.IO;

namespace SeleniumWebdriver.ComponentHelper
{
    class FileHelper
    {
        public static String SaveScreenShot(String absolutePath, String fileName)
        {
            var dir = Directory.Exists(absolutePath);
            if (!dir)
            {
                Directory.CreateDirectory(absolutePath);
            }

            return absolutePath;

        }
    }
}
