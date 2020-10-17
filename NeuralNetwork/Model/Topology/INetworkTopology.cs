using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Topology
{
    internal interface INetworkTopology
    {
        IList<ILayer> GenerateLayers();
    }
}