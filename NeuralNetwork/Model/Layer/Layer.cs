using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Layer
{
    internal abstract class Layer : ILayer
    {
        public List<INeuron> Neurons { get; private protected set; }

        public abstract void FeedForward();
    }
}