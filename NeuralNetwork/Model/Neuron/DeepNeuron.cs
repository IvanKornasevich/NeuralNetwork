using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepNeuron : Neuron
    {
        public DeepNeuron(Layer prev, double defaultWeight = 0.5)
        {
            Connections = new List<Connection>(prev.Neurons.Count);
            foreach (var neuron in prev.Neurons)
            {
                Connections.Add(new Connection(neuron, defaultWeight));
            }
        }

        internal override void Calculate()
        {
            var value = 0d;

            foreach (var connection in Connections)
            {
                value += connection.Neuron.Value * connection.Weight;
            }
            Value = NeuralNetwork.ActivationFunction(value - Threshold);
        }
    }
}