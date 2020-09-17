using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class Teacher
    {
        internal NeuralNetwork NeuralNetwork { get; private set; }

        internal IEnumerable<LearnCase> LearnSet { get; private set; }

        public Teacher(NeuralNetwork neuralNetwork, IEnumerable<LearnCase> learnSet)
        {
            NeuralNetwork = neuralNetwork;
            LearnSet = learnSet;
        }

        public void Learn(double n)
        {
        }
    }
}