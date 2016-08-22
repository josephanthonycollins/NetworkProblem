using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetWorkConsoleApp
{
    class ParseData
    {
        private List<string> uniqueListOfNodes = new List<string>();

        public List<string> UniqueListOfNodes
        {
            get { return uniqueListOfNodes; }
            set { uniqueListOfNodes = value; }
        }

        private List<int> Indexi = new List<int>();

        public List<int> IndexI
        {
            get { return Indexi; }
            set { Indexi = value; }
        }

        private List<int> Indexj = new List<int>();

        public List<int> IndexJ
        {
            get { return Indexj; }
            set { Indexj = value; }
        }

        public bool generateUniqueNamesAndIndices(List<string> originalData)
        {
            int count = 0;

            foreach (var element in originalData)
            {
                if (element == null)
                    continue;

                String[] names = element.Split(',');

                //Is the first and second name already in the list?
                int firstNodePosition = uniqueListOfNodes.IndexOf(names[0]);
                int secondNodePosition = uniqueListOfNodes.IndexOf(names[1]);

                if (firstNodePosition < 0)
                {
                    uniqueListOfNodes.Add(names[0]);
                    count = count + 1;
                }

                IndexI.Add(firstNodePosition < 0 ? count - 1 : firstNodePosition);

                if (secondNodePosition < 0)
                {
                    uniqueListOfNodes.Add(names[1]);
                    count = count + 1;
                }

                IndexJ.Add(secondNodePosition < 0 ? count - 1 : secondNodePosition);
            }

            if(UniqueListOfNodes.Count==0)
                return false;

            return true;
        }
    }
}

