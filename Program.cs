using System;

namespace RecruitmentTask
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("This program requires that input is redirected from a file.");
                return;
            }

            var solver = new ElephantsSolver();
            solver.ParseInputData();
            (new Util()).PrintData(solver);
        }
    }
}