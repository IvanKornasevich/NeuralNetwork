using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepLayer : Layer
    {
        public DeepLayer(Layer prev, int neuronsCount)
        {
            var neuronsList = new List<Neuron>(neuronsCount);

            while (neuronsCount > 0)
            {
                neuronsList.Add(new DeepNeuron(prev));
                neuronsCount--;
            }

            Neurons = neuronsList;
        }

        internal override void FeedForward()
        {
            foreach (var neuron in Neurons)
            {
                neuron.Calculate();
            }
        }
    }
}