using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class LearnCase
    {
        internal double Answer { get; set; }

        internal List<double> Arguments { get; set; }

        public LearnCase(IEnumerable<double> args, double answer)
        {
            Arguments = new List<double>(args);
            Answer = answer;
        }
    }
}