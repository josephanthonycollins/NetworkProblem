using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetWorkConsoleApp
{
    //Class used to run the simulations i.e. given the parsed data set, generate the relevant Matrix/Graph and run the simulation
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

            //Get the user to enter the starting and destination node
            int startNode = getUserToEnterNode(1);
            int destinationNode = getUserToEnterNode(2);

            if (startNode == destinationNode)
            {
                Console.WriteLine("\n\nTrivial case, i.e. distance from node to itself is 0, exiting.");
                return 0;
            }

            Console.WriteLine("\n\nRunning simulation.");
            
            //Now we generate a n by n Matrix where n is the number of unqiue nodes, all entries are 0
            Matrix matrix = new Matrix(Data.UniqueListOfNodes.Count, Data.UniqueListOfNodes.Count(), 0.0);

            //Populate the matrix, 1 indicates two Nodes are connected
            for (int i = 0; i < Data.IndexI.Count; i++)
            {
                matrix[Data.IndexI[i], Data.IndexJ[i]] = 1.0;
                //matrix will be symmetric
                matrix[Data.IndexJ[i], Data.IndexI[i]] = 1.0;
            }

            Matrix tempMatrix = matrix;

            int iteration = upperbound;

            while (iteration > 0)
            {
                //TODO: change this so that we can enter in any nodes
                if (tempMatrix[startNode, destinationNode] == 1.0)
                {
                    Console.WriteLine("\n\nNode {0} and Node {1} are linked after {2} steps, exiting.",startNode,destinationNode, upperbound - iteration + 1);
                    return upperbound - iteration + 1;
                }
                iteration--;

                tempMatrix = tempMatrix * matrix;
            }

            Console.WriteLine("\n\nNode {0} and Node {1} are not linked after 15 steps. Exiting.", startNode, destinationNode);

            return upperbound;
        }


        public int getUserToEnterNode(int selection)
        {
            string str = "";
            int node = 0;
            Console.Write("\nTo choose node {0}, enter an integer between 0 and {1}:",selection,Data.UniqueListOfNodes.Count-1);
            str = Console.ReadLine();
            bool val = int.TryParse(str, out node);
            while (!val)
            {
                Console.Write("\nInvalid Input. Please enter an integer between 0 and {1}: ",0,Data.UniqueListOfNodes.Count-1);
                str = Console.ReadLine();
                val = int.TryParse(str, out node);
            }
            return node;
        }

    }
}
