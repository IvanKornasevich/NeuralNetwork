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

        private int idx = 0;

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

            foreach (var learnCase in LearnSet)
            {
                var networkAnsw = NeuralNetwork.Run(learnCase.Arguments).First();

                var learnCaseAnsw = learnCase.Answer;

                var outNeuron = NeuralNetwork.OutputLayer.Neurons.First();

                ((DeepNeuron)outNeuron).Error = networkAnsw - learnCaseAnsw;

                BackProtIteratively(NeuralNetwork.OutputLayer);

                if (idx % 111111 == 0)
                {
                    Console.WriteLine($"network answer => {outNeuron.Value}");
                    Console.WriteLine($"learnCase answer => {learnCase.Answer}");
                    Console.WriteLine($"mistake => {learnCase.Answer - outNeuron.Value}\n");
                }
                ++idx;
            }

            void BackProtIteratively(ILayer currentLayer)
            {
                if (currentLayer is IDeepLayer deepLayer)
                {
                    foreach (IDeepNeuron deepNeuron in deepLayer.Neurons)
                    {
                        var delta = deepNeuron.Error * deepNeuron.LayerOfTheNeuron.DerivativeOfActivationFunction(deepNeuron.ValueBeforeActivation);

                        foreach (var connection in deepNeuron.Connections)
                        {
                            if (connection.Neuron is IDeepNeuron prevDeepNeuron)
                            {
                                prevDeepNeuron.Error = connection.Weight * delta;
                            }
                            else return;
                        }
                    }

                    foreach (IDeepNeuron deepNeuron in deepLayer.Neurons)
                    {
                        var delta = deepNeuron.Error * deepNeuron.LayerOfTheNeuron.DerivativeOfActivationFunction(deepNeuron.ValueBeforeActivation);

                        double learnRate2 = deepLayer.Neurons.Sum(x => Math.Pow(((IDeepNeuron)x).Error, 2) *
                                            deepLayer.DerivativeOfActivationFunction(x.ValueBeforeActivation)) /
                                            (deepLayer.DerivativeOfActivationFunction(0) *
                                            (1 + deepLayer.Neurons.Sum(x => Math.Pow(((IDeepNeuron)x).Error, 2) *
                                             Math.Pow(deepLayer.DerivativeOfActivationFunction(x.ValueBeforeActivation), 2))));

                        foreach (var connection in deepNeuron.Connections)
                        {
                            connection.Weight -= learnRate * connection.Neuron.Value * delta;

                            if (connection.Neuron is IDeepNeuron prevDeepNeuron)
                            {
                                prevDeepNeuron.Error = connection.Weight * delta;
                            }
                        }
                        deepNeuron.Threshold += learnRate * deepNeuron.Error * deepNeuron.LayerOfTheNeuron.DerivativeOfActivationFunction(deepNeuron.ValueBeforeActivation);
                    }
                }
            }

            void BackProp(INeuron currentNeuron, double currentError)
            {
                if (currentNeuron is DeepNeuron deepNeuron)
                {
                    var delta = currentError * deepNeuron.LayerOfTheNeuron.DerivativeOfActivationFunction(deepNeuron.ValueBeforeActivation);

                    foreach (var connection in deepNeuron.Connections)
                    {
                        connection.Weight -= learnRate * connection.Neuron.Value * delta;

                        var newError = connection.Weight * delta;
                        BackProp(connection.Neuron, newError);
                    }
                    deepNeuron.Threshold += learnRate * currentError * deepNeuron.LayerOfTheNeuron.DerivativeOfActivationFunction(deepNeuron.ValueBeforeActivation);
                }
            }
        }
    }
}