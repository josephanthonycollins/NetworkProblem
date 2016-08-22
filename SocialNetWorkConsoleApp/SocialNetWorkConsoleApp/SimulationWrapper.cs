using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetWorkConsoleApp
{
    //Class used to run the simulations i.e. given the parsed data set, generate the relevant Matrix/graph and run the simulation
    public class SimulationWrapper
    {
        private ParseData data;

        public ParseData Data
        {
            get { return data; }
            set { data = value; }
        }

        public SimulationWrapper(ParseData dataObject)
        {
            this.Data = dataObject;
        }

        //iteration upper bound
        const int upperbound = 15;

        public int RunSimulation()
        {
            if (Data.UniqueListOfNodes.Count == null || Data.UniqueListOfNodes.Count < 2)
            {
                Console.WriteLine("\n\nTrivial or non-existent matrix, exiting.");
                return 0;
            }

            //Now we generate a n by n Matrix where n is the number of unqiue nodes, all entries are 0
            Matrix matrix = new Matrix(Data.UniqueListOfNodes.Count, Data.UniqueListOfNodes.Count(), 0.0);

            //Populate the matrix, 1 indicates two Nodes are connected
            for (int i = 0; i < Data.IndexI.Count; i++)
            {
                matrix[Data.IndexI[i], Data.IndexJ[i]] = 1.0;
                //matrix will be symmetric
                matrix[Data.IndexJ[i], Data.IndexI[i]] = 1.0;
            }

            int iteration = upperbound;

            while (iteration > 0)
            {
                //TODO: change this so that we can enter in any nodes
                if (matrix[1 - 1, 400 - 1] == 1.0)
                {
                    Console.WriteLine("\n\nElement 1 and Element 400 linked after {0} iterations, exiting.", upperbound - iteration);
                    return upperbound - iteration;
                }
                iteration--;

                matrix = matrix * matrix;
            }

            Console.WriteLine("\n\nElement 1 and Element 400 are not linked after 15 iterations.Exiting");

            return upperbound;
        }

    }
}
