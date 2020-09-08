using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepNeuron : Neuron
    {
        internal Dictionary<Neuron, double> Connections { get; set; } = new Dictionary<Neuron, double>();

        public DeepNeuron(Layer prev, double defaultPriority = 0.5)
        {
            foreach (var neuron in prev.Neurons)
            {
                Connections.Add(neuron, defaultPriority);
            }
        }

        internal override void Calculate()
        {
            var value = 0d;

            foreach (var connection in Connections)
            {
                value += connection.Key.Value * connection.Value;
            }
            Value = NeuralNetwork.ActivationFunction(value);
        }
    }
}