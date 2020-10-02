using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Layer
{
    internal interface IDeepLayer
    {
        Func<double, double> ActivationFunction { get; }

        Func<double, double> DerivativeOfActivationFunction { get; }
    }
}