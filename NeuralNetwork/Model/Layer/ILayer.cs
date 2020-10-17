using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal interface ILayer : IEnumerable<INeuron>
    {
        IList<INeuron> Neurons { get; }

        void FeedForward();
    }
}