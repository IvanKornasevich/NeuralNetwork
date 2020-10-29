using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Neuron;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class DeepLayer : Layer, IDeepLayer
    {
        public DeepLayer(ILayer prev, int neuronsCount, Func<double, double> activFunc,
                        Func<double, double> derivativeOfActivFunc)
        {
            Neurons = new List<INeuron>(neuronsCount);
            for (var i = 0; i < neuronsCount; ++i)
            {
                Neurons.Add(new DeepNeuron(prev, activFunc, derivativeOfActivFunc));
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