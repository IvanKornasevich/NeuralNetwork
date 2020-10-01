using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepLayer : Layer
    {
        public DeepLayer(Layer prev, int neuronsCount)
        {
            Neurons = new List<Neuron>(neuronsCount);

            while (neuronsCount > 0)
            {
                Neurons.Add(new DeepNeuron(prev));
                neuronsCount--;
            }
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