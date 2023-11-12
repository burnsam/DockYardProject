using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockYard
{
    internal class Yard
    {
        public List<Dock> Docks;
        public Queue<Truck> Entrance;
        public int TimeLeft { get; private set; }
        private int NumberofDocks;
        /// <summary>
        /// Main Control Hub loads and sets up simulation as well as runs the simulation
        /// </summary>
        /// <param name="NumberofDocks"></param>
        public Yard(int NumberofDocks)
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
            TimeLeft = 48;
            if (NumberofDocks > 15 || NumberofDocks < 1)
            {
                throw new IndexOutOfRangeException("Cannot support this amount Docks! choose between 1 and 15");
            }
            this.NumberofDocks = NumberofDocks;
        }


        public void Run()
        {
            int min = 9999;
            for (int i = 0; i < NumberofDocks; i++)
            {
                Dock dok = new Dock((i+1).ToString());
                Docks.Add(dok);
            }


            // Every time increment Adds trucks to the entrance
            // Each Truck then goes to the dock with the smallest line repeat for every truck in entrance
            // Docks then updates their statistics
            // each Truck in each dock then logs a crate leaving immediatly when empty (they use a different path out)
            while (TimeLeft > 0)
            {
                for (int i = 0; i < RNGesus.RandomInt(5); i++)
                {
                    Entrance.Enqueue(RNGesus.RandomizerTruck());
                }
                foreach (Dock dock in Docks)
                {
                    if (Entrance.Count <= 0) { break; }
                    if (dock.NumberOfTrucks() == 0) { dock.JoinLine(Entrance.Dequeue());}
                    min = Math.Min(min, dock.NumberOfTrucks());
                }
                while (Entrance.Count > 0)
                {
                    foreach (Dock dock in Docks)
                    {
                        if (Entrance.Count == 0) break;
                        if (dock.NumberOfTrucks() == min)
                        {
                            dock.JoinLine(Entrance.Dequeue());
                        }
                        min = Math.Min(min, dock.NumberOfTrucks());
                    }
                    min = 9999;
                }

                foreach (Dock dock in Docks) dock.RunOperations();

                TimeLeft--;

            }
            Console.WriteLine(DockYardReport());
            
        }
        /// <summary>
        /// Writes the Report of the simulation
        /// </summary>
        /// <returns></returns>
        public string DockYardReport()
        {
            string report = "Number of Docks: " + Docks.Count + "\n";
            double GrandTotalSales = 0.0;
            int GrandTotalCrates = 0;
            int GrandTotalTrucks = 0;
            int GrandTimeInUse = 0;
            int GrandTimeNotInUse = 0;
            int LongestLine = 0;
            int GrandCost;
            foreach (Dock dock in Docks)
            {
                LongestLine = Math.Max(LongestLine,dock.GreatestLength);
                GrandTotalCrates += dock.TotalCrates;
                GrandTotalTrucks += dock.TotalTrucks;
                GrandTimeInUse += dock.TimeInUse;
                GrandTotalSales += dock.TotalSales;
                GrandTimeNotInUse += dock.TimeNotInUse;
            }
            GrandCost = 100 * GrandTimeInUse;
            GrandTimeInUse = GrandTimeInUse / Docks.Count;
            report += "Longest Line was: " + LongestLine + "\n";
            report += "Total Number of trucks Processed: " + GrandTotalTrucks + "\n";
            report += "Total Number of Crates Processed: " + GrandTotalCrates + "\n";
            report += "Total Value of Crates Processed: $" + GrandTotalSales + "\n";
            report += "Average Value of Crates Processed: $" + GrandTotalSales / GrandTotalCrates + "\n";
            report += "Average Value of Trucks Processed: $" + GrandTotalSales / GrandTotalTrucks + "\n";
            report += "Total amount of time Docks were in use: " + GrandTimeInUse + "\n";
            report += "Total amount of time Docks were not in use: " + GrandTimeNotInUse + "\n";
            report += "Average Amount of time Docks were in use: " + GrandTimeInUse / Docks.Count + "\n";
            report += "Total Cost of operation: $" + GrandCost + "\n";
            report += "Total Revenue of operation: $" + (GrandTotalSales - GrandCost) + "\n";

            return report;
        }
    }
}
