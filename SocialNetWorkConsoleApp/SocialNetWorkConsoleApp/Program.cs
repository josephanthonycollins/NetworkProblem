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

            if (doesFileExist)
                dataLoader.load(dataLoader.TextFileLocation);
            else
            {
                Console.WriteLine("\n\nFile does not exist. Exiting.");
                return;
            }

            //Parsing the Original Data to get unique list of names and indices
            ParseData datafilter = new ParseData();
            bool canWeFilter = datafilter.generateUniqueNamesAndIndices(dataLoader.OriginalData);

            if (!canWeFilter)
            {
                Console.WriteLine("\n\nCan't generate List of names. Exiting.");
                return;   
            }

            //Create the SimulationWrapper object and run the simulation
            SimulationWrapper sim = new SimulationWrapper(datafilter);
            int ans = sim.RunSimulation();

            //End of programme
            Console.ReadLine();
        
        }
    }



}
