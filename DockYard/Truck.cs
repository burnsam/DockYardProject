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
        private Stack<Crate> Trailer;
        private int TimeIncrement;

        public Truck(string driverName, string deliveryCompany, int NumberOfCrates)
        {
            DriverName = driverName;
            DeliveryCompany = deliveryCompany;
            Trailer = new Stack<Crate>();
            for (int i = 0; i < NumberOfCrates; i++)
            {
                Trailer.Push(new Crate());
            }
            TimeIncrement = 0;
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
            Crate crate = Trailer.Pop();


            return crate;
        }



        public string ToString()
        {
            string s = "Delivered by: " + DriverName + "\t";
            s += "Delivered From: " + DeliveryCompany + "\t";
            return s;
        }
    }
}
