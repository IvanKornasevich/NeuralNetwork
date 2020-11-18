using NeuralNetwork.Model.Neuron.Connection;
using NeuralNetwork.Model.Neuron.Input;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class InputNeuron : Neuron, IInputNeuron
    {
        public InputNeuron(Func<double, double> activFunc, Func<double, double> derivativeOfActiveFunc)
            : base(activFunc, derivativeOfActiveFunc)
        {
            Connections = new List<IConnection>();
        }

        public override void Calculate()
        {
            ValueBeforeActivation = Value;
        }
    }
}