using NeuralNetwork.Model;
using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Neuron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    internal class Teacher
    {
        internal List<LearnCase> LearnSet { get; private set; }

        private INeuralNetwork NeuralNetwork { get; set; }

        public Teacher(INeuralNetwork neuralNetwork)
        {
            NeuralNetwork = neuralNetwork;
        }

        public Teacher(INeuralNetwork neuralNetwork, List<LearnCase> learnSet)
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

        public void Learn(double learnRate)
        {
            if (LearnSet == null)
                throw new NullReferenceException($"There is no {nameof(LearnSet)} for the {nameof(NeuralNetwork)}");

            var i = 0;
            foreach (var learnCase in LearnSet)
            {
                var networkAnsw = NeuralNetwork.Run(learnCase.Arguments).First();

                var learnCaseAnsw = learnCase.Answer;

                var outNeuron = NeuralNetwork.OutputLayer.Neurons.First();

                BackProp(outNeuron, networkAnsw - learnCaseAnsw);

                if (i % 567 == 0)
                {
                    Console.WriteLine($"network answer => {outNeuron.Value}");
                    Console.WriteLine($"learnCase answer => {learnCase.Answer}");
                    Console.WriteLine($"mistake => {learnCase.Answer - outNeuron.Value}\n");
                }
                ++i;
            }

            void BackProp(INeuron neuron, double currentError)
            {
                if (neuron is IDeepNeuron deepNeuron)
                {
                    var delta = currentError * deepNeuron.LayerOfTheNeuron.DerivativeOfActivationFunction(deepNeuron.ValueBeforeActivation);

                    foreach (var connection in deepNeuron.Connections)
                    {
                        connection.Weight -= learnRate * connection.Neuron.Value * delta;

                        var newError = connection.Weight * delta;
                        BackProp(connection.Neuron, newError);
                    }
                    //deepNeuron.Threshold += learnRate * currentError * deepNeuron.LayerOfTheNeuron.DerivativeOfActivationFunction(deepNeuron.ValueBeforeActivation);
                }
            }
        }
    }
}