using NeuralNetwork.Model;
using NeuralNetwork.Model.Topology;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    internal class NeuralNetwork : INeuralNetwork
    {
        public ILayer InputLayer => Layers.First();

        internal List<ILayer> Layers { get; private set; }

        public ILayer OutputLayer => Layers.Last();

        public NeuralNetwork(ITopology topology)
        {
            Layers = topology.GenerateLayers();
        }

        public List<double> Run(List<double> args)
        {
            if (args.Count != InputLayer.Neurons.Count)
                throw new ArgumentException("Input parameters count and input neurons count were not same");

            var i = 0;
            InputLayer.Neurons.ForEach(x => x.Value = args[i++]);

            Layers.ForEach(x => x.FeedForward());

            return OutputLayer.Neurons.Select(x => x.Value).ToList();
        }
    }
}