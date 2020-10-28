using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Neuron;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepLayer : Layer, IDeepLayer
    {
        public Func<double, double> ActivationFunction { get; private set; }

        public Func<double, double> DerivativeOfActivationFunction { get; private set; }

        public DeepLayer(ILayer prev, int neuronsCount, Func<double, double> activationFunction,
                        Func<double, double> derivativeOfActivatoinFunction)
        {
            ActivationFunction = activationFunction;
            DerivativeOfActivationFunction = derivativeOfActivatoinFunction;

            Neurons = new List<INeuron>(neuronsCount);
            while (neuronsCount > 0)
            {
                Neurons.Add(new DeepNeuron(prev, this));
                neuronsCount--;
            }
        }

        public void FeedForward()
        {
            foreach (var neuron in Neurons)
            {
                neuron.Calculate();
            }
        }

        public IEnumerator<INeuron> GetEnumerator()
        {
            return Neurons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}