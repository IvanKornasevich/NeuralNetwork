using NeuralNetwork.Model.Learning.LearnCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class LearnCase : ILearnCase
    {
        public IList<double> Answer { get; private set; }

        public IList<double> Arguments { get; private set; }

        public LearnCase(IEnumerable<double> args, IEnumerable<double> answer)
        {
            Arguments = new List<double>(args);
            Answer = new List<double>(answer);
        }
    }
}