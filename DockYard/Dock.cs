using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal class Dock
    {
        public string Id { get; private set; }
        public Queue<Truck> Line;
        private Truck UnloadingTruck { get; set; }
        private int TimeIncrement { get; set; }
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
            TimeIncrement = 0;
        }

        private void LogCrate(Crate crate)
        {
            Crate Unloadedcrate = UnloadingTruck.UnLoad();
            string newSTR = TimeIncrement + "\t";
            newSTR += Unloadedcrate.ToString();
            newSTR += UnloadingTruck.ToString();
            if (UnloadingTruck.nextCrateExists()) { newSTR += "more crates in truck!"; }
            else if (DoesNextInLineExists()) { newSTR += "empty, new truck in line!"; }
            else { newSTR += "empty, we require another truck!"; }
            FileLord.WriteCrateLog(newSTR);
        }

        public bool DoesNextInLineExists() 
        {
            if(Line.Peek() == null)
            {
                return false;
            } else {
                return true;
            }
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
