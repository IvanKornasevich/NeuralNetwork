using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    internal class Topology : IEnumerable<LayerTopology>
    {
        internal List<LayerTopology> LayersTopology { get; private set; } = new List<LayerTopology>();

        internal int LayersCount => LayersTopology.Count;

        public Topology()
        {
        }

        internal void AddLayer(LayerTopology layerTopology)
        {
            LayersTopology.Add(layerTopology);
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