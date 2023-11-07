using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal class Truck
    {
        public string DriverName { private set; get; }
        public string DeliveryCompany { private set; get; }
        public Stack<Crate> Trailer;
        /// <summary>
        /// Trucks contains Crates and are the main object used by primailay Dock and Yard
        /// </summary>
        /// <param name="driverName"></param>
        /// <param name="deliveryCompany"></param>
        /// <param name="NumberOfCrates"></param>
        public Truck(string driverName, string deliveryCompany, int NumberOfCrates)
        {
            DriverName = driverName;
            DeliveryCompany = deliveryCompany;
            Trailer = new Stack<Crate>();
            for (int i = 0; i < NumberOfCrates; i++)
            {
                Trailer.Push(new Crate());
            }
        }

        public bool nextCrateExists()
        {
            return Trailer.Count > 0;
        }

        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }
        public Crate UnLoad()
        {
            return Trailer.Pop();
        }

        public string ToString()
        {
            string s = "Delivered by: " + DriverName + "\t";
            s += "Delivered From: " + DeliveryCompany + "\t";
            return s;
        }
    }
}
