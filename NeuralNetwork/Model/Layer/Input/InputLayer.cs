using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Layer.Input;
using NeuralNetwork.Model.Neuron.Input;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    internal class InputLayer : Layer, IInputLayer
    {
        public InputLayer(int neuronsCount)
        {
            Neurons = new List<IInputNeuron>(neuronsCount);

            while (neuronsCount > 0)
            {
                Neurons.Add(new InputNeuron());
                neuronsCount--;
            }
        }

        public override void FeedForward()
        {
        }

        public override IEnumerator<ILayer> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}