namespace DockYard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Yard DockYard = new Yard(1);

            DockYard.Run();
            //Yard yard = new Yard(3);
            //Yard yerd = new Yard(10);
            //Yard GigaYard = new Yard(15);
            //yard.Run();
            //yerd.Run();
            //GigaYard.Run();






            /*
            *   Testing of File Helper class -- FTF, simple fix
            * FileLord.WriteCrateLog("Testing 1. 2. 3. 2. 1. Deja vu, test");
            *   Testing of Crate and RNG randomisers -- FTF, forgot to Round then removed some unneeded code
            * Crate crate = new Crate();
            * Console.WriteLine(crate.ToString());
            *   Testing of Truck and its crates -- First Time Success
            * Truck truck = new Truck("dod", "DUMD", 5);
            * Console.WriteLine(truck.ToString());
            * foreach (Crate crate in truck.Trailer)
            * {
            *     Console.WriteLine(crate.ToString());
            * }
            *
            *  Testing Run Operations and random trucks -- First Time Success
            *  Dock dock = new Dock("180 test testing test");
            *  dock.JoinLine(RNGesus.RandomizerTruck());
            *  dock.JoinLine(RNGesus.RandomizerTruck());
            *  dock.JoinLine(RNGesus.RandomizerTruck());
            *  dock.RunOperations();
            *  
            *  Yard DockYard = new Yard(20); Crashed Successful
            *  Yard DockYard = new Yard(0); Crashed Successful
            */

        }
    }
}