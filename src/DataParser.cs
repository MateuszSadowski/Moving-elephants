using System;
using System.IO;

namespace RecruitmentTask
{
    public class DataParser
    {
        ElephantsData OutputData {get; set;}
        StreamReader file;
        String textLine;

        public DataParser(ElephantsData outputData, String pathToFile = null)
        {
            OutputData = outputData;
            if(pathToFile != null)
            {
                file = new StreamReader(pathToFile);
            }
        }
        public void ParseInputData()
        {
            ReadLine();
            ParseCount();
            ReadLine();
            ParseWeights();
            ReadLine();
            ParseInitialArrangement();
            ReadLine();
            ParseTargetArrangement();
        }

        private void ReadLine()
        {
            try
            {
                textLine = file != null ? file.ReadLine() : Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void ParseCount()
        {
            OutputData.Count = ParseNumber(textLine);
        }

        private void ParseWeights()
        {
            String[] weights = textLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            OutputData.Weights = new int[OutputData.Count];
            for (int i = 0; i < OutputData.Count; i++)
            {
                OutputData.Weights[i] = ParseNumber(weights[i]);
            }
        }
        private void ParseInitialArrangement()
        {
            String[] initialArrangement = textLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            OutputData.InitialArrangement = new int[OutputData.Count];
            for (int i = 0; i < OutputData.Count; i++)
            {
                OutputData.InitialArrangement[i] = ParseNumber(initialArrangement[i]);
            }
        }
        private void ParseTargetArrangement()
        {
            String[] targetArrangement = textLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            OutputData.TargetArrangement = new int[OutputData.Count];
            for (int i = 0; i < OutputData.Count; i++)
            {
                OutputData.TargetArrangement[i] = ParseNumber(targetArrangement[i]);
            }
        }

        private static int ParseNumber(String number)
        {
            int parsedNumber;
            bool success = int.TryParse(number, out parsedNumber);
            if (success)
            {
                return parsedNumber;
            }
            else
            {
                Console.WriteLine("Attempted conversion of '{0}' failed.",
                    number == null ? "<null>" : number);
                throw new InvalidProgramException("Exception thrown while parsing input data.");
            }
        }
    }
}