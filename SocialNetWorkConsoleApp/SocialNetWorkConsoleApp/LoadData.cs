using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SocialNetWorkConsoleApp
{
    public class LoadData
    {
        private List<String> originalData = new List<string>();

        public List<String> OriginalData
        {
            get { return originalData; }
            set { originalData = value; }
        }

        private string textFileLocation;

        public string TextFileLocation
        {
            get { return textFileLocation; }
            set { textFileLocation = value; }
        }

        public void load(string file)
        {   
            //Insert Try and Catch Block
            StreamReader sr = new StreamReader(file);

            string tmp = "";            
            do
            {
                tmp = sr.ReadLine();
                OriginalData.Add(tmp);
            }
            while (tmp != null);
            
            sr.Close();
        }

        public bool getUserToEnterFileDetails()
        {
            Console.WriteLine("Enter file (i.e. C:\\SocialNetwork.txt): ");
            //string fname = Console.ReadLine();
            string fname = "D:\\JC Masters\\UTRC Problem\\SocialNetwork.txt";

            this.TextFileLocation = fname;

            bool fileExists = checkFileExists(this.TextFileLocation);
            
            if (fileExists)
                return true;

            return false;
        }

        public bool checkFileExists(string file)
        {
            FileInfo f = new FileInfo(file);
            if (f.Exists)
                return true;

            return false;
        }

    }
}
