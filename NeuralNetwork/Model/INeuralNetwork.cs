using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model
{
    internal interface INeuralNetwork : IEnumerable<ILayer>
    {
        ILayer InputLayer { get; }

        ILayer OutputLayer { get; }

        public IList<ILayer> Layers { get; }

        IList<double> Run(IList<double> args);

        public ILayer this[int idx] { get; }
    }
}