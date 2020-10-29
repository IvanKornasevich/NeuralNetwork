using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Neuron;
using NeuralNetwork.Model.Neuron.Connection;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepNeuron : Neuron, IDeepNeuron
    {
        public DeepNeuron(ILayer prevLayer, Func<double, double> activFunc, Func<double, double> derivativeOfActiveFunc)
            : base(activFunc, derivativeOfActiveFunc)
        {
            Connections = new List<IConnection>(prevLayer.Neurons.Count);

            ActivFunc = activFunc;
            DerivativeOfActivFunc = derivativeOfActiveFunc;

            foreach (var neuron in prevLayer.Neurons)
            {
                Connections.Add(new Connection(neuron));
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

            Value = this.ActivFunc(ValueBeforeActivation);
        }
    }
}