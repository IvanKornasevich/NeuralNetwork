using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class LearnCase
    {
        internal double Answer { get; private set; }

        internal List<double> Arguments { get; private set; }

        public LearnCase(IEnumerable<double> args, double answer)
        {
            Arguments = new List<double>(args);
            Answer = answer;
        }
    }
}