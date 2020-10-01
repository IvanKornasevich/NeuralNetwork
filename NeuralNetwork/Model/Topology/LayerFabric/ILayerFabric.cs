using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Topology
{
    internal interface ILayerFabric
    {
        Layer Create(Layer prev, int neuronsCount, Func<double, double> activationFunction, Func<double, double> derivativeOfActivatoinFunction);
    }
}