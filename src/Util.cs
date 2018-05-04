using System;

namespace RecruitmentTask
{
    class Util
    {
        public void PrintData(ElephantsSolver solver)
        {
            // System.Console.WriteLine("Count: {0}", solver.Data.Count);
            // System.Console.Write("Weights: ");
            // foreach (var item in solver.Data.Weights)
            // {
            //     System.Console.Write("{0} ", item);
            // }
            // System.Console.WriteLine();
            // System.Console.Write("Initial arrangement: ");
            // foreach (var item in solver.Data.InitialArrangement)
            // {
            //     System.Console.Write("{0} ", item);
            // }
            // System.Console.WriteLine();
            // System.Console.Write("Target arrangement: ");
            // foreach (var item in solver.Data.TargetArrangement)
            // {
            //     System.Console.Write("{0} ", item);
            // }
            // System.Console.WriteLine();
            // foreach (var cycle in solver.Cycles)
            // {
            //     System.Console.Write("Cycle: ");
            //     foreach (var vertex in cycle.Vertices)
            //     {
            //         System.Console.Write("{0} ", vertex);
            //     }
            //     System.Console.WriteLine();
            // }
            // System.Console.WriteLine();
            System.Console.WriteLine("Result: {0}", solver.ResultWeight);
        }
    }
}