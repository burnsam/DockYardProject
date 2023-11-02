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
        
        public Yard(int NumberofDocks)
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
            TimeLeft = 48;
        }


        public void Run()
        {




            while (TimeLeft > 0)
            {







            }
        }
    }
}
