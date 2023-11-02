using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal class Dock
    {
        public string Id { get; private set; }
        public Queue<Truck> Line;
        // Statistics
        public double TotalSales { get; private set; }
        public int TotalCrates { get; private set; }
        public int TotalTrucks { get; private set; }
        public int TimeInUse { get; private set; }
        public int TimeNotInUse { get; private set; }

        public Dock(string DockID)
        {
            Line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
            Id = DockID;
        }



        public void JoinLine(Truck truck)
        {
            Line.Enqueue(truck);
        }
        public Truck SendOff()
        {
            return Line.Dequeue();
        }
    }
}
