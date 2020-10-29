using NeuralNetwork.Model.Neuron.Connection;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    abstract internal class Neuron : INeuron
    {
        public double Threshold { get; set; }
        public double Value { get; set; }

        public double ValueBeforeActivation { get; private protected set; }
        public double Error { get; set; }

        public IList<IConnection> Connections { get; private protected set; }

        public Func<double, double> ActivFunc { get; private protected set; }
        public Func<double, double> DerivativeOfActivFunc { get; private protected set; }

        public Neuron(Func<double, double> activFunc, Func<double, double> derivativeOfActiveFunc)
        {
            ActivFunc = activFunc;
            DerivativeOfActivFunc = derivativeOfActiveFunc;
        }

        public abstract void Calculate();
    }
}