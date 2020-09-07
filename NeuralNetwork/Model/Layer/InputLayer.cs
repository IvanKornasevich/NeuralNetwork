using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class InputLayer : Layer
    {
        public InputLayer(int neuronsCount)
        {
            var neuronsList = new List<Neuron>(neuronsCount);

            while (neuronsCount > 0)
            {
                neuronsList.Add(new InputNeuron());
                neuronsCount--;
            }

            Neurons = neuronsList;
        }

        internal override void FeedForward()
        {
            throw new NotImplementedException();
        }
    }
}