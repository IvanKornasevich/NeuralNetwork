using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Topology.Layer
{
    public interface ILayerTopology
    {
        int NeuronsCount { get; }

        Func<double, double> ActivFunc { get; }

        Func<double, double> DerivativeOfActivFunc { get; }
    }
}