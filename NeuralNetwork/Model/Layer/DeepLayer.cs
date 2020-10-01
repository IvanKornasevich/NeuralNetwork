using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepLayer : Layer
    {
        internal Func<double, double> ActivationFunction { get; private set; }

        internal Func<double, double> DerivativeOfActivationFunction { get; private set; }

        public DeepLayer(Layer prev, int neuronsCount, Func<double, double> activationFunction, Func<double, double> derivativeOfActivatoinFunction)
        {
            ActivationFunction = activationFunction;
            DerivativeOfActivationFunction = derivativeOfActivatoinFunction;

            Neurons = new List<Neuron>(neuronsCount);
            while (neuronsCount > 0)
            {
                Neurons.Add(new DeepNeuron(prev, this));
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