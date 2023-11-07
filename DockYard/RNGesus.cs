using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal static class RNGesus
    {
        /// <summary>
        /// A Helper class that deals with randomistion
        /// </summary>
        /// <returns></returns>
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
            double price = random.Next(50, 500);
            price += random.NextDouble();
            price = Math.Round(price, 2);
            return price;
        }

    }
}
