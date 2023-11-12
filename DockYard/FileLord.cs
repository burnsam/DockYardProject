using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal static class FileLord
    {
        /// <summary>
        /// A Helper Class used to write information to files
        /// </summary>
        /// <param name="Pencil">any length string</param>
        public static  void WriteCrateLog(string Pencil)
        {
            StreamWriter sw = new("CrateLog.txt");
            sw.WriteLine(Pencil);
            sw.Close();
        }
    }
}
