using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Learning.LearnCase
{
    internal interface ILearnCase
    {
        IList<double> Answer { get; }

        IList<double> Arguments { get; }
    }
}