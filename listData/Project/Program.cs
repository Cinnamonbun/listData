// 2017 https://github.com/Cinnamonbun
// Feel free to modify or use for non-profit purposes.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewListData
{
    class Program
    {
        // listPath created to show where the listData.txt file is located.
        public static string listPath = @"K:\listData\listRandomData.txt";
        public static string userInput = null;
        public static string listDataTxtContents;
        // Properties of the list, later defined.
        public static int listDataSum = 0;
        public static int listDataMax = 0;
        public static int listDataMin = 0;
        public static int listDataAll = 0;
        //
        public static bool userInteractionPhase;

        static void Main(string[] args)
            {
            Console.WriteLine("Please input the directory where you placed 'listRandomData.txt'");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"Example: C:\listData\listRandomData.txt");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("!DO NOT MESS THIS UP!");
            Console.ForegroundColor = ConsoleColor.White;
            listPath = Console.ReadLine();
            userInteractionPhase = true;
            Console.ForegroundColor = ConsoleColor.Green;
            while (userInteractionPhase)
                {               
                Console.WriteLine("Type 'generate' to generate a list of random integers(50 lines)");
                Console.WriteLine("If you already have a list, or already generated one, please type 'listready'");
                userInput = Console.ReadLine();
                userInput.ToLower();
                if (userInput == "generate")
                    {
                    Console.Clear();
                    generateList();
                    Console.Clear();
                    }

                if (userInput == "listready")

                    {
                    Console.Clear();
                    // After list is created, user can now request to see properties of list.
                    Console.WriteLine("Please input the data you wish to see, type 'help' for what to type");
                    userInput = Console.ReadLine();
                    userInput.ToLower();
                    if (userInput == "matlab")
                        {
                        Console.WriteLine("This will open Matlab. To import the randomly generated data, run 'importRandomData.m' in Matlab");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Process matlab = null;
                        startProgram(matlab, "matlab.exe");
                        Console.Clear();
                        }

                    if (userInput == "sum")
                        {
                        Console.WriteLine("The sum of the list is " + listDataSum);
                        Console.ReadKey();
                        Console.Clear();
                        }
                    if (userInput == "max")
                        {
                        Console.WriteLine("The max of the list is " + listDataMax);
                        Console.ReadKey();
                        Console.Clear();
                        }
                    if (userInput == "min")
                        {
                        Console.WriteLine("The min of the list is " + listDataMin);
                        Console.ReadKey();
                        Console.Clear();
                        }
                    if (userInput == "help")
                        {
                        Console.WriteLine("Type 'sum' to view the sum of all integers in the list");
                        Console.WriteLine("Type 'max' to view the max of all integers(highest number) in the list");
                        Console.WriteLine("Type 'min' to view the min of all integers(lowest number) in the list");
                        Console.WriteLine("Type 'generate' at the first option menu to generate a sequence of random integers");
                        Console.WriteLine("Type 'matlab' to open the document as a variable in Matlab");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        
                        }
                    
                    }
                
                }
            
            }

        static void generateList()
            {
            // Calls GenerateTxtRandom method in order to randomly generate a text file with integers.
            GenerateTxtRandom();
            // Reads the listPath file and puts contents of listPath into a list.
            var fileReader = new System.IO.StreamReader(listPath);
            List<string> stringsFromFile = new List<string>();

            while ((listDataTxtContents = fileReader.ReadLine()) != null)
                {
                stringsFromFile.Add(listDataTxtContents);
                }
            List<int> dataSet = new List<int>();

            foreach (string s in stringsFromFile)
                {
                int temp = 0;
                if (Int32.TryParse(s, out temp))
                    {
                    dataSet.Add(temp);
                    }
                }
            // After integers from file are put into the dataSet List, the user can now take whatever value they need from the list.

            listDataSum = dataSet.Sum();
            listDataMax = dataSet.Max();
            listDataMin = dataSet.Min();
            }
           
        static void GenerateTxtRandom()
        {
            // This method randomly generates integers and writes it to whatever file you want. Use .txt and .m files.
            // Declare file location of text file to be written to, declare new RNG and List
            string listRandomDataPath = listPath;
            Random numberGenerator = new Random();
            List<int> generatedList = new List<int>();
            // User interaction
            Console.WriteLine("50 random integers will be written to " + listPath);
            Console.WriteLine("Press any key to continue");
            // After receiving user input, numbers are generated and written to listRandomData.txt
            Console.ReadKey();
            Console.Clear();      
                while (generatedList.Count < 51)
                {
                    generatedList.Add(numberGenerator.Next(1, 50001));
                }
            Convert.ToString(generatedList);
            System.IO.File.WriteAllLines(listRandomDataPath, generatedList.ConvertAll(Convert.ToString));
            // End of Method
            Console.WriteLine("50 integers written to " + listPath + " press any key to continue.");
            Console.ReadKey();
        }

        static void startProgram(Process programName, string programProcessExe)
        {
            // Starts whatever program you need to start
            // IMPORTANT: Before calling this method, make sure to declare a Process name, ie, Process matlab = null;
            // So when called it should look something like this: startProgram(matlab, "matlab.exe");

            programName = new Process();
            programName.StartInfo.FileName = programProcessExe;
            programName.StartInfo.RedirectStandardInput = true;
            programName.StartInfo.RedirectStandardOutput = true;
            programName.StartInfo.CreateNoWindow = true;
            programName.StartInfo.UseShellExecute = false;

            programName.Start();
            // Code to be possibly used in next revision.
            //string temp = "open listRandomData.Txt";
            //Process.Start(@"F:\Matlab 2015a\bin\win64\Matlab.exe", temp);
            // End of Method
        }
    }
}
