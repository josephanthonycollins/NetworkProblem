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

            //Parsing the Original Data to Unique List of Nodes
            ParseData datafilter = new ParseData();
            bool canwefilter = datafilter.generateUniqueNamesAndIndices(dataLoader.OriginalData);

        }
    }
}
