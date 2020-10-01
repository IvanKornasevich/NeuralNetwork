﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    internal static class Program
    {
        public static void Main()
        {
            var topology = new Topology();
            topology.AddLayer(new LayerTopology(4, x => x, x => 1));
            topology.AddLayer(new LayerTopology(4, Sigmoid, DerivativeOfSigmoid));
            topology.AddLayer(new LayerTopology(4, x => x, x => 1));

            var network = new NeuralNetwork(topology);
            var teacher = new Teacher(network);

            teacher.CreateLearnSet(0, 0.1, Func, 1000);
            teacher.Learn(0.01);
            teacher.Test();
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