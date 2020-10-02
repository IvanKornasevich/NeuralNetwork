using NeuralNetwork.Model.Topology;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class Topology : ITopology, IEnumerable<LayerTopology>
    {
        internal List<LayerTopology> LayersTopology { get; private set; } = new List<LayerTopology>();

        internal int LayersCount => LayersTopology.Count;

        internal void Add(LayerTopology layerTopology)
        {
            LayersTopology.Add(layerTopology);
        }

        public List<ILayer> GenerateLayers()
        {
            var layers = new List<ILayer>(LayersCount)
            {
                new InputLayer(LayersTopology[0].NeuronsCount)
            };

            for (var i = 1; i < LayersCount; ++i)
            {
                var currentTopology = LayersTopology[i];
                layers.Add(new DeepLayer(layers[i - 1], currentTopology.NeuronsCount, currentTopology.ActivationFunction, currentTopology.DerivativeOfActivationFunction));
            }

            return layers;
        }

        internal LayerTopology this[int i] => LayersTopology[i];

        public IEnumerator<LayerTopology> GetEnumerator()
        {
            return LayersTopology.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}