using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    internal static class Program
    {
        public static void Main()
        {
            var network = new NeuralNetwork(4, 1);
            var teacher = new Teacher(network);

            teacher.CreateLearnSet(0, 0.1, Func, 10000);
            teacher.Learn();
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

        public static double Func(double x) => Math.Sin(x * 8) + 0.3;
    }
}