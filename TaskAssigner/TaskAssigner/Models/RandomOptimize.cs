using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAssigner.Models;
using TaskAssigner.Models.Repositories;

namespace TaskAssigner.Domain
{
    public class RandomOptimize : OptimizationAlgorithm
    {
        /// <summary>
        /// Generates a series of random solutions and finds the one with the lowest cost.
        /// </summary>
        /// <param name="developerRepository"></param>
        /// <param name="ticketRepository"></param>
        public RandomOptimize(IDeveloperRepository developerRepository, ITicketRepository ticketRepository) : base(developerRepository, ticketRepository)
        {

        }

        /// <summary>
        /// Gets the best solution for the RandomOptimize algorithm.
        /// </summary>
        /// <returns>
        /// Returns a list that represents each ticket.  Each value in the list corresponds to the index of a developer int he developers list.
        /// For example, [1, 0, 2, 3] indicates that the first ticket was assigned to the 2nd developer in the developers list, the second ticket is assigned to the first developer
        /// in the developers list, and so forth.
        /// </returns>
        public override List<int> GetSolution()
        {
            int bestCost = int.MaxValue;
            List<int> bestSolution = new List<int>();
            var random = new Random();

            for(int i = 0; i < 1000; i++)
            {
                var randomSolution = GetRandomSolution(this.Domain, random);

                int cost = CostCalculator.Calculate(randomSolution);
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
