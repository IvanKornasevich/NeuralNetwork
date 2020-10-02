using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Topology
{
    internal interface ITopology
    {
        List<ILayer> GenerateLayers();
    }
}