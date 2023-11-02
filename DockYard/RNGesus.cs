using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal static class RNGesus
    {
        static public string RandomizerID()
        {
            Random random = new Random();
            string ID = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                int temp = random.Next(0, 10);
                ID += temp.ToString();
            }
            return ID;
        }
        static public double RandomizerPrice()
        {
            Random random = new Random();
            double price = random.Next(1, 10);
            price += random.NextDouble();
            return price * 50;
            
        }
    }
}
