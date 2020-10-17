using NeuralNetwork.Model;
using NeuralNetwork.Model.Topology;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    internal class NeuralNetwork : INeuralNetwork
    {
        public ILayer InputLayer => Layers.First();
        public ILayer OutputLayer => Layers.Last();
        public IList<ILayer> Layers { get; private set; }

        public NeuralNetwork(INetworkTopology topology)
        {
            Layers = topology.GenerateLayers();
        }

        public IList<double> Run(IList<double> args)
        {
            if (args.Count != InputLayer.Neurons.Count)
                throw new ArgumentException("Input parameters count and input neurons count were not same");

            for (var i = 0; i < args.Count; ++i)
            {
                InputLayer.Neurons[i].Value = args[i];
            }

            foreach (var layer in Layers)
            {
                layer.FeedForward();
            }

            return OutputLayer.Neurons.Select(x => x.Value).ToArray();
        }

        public ILayer this[int idx] => Layers[idx];

        public IEnumerator<ILayer> GetEnumerator()
        {
            return Layers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}