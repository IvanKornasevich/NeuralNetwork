using NeuralNetwork.Model.Neuron.Input;
using System;

namespace NeuralNetwork
{
    internal class InputNeuron : Neuron, IInputNeuron
    {
        public InputNeuron(Func<double, double> activFunc, Func<double, double> derivativeOfActiveFunc)
            : base(activFunc, derivativeOfActiveFunc)
        {
        }

        public override void Calculate()
        {
            ValueBeforeActivation = Value;
        }
    }
}