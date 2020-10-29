using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Layer.Input;
using NeuralNetwork.Model.Neuron.Input;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class InputLayer : Layer, IInputLayer
    {
        public InputLayer(int neuronsCount)
        {
            Neurons = new List<INeuron>(neuronsCount);

            for (var i = 0; i < neuronsCount; ++i)
            {
                Neurons.Add(new InputNeuron(x => x, x => 1));
            }
        }

        public void FeedForward()
        {
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