using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model
{
    internal interface INeuralNetwork
    {
        List<double> Run(List<double> args);

        ILayer InputLayer { get; }

        ILayer OutputLayer { get; }
    }
}