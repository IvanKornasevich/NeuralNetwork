using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    internal class Teacher
    {
        internal List<LearnCase> LearnSet { get; private set; }

        private NeuralNetwork NeuralNetwork { get; set; }

        public Teacher(NeuralNetwork neuralNetwork)
        {
            NeuralNetwork = neuralNetwork;
        }

        public Teacher(NeuralNetwork neuralNetwork, List<LearnCase> learnSet)
        {
            NeuralNetwork = neuralNetwork;
            LearnSet = learnSet;
        }

        internal void CreateLearnSet(double start, double step, Func<double, double> func, int count = 10000)
        {
            LearnSet = new List<LearnCase>();
            var dataSet = new List<double>();
            for (var i = start; dataSet.Count < count + NeuralNetwork.InputLayer.Neurons.Count; i += step)
            {
                dataSet.Add(func(i));
            }

            for (var i = 0; i < dataSet.Count - NeuralNetwork.InputLayer.Neurons.Count; ++i)
            {
                var caseArgs = new List<double>();
                int j;
                for (j = 0; j < NeuralNetwork.InputLayer.Neurons.Count; ++j)
                {
                    caseArgs.Add(dataSet[i + j]);
                }
                LearnSet.Add(new LearnCase(caseArgs, dataSet[i + j]));
            }
        }

        public void Learn()
        {
            if (LearnSet == null)
                throw new NullReferenceException($"There is no {nameof(LearnSet)} for the {nameof(NeuralNetwork)}");

            var i = 0;
            foreach (var learnCase in LearnSet)
            {
                var networkAnsw = NeuralNetwork.Run(learnCase.Arguments).First();
                var outNeuron = NeuralNetwork.OutputLayer.Neurons.First();

                #region logs

                if (i % (LearnSet.Count / 1000) == 0)
                {
                    Console.WriteLine($"network answer => {outNeuron.Value}");
                    Console.WriteLine($"learnCase answer => {learnCase.Answer}");
                    Console.WriteLine($"mistake => {learnCase.Answer - outNeuron.Value}\n");
                }

                #endregion logs

                if (Math.Abs(learnCase.Answer - outNeuron.Value) < 1e-14)
                {
                    Console.WriteLine($"network answer => {networkAnsw}");
                    Console.WriteLine($"learnCase answer => {learnCase.Answer}");
                    Console.WriteLine($"mistake => {learnCase.Answer - networkAnsw}\n");
                    return;
                }

                double step = 1 / (1 + learnCase.Arguments.Sum(x => x * x));

                foreach (var connection in outNeuron.Connections)
                {
                    connection.Weight -= step * (networkAnsw - learnCase.Answer) * connection.Neuron.Value;
                }
                outNeuron.Threshold += step * (networkAnsw - learnCase.Answer);

                ++i;
            }
        }

        public void Test()
        {
            var networkArgs = new List<double>(LearnSet.First().Arguments);

            var j = 0;

            foreach (var learnCase in LearnSet)
            {
                var answ = NeuralNetwork.Run(networkArgs).First();

                if (++j % 100 == 0)
                {
                    Console.WriteLine($"Mistake = {answ - learnCase.Answer}");
                }

                var networkInputCount = NeuralNetwork.InputLayer.Neurons.Count;

                for (var i = 0; i < networkInputCount - 1; ++i)
                {
                    networkArgs[i] = networkArgs[i + 1];
                }

                networkArgs[networkInputCount - 1] = answ;
            }
        }
    }
}