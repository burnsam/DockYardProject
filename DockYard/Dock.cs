using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Truck? UnloadingTruck { get; set; }
        private int TimeIncrement { get; set; }
        // Statistics
        public double TotalSales { get; private set; }
        public int TotalCrates { get; private set; }
        public int TotalTrucks { get; private set; }
        public int TimeInUse { get; private set; }
        public int TimeNotInUse { get; private set; }
        public int GreatestLength { get; private set; }
        /// <summary>
        /// Main staging area where things get done, tracks information
        /// </summary>
        /// <param name="DockID"></param>
        public Dock(string DockID)
        {
            Line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
            Id = DockID;
            TimeIncrement = 0;
            GreatestLength = 0;
        }

        public int NumberOfTrucks()
        {
            if (UnloadingTruck is not null)
            {
                return Line.Count + 1;
            }
            return Line.Count;
        }
        /// <summary>
        /// Unloads a Crate, UpDates
        /// </summary>
        public void RunOperations()
        {
            // checks if there is a truck being unloaded. if there is no truck in the line then that means the dock is not in use.
            if (UnloadingTruck is null && Line.Count <= 0) { TimeIncrement++; TimeNotInUse++; return; }
            if (UnloadingTruck is null) { UnloadingTruck = Line.Dequeue(); }
            TimeInUse++;
            GreatestLength = Math.Max(GreatestLength, Line.Count);
            Crate Unloadedcrate = UnloadingTruck.UnLoad();
            TotalSales += Unloadedcrate.Price;
            LogCrate(Unloadedcrate);
            TimeIncrement++;
        }

        private void LogCrate(Crate crate)
        {
            
            string newSTR = "Time of Unload: " + TimeIncrement + "\t";
            newSTR += crate.ToString();
            newSTR += crate.ToString();
            if (UnloadingTruck.nextCrateExists()) { newSTR += "\tThere are still more crates in truck!"; }
            else if (DoesNextInLineExists()) { newSTR += "empty, new truck in line!"; TotalTrucks++; UnloadingTruck = SendOff(); }
            else { newSTR += "empty, we require another truck!"; TotalTrucks++; UnloadingTruck = null; }
            FileLord.WriteCrateLog(newSTR);
            TotalCrates++;
        }

        public bool DoesNextInLineExists() 
        {
            if(Line.Count <= 0)
            {
                return false;
            } else {
                return true;
            }
        }

        public void JoinLine(Truck truck)
        {
            if (UnloadingTruck is null)
            {
                UnloadingTruck = truck;
            } else {
                Line.Enqueue(truck);
            }
            
        }
        public Truck SendOff()
        {
            return Line.Dequeue();
        }
    }
}
