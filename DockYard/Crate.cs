using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal class Crate
    {
        public string ID { get; private set; }
        public double Price { get; private set; }

        public Crate()
        {
            ID = RNGesus.RandomizerID();
            Price = RNGesus.RandomizerPrice();
        }
        public string ToString()
        {
            string build = "Crate ID: " + ID + "\t";
            build += "Price of Crate: $" + Price + "\t";
            return build;
        }
    }
}
