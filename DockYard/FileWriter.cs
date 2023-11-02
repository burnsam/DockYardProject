using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal static class FileLord
    {
        static public void WriteCrateLog(string Pencil)
        {

            File.Create("CrateLog.CSV");
            StreamWriter sw = new("CrateLog.CSV");
            sw.WriteLine(Pencil);
            sw.Close();
        }
    }
}
