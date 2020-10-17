using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Neuron;
using NeuralNetwork.Model.Neuron.Connection;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepNeuron : Neuron, IDeepNeuron
    {
        public IList<IConnection> Connections { get; private set; }
        public IDeepLayer LayerOfTheNeuron { get; private set; }
        public double ValueBeforeActivation { get; set; }
        public double Error { get; set; }

        public DeepNeuron(ILayer prev, IDeepLayer current, double defaultWeight = 0.1)
        {
            LayerOfTheNeuron = current;
            Connections = new List<IConnection>(prev.Neurons.Count);
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

            Value = LayerOfTheNeuron.ActivationFunction(ValueBeforeActivation);
        }
    }
}