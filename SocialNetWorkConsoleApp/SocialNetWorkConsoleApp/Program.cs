using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetWorkConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loading the Data
            LoadData dataLoader = new LoadData();
            bool doesFileExist = dataLoader.getUserToEnterFileDetails();
            bool canWeLoadData = dataLoader.load(dataLoader.TextFileLocation);
            if (!canWeLoadData || !doesFileExist)
            {
                Console.WriteLine("\n\nFile does not exist, or it can't be accessed. Exiting.");
                Console.ReadLine();
                return;
            }

            //Parsing the Original Data to get a) unique list of vertices b) edges
            ParseData datafilter = new ParseData();
            Console.WriteLine("\n\nParsing data.");
            bool canWeFilter = datafilter.generateUniqueNamesAndIndices(dataLoader.OriginalData);
            if (!canWeFilter)
            {
                Console.WriteLine("\n\nCan't generate List of names. Exiting.");
                Console.ReadLine();
                return;   
            }
            Console.WriteLine("\nThere are {0} unique vertices.", datafilter.UniqueListOfNodes.Count);

            //Create the SimulationWrapper object and run the simulation
            SimulationWrapper sim = new SimulationWrapper(datafilter);
            int ans = sim.RunSimulation();

            //End of programme
            Console.ReadLine();
        
        }
    }



}
