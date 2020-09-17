using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    internal class Program
    {
        public static void Main()
        {
            var network = new NeuralNetwork(5);

            var learnSet = new List<LearnCase>(15);
            for (var i = 0; i < 15; ++i)
            {
                learnSet.Add(new LearnCase(new double[] { i, i, i, i, i }, Func(i)));
            }

            var teacher = new Teacher(network, learnSet);

            Console.WriteLine(network.Run(-10, 3));
        }

        public static double Func(double x) => 1 * Math.Sin(x * 8) + 0.3;
    }
}