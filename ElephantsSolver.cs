using System;
using System.Collections.Generic;

namespace RecruitmentTask
{
    class ElephantsData
    {
        public int Count { get; set; }
        public int[] Weights { get; set; }  //TODO: Change into List<int>
        public int[] InitialArrangement { get; set; }
        public int[] TargetArrangement { get; set; }
    }
    class Cycle
    {
        public List<int> Vertices { get; set; }
        public int MinWeight { get; set; }
        //public int MinWeightIndex { get; set; }
        public int SumWeight { get; set; }
        public int Length { get { return Vertices.Count; } }

        public Cycle()
        {
            Vertices = new List<int>();
        }
    }
    class ElephantsSolver
    {
        public ElephantsData Data { get; set; }
        public DataParser Parser { get; private set; }
        private int[] Graph { get; set; }
        public int ResultWeight { get; set; }
        private int MinWeight { get; set; }
        //private int MinWeightIndex { get; set; }
        public List<Cycle> Cycles { get; set; }

        bool[] processedVertices;

        public ElephantsSolver()
        {
            Data = new ElephantsData();
            Parser = new DataParser(Data);

            //Array of vertices of the graph
            //indices are numbers of specific elephants
            //order of the elephants in the arrangement is not to be concerned of
            //as long as it is known which elephant should be in the place of a specific elephant in the end
            //values are which elephant should be in the place of the current elephant in the end
            //value 5 under index 2 means that in the end elephant (2) should be where elephant (5) is
            //(there is an edge (2,5) in the graph)

            ResultWeight = 0;
            MinWeight = Int32.MaxValue;

            Cycles = new List<Cycle>();
        }

        public void ParseInputData()
        {
            Parser.ParseInputData();
        }

        public void PartitionIntoCycles()
        {
            InitializeGraph();

            processedVertices = new bool[Data.Count + 1];
            processedVertices[0] = true; //sentiel

            for (int i = 1; i < processedVertices.Length; i++)
            {
                if (!processedVertices[i])
                {
                    var cycle = new Cycle();

                    cycle.MinWeight = Data.Weights[i - 1];
                    cycle.SumWeight += Data.Weights[i - 1];
                    cycle.Vertices.Add(i);

                    processedVertices[i] = true;

                    FindCycle(i, cycle);

                    if(cycle.MinWeight < MinWeight)
                    {
                        MinWeight = cycle.MinWeight;
                    }

                    Cycles.Add(cycle);
                }
            }
        }

        private void InitializeGraph()
        {
            Graph = new int[Data.Count + 1];
            Graph[0] = 0; //sentiel

            for (int i = 0; i < Data.InitialArrangement.Length; i++)
            {
                int from = Data.InitialArrangement[i];
                int to = Data.TargetArrangement[i];
                Graph[from] = to;
            }
        }

        private void FindCycle(int start, Cycle cycle)
        {
            int next = Graph[start];
            while (next != start)
            {
                if(Data.Weights[next - 1] < cycle.MinWeight)
                {
                    cycle.MinWeight = Data.Weights[next - 1];
                }
                cycle.SumWeight += Data.Weights[next - 1];
                cycle.Vertices.Add(next);
                processedVertices[next] = true;
                next = Graph[next];
            }
        }

        public void SolveCycles()
        {
            foreach (var cycle in Cycles)
            {
                ResultWeight += SolveCycle(cycle);
            }
        }

        private int SolveCycle(Cycle cycle)
        {
            if(IsSecondMethodBetter(cycle))
            {
                return SolveCycleSecondMethod(cycle);
            }
            else
            {   
                return SolveCycleFirstMethod(cycle);
            }
        }

        private bool IsSecondMethodBetter(Cycle cycle)
        {
            return (cycle.Length - 3)/(cycle.Length + 1) * cycle.MinWeight > MinWeight; //sum(C) + (|C|-2) * min(C) >? sum(C) + min(C) + (|C|+1) * min
        }

        private int SolveCycleFirstMethod(Cycle cycle)
        {
            // int cost = 0;
            // while(Graph[cycle.MinWeightIndex] != cycle.MinWeightIndex)  //until lightest elephant is in target position
            // {
            //     int prevInCycle = Graph[cycle.MinWeightIndex];
            //     Graph[cycle.MinWeightIndex] = Graph[prevInCycle];
            //     Graph[prevInCycle] = prevInCycle;   //in target position

            //     cost += Data.Weights[prevInCycle];
            //     cost += cycle.MinWeight;
            // }
            // ResultWeight += cost;
            return cycle.SumWeight + (cycle.Length - 2) * cycle.MinWeight;
        }
        private int SolveCycleSecondMethod(Cycle cycle)
        {
            // int cost = 0;
            // while(Graph[cycle.MinWeightIndex] != cycle.MinWeightIndex)  //until lightest elephant is in target position
            // {
            //     int prevInCycle = Graph[cycle.MinWeightIndex];
            //     Graph[cycle.MinWeightIndex] = Graph[prevInCycle];
            //     Graph[prevInCycle] = prevInCycle;   //in target position

            //     cost += Data.Weights[prevInCycle];
            //     cost += cycle.MinWeight;
            // }
            // ResultWeight += cost;
            return cycle.SumWeight + cycle.MinWeight + (cycle.Length + 1) * MinWeight;
        }
    }
}