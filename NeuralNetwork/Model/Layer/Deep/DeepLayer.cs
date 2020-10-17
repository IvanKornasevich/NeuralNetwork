using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Neuron;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepLayer : Layer, IDeepLayer
    {
        public Func<double, double> ActivationFunction { get; private set; }

        public Func<double, double> DerivativeOfActivationFunction { get; private set; }

        Func<double, double> IDeepLayer.ActivationFunction => throw new NotImplementedException();

        Func<double, double> IDeepLayer.DerivativeOfActivationFunction => throw new NotImplementedException();

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

        public override void FeedForward()
        {
            foreach (var neuron in Neurons)
            {
                neuron.Calculate();
            }
        }

        public override IEnumerator<INeuron> GetEnumerator()
        {
            return Neurons.GetEnumerator();
        }
    }
}