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
            //iteration upper bound
            const int upperbound = 15;
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

            //Now we generate a n by n Matrix where n is the number of unqiue nodes, all entries are 0
            Matrix matrix = new Matrix(datafilter.UniqueListOfNodes.Count, datafilter.UniqueListOfNodes.Count(), 0.0);
            
            //Populate the matrix, 1 indicates two Nodes are connected
            for (int i = 0; i < datafilter.IndexI.Count; i++)
            {
                matrix[datafilter.IndexI[i], datafilter.IndexJ[i]] = 1.0;
                //matrix will be symmetric
                matrix[datafilter.IndexJ[i],datafilter.IndexI[i]] = 1.0;
            }

            //Test check if element 1 and element 400 are connected
            int iteration = upperbound;

            while (iteration > 0)
            {
                //TODO: change this so that we can enter in any 
                if (matrix[1 - 1, 400 - 1] == 1.0)
                {
                    Console.WriteLine("\n\nElement 1 and Element 400 linked after {0} iterations, exiting.",upperbound-iteration);
                }
                iteration--;

                matrix = matrix * matrix;
            }

            if (iteration == 0)
            {
                Console.WriteLine("\n\nElement 1 and Element 400 are not linked after 15 iterations.Exiting");
                return;
            }

        }
    }

    //Class used to wrap the matrix calculations i.e. simplify the Main() body

    public class MatrixWrapper
    {
        private Matrix _matrix = null;

        internal Matrix _Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
        private ParseData _data = null;

        internal ParseData Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

}
