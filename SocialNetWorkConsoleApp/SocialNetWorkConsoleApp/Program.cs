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

            LoadData dataLoader = new LoadData();
            bool doesFileExist = dataLoader.getUserToEnterFileDetails();

            if (doesFileExist)
                dataLoader.load(dataLoader.TextFileLocation);
            else
            {
                Console.WriteLine("\n\nFile does not exist. Exiting.");
                return;
            }


        }
    }
}
