﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskAssigner.Domain
{
    interface IOptimizationAlgorithm
    {
       
        List<int> GetSolution(List<List<int>> domain, Cost costCalculator);
    }
}
