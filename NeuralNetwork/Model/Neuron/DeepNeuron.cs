using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Neuron;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepNeuron : Neuron, IDeepNeuron
    {
        public IDeepLayer LayerOfTheNeuron { get; private set; }

        public DeepNeuron(ILayer prev, IDeepLayer current, double defaultWeight = 0.5)
        {
            LayerOfTheNeuron = current;
            Connections = new List<Connection>(prev.Neurons.Count);
            foreach (var neuron in prev.Neurons)
            {
                Connections.Add(new Connection(neuron, defaultWeight));
            }
        }

        public override void Calculate()
        {
            var value = 0d;

            foreach (var connection in Connections)
            {
                value += connection.Neuron.Value * connection.Weight;
            }

            ValueBeforeActivation = value - Threshold;

            Value = LayerOfTheNeuron.ActivationFunction(value - Threshold);
        }
    }
}