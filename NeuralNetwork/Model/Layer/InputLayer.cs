using NeuralNetwork.Model.Layer;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class InputLayer : Layer
    {
        public InputLayer(int neuronsCount)
        {
            Neurons = new List<INeuron>(neuronsCount);

            while (neuronsCount > 0)
            {
                Neurons.Add(new InputNeuron());
                neuronsCount--;
            }
        }

        public override void FeedForward()
        {
        }
    }
}