using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Layer
{
    internal abstract class Layer : ILayer
    {
        public IList<INeuron> Neurons { get; private protected set; }

        public abstract void FeedForward();

        public abstract IEnumerator<INeuron> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}