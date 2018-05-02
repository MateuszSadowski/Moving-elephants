using System;
using System.Collections.Generic;

namespace RecruitmentTask
{
    class ElephantsData
    {
        public int Count { get; set; }
        public int[] Weights { get; set; }
        public int[] InitialArrangement { get; set; }
        public int[] TargetArrangement { get; set; }
    }
    class ElephantsSolver
    {
        public ElephantsData Data { get; set; }
        public DataParser Parser { get; private set; }
        private int[] Graph { get; set; }
        private int ResultWeight { get; set; }
        public List<List<int>> Cycles { get; set; }

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

            Cycles = new List<List<int>>();
        }

        public void ParseInputData()
        {
            Parser.ParseInputData();
        }

        public void PartitionIntoCycles()
        {
            Graph = new int[Data.Count + 1];
            Graph[0] = 0; //sentiel
            // Array.Copy(Data.InitialArrangement, 0, Graph, 1, Data.Count);
            for (int i = 0; i < Data.InitialArrangement.Length; i++)
            {
                Graph[Data.InitialArrangement[i]] = Data.TargetArrangement[i];  //TODO: cleanup
            }
            processedVertices = new bool[Data.Count + 1];
            processedVertices[0] = true;    //sentiel

            for (int i = 1; i < processedVertices.Length; i++)
            {
                if(processedVertices[i])
                    continue;

                var cycle = new List<int>();
                cycle.Add(i);
                processedVertices[i] = true;
                FindCycle(i, cycle);
                // var foundCycle = new int[cycle.Count];
                // int j = 0;
                // while(cycle.Count > 0)
                // {
                //     foundCycle[j++] = cycle.
                // }
                Cycles.Add(cycle);  //TODO: do it better?
            }
        }

        private void FindCycle(int start, List<int> cycle)
        {
            int next = Graph[start];
            while(next != start)
            {
                cycle.Add(next);
                processedVertices[next] = true;
                next = Graph[next];
            }
        }
    }
}