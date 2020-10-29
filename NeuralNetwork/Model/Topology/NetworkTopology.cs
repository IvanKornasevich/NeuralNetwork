using NeuralNetwork.Model.Topology;
using NeuralNetwork.Model.Topology.Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class NetworkTopology : INetworkTopology, IEnumerable<ILayerTopology>
    {
        internal IList<ILayerTopology> LayersTopology { get; private set; } = new List<ILayerTopology>();

        internal int LayersCount => LayersTopology.Count;

        internal void Add(ILayerTopology layerTopology)
        {
            LayersTopology.Add(layerTopology);
        }

        public IList<ILayer> GenerateLayers()
        {
            var layers = new List<ILayer>(LayersCount)
            {
                new InputLayer(LayersTopology[0].NeuronsCount)
            };

            for (var i = 1; i < LayersCount; ++i)
            {
                var currentTopology = LayersTopology[i];
                layers.Add(new DeepLayer(layers[i - 1], currentTopology.NeuronsCount,
                                        currentTopology.ActivFunc, currentTopology.DerivativeOfActivFunc));
            }

            return layers;
        }

        public IEnumerator<ILayerTopology> GetEnumerator()
        {
            return LayersTopology.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal ILayerTopology this[int i] => LayersTopology[i];
    }
}