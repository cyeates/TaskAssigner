using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskAssigner.Domain
{
    public class RandomOptimize : IOptimizationAlgorithm
    {
        public List<int> GetSolution(List<List<int>> domain, Cost costCalculator)
        {
            int bestCost = int.MaxValue;
            List<int> bestSolution = new List<int>();
            var random = new Random();

            for(int i = 0; i < 1000; i++)
            {
                var randomSolution = GetRandomSolution(domain, random);

                int cost = costCalculator.Calculate(randomSolution);
                if (cost < bestCost)
                {
                    bestCost = cost;
                    bestSolution = randomSolution;

                    if (cost == 0)
                        return bestSolution;
                }
                
            }

            return bestSolution;
        }

        private static List<int> GetRandomSolution(List<List<int>> domain, Random random)
        {
            var randomSolution = new List<int>();
            for (int j = 0; j < domain.Count; j++)
            {
                randomSolution.Add(random.Next(domain[j][0], domain[j][1]));
            }
            return randomSolution;
        }
    }
}
