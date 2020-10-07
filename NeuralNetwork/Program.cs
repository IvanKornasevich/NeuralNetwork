using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    internal static class Program
    {
        public static void Main()
        {
            var topology = new Topology
            {
                new LayerTopology(10, x => x, x => 1),
                new LayerTopology(4, Sigmoid, DerivativeOfSigmoid),
                new LayerTopology(1, x => x, x => 1)
            };

            var network = new NeuralNetwork(topology);
            var teacher = new Teacher(network);

            teacher.CreateLearnSet(0, 0.1, Func, 1000);

            for (var i = 0; i < 5000; ++i)
            {
                teacher.Learn(0.1);
            }
        }

        public static string AnswerToString<T>(this IEnumerable<T> seq)
        {
            var s = new List<string>();

            foreach (var item in seq)
            {
                s.Add(item.ToString());
            }

            return string.Join('\n', s);
        }

        public static double Func(double x) => 0.1 * Math.Cos(0.3 * x) + 0.08 * Math.Sin(0.2 * x);

        public static double Sigmoid(double x) => 1 / (1 + Math.Exp(-x));

        public static double DerivativeOfSigmoid(double x) => Sigmoid(x) * (1 - Sigmoid(x));
    }
}