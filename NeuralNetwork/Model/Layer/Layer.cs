using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Layer
{
    internal class Layer
    {
        public IList<INeuron> Neurons { get; private protected set; }

        public INeuron this[int i] => Neurons[i];
    }
}