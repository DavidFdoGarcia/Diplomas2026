using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GenerarDiplomas.Clases
{
    internal class ini
    {
        internal class Ini
        {
            string path;

            [DllImport("kernel32")]
            private static extern long GetPrivateProfileString(
                string section,
                string key,
                string def,
                StringBuilder retVal,
                int size,
                string filePath);

            public Ini(string iniPath)
            {
                path = iniPath;
            }

            public string Leer(string section, string key)
            {
                StringBuilder temp = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", temp, 255, path);
                return temp.ToString();
            }
        }
    }
}
