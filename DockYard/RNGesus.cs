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
        static public int RandomInt(int integer)
        {
            Random rand = new Random();
            int result = rand.Next(0,integer);
            return result;
        }
        static public Truck RandomizerTruck()
        {
            Random rand = new Random();
            string name;
            string comp;
            int integer1 = rand.Next(1, 6);
            int integer2 = rand.Next(1, 6);
            int integer3 = rand.Next(1, 6);
            if (integer1 == 1) name = "dave";
            else if (integer1 == 2) name = "paul";
            else if (integer1 == 3) name = "karl";
            else if (integer1 == 4) name = "kennith";
            else name = "david \"Skull\" bowl";
            if (integer2 == 1) comp = "dave and teller";
            else if (integer2 == 2) comp = "Skull jumpers";
            else if (integer2 == 3) comp = "pet shart";
            else if (integer2 == 4) comp = "killa\' haulers";
            else comp = "Heavy Duty Spikes";
            Truck truck = new Truck(name, comp, integer3);
            return truck;
        }
    }
}
