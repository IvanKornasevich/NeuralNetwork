using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NeuralNetwork
{
    internal class NeuralNetwork
    {
        internal List<Layer> Layers { get; private set; }

        internal static double ActivationFunction(double arg) => 1 / (1 + Math.Exp(-arg));

        internal double Run(params double[] args)
        {
            if (args.Length != Layers[0].Neurons.Count)
                throw new ArgumentException("Input parameters count and input neurons count were not same");

            var i = 0;
            Layers[0].Neurons.ForEach(x => (x as InputNeuron).SetValue(args[i++]));

            for (var k = 1; k < Layers.Count; ++k)
            {
                Layers[k].FeedForward();
            }

            return Layers.Last().Neurons.First().Value;
        }

        public NeuralNetwork(params int[] topology)
        {
            var layers = new List<Layer>(topology.Length);

            layers.Add(new InputLayer(topology[0]));

            for (var i = 1; i < topology.Length; i++)
            {
                layers.Add(new DeepLayer(layers[i - 1], topology[i]));
            }

            layers.Add(new DeepLayer(layers.Last(), 1));

            Layers = layers;
        }
    }
}