using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    internal class NeuralNetwork
    {
        internal Layer InputLayer => Layers.First();

        internal List<Layer> Layers { get; private set; }

        internal Layer OutputLayer => Layers.Last();

        public NeuralNetwork(params int[] topology)
        {
            if (topology.Length < 2)
            {
                throw new ArgumentException($"Topology length was {topology.Length} but more than 2 expected");
            }

            foreach (var item in topology)
            {
                if (item < 1)
                    throw new ArgumentException($"Layer length was {item} but more than 1 expected");
            }

            Layers = new List<Layer>(topology.Length)
            {
                new InputLayer(topology[0])
            };

            for (var i = 1; i < topology.Length; i++)
            {
                Layers.Add(new DeepLayer(Layers[i - 1], topology[i]));
            }
        }

        internal static double ActivationFunction(double arg) => arg;

        internal IEnumerable<double> Run(List<double> args)
        {
            if (args.Count != InputLayer.Neurons.Count)
                throw new ArgumentException("Input parameters count and input neurons count were not same");

            var i = 0;
            InputLayer.Neurons.ForEach(x => x.Value = args[i++]);

            Layers.ForEach(x => x.FeedForward());
            return OutputLayer.Neurons.Select(x => x.Value);
        }
    }
}