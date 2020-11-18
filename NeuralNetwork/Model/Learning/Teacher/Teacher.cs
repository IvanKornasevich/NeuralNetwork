using NeuralNetwork.Model;
using NeuralNetwork.Model.Layer;
using NeuralNetwork.Model.Learning.LearnCase;
using NeuralNetwork.Model.Learning.Teacher;
using NeuralNetwork.Model.Neuron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NeuralNetwork
{
    internal class Teacher : ITeacher
    {
        internal IList<ILearnCase> LearnSet { get; private set; }

        private INeuralNetwork NeuralNetwork { get; set; }

        private int counter = 0;

        public Teacher(INeuralNetwork neuralNetwork)
        {
            NeuralNetwork = neuralNetwork;
        }

        public Teacher(INeuralNetwork neuralNetwork, IEnumerable<ILearnCase> learnSet)
        {
            NeuralNetwork = neuralNetwork;
            LearnSet = new List<ILearnCase>(learnSet);
        }

        public void CreateLearnSet(double start, double step, Func<double, double> func, int count = 10000)
        {
            LearnSet = new List<ILearnCase>();
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
                LearnSet.Add(new LearnCase(caseArgs, new List<double> { dataSet[i + j] }));
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

                BackProp(outNeuron, networkAnsw - learnCaseAnsw[0], learnRate);

                if (counter % 11111 == 0)
                {
                    Console.WriteLine($"network answer => {outNeuron.Value}");
                    Console.WriteLine($"learnCase answer => {learnCase.Answer[0]}");
                    Console.WriteLine($"mistake => {learnCase.Answer[0] - outNeuron.Value}\n");
                }
                ++counter;
            }
        }

        private void BackProp(INeuron currentNeuron, double currentError, double learnRate)
        {
            if (currentNeuron is DeepNeuron deepNeuron)
            {
                var delta = currentError * deepNeuron.DerivativeOfActivFunc(deepNeuron.ValueBeforeActivation);

                foreach (var connection in deepNeuron.Connections)
                {
                    connection.Weight -= learnRate * connection.Neuron.Value * delta;

                    var newError = connection.Weight * delta;
                    BackProp(connection.Neuron, newError, learnRate);
                }
                deepNeuron.Threshold += learnRate * currentError * deepNeuron.DerivativeOfActivFunc(deepNeuron.ValueBeforeActivation);
            }
        }

        public void Learn()
        {
            if (LearnSet == null)
                throw new NullReferenceException($"There is no {nameof(LearnSet)} for the {nameof(NeuralNetwork)}");

            foreach (var learnCase in LearnSet)
            {
                BackPropAdaptive(learnCase);

                var outNeuron = NeuralNetwork.OutputLayer.Neurons.First();
                if (counter % 11111 == 0)
                {
                    Console.WriteLine($"network answer => {outNeuron.Value}");
                    Console.WriteLine($"learnCase answer => {learnCase.Answer[0]}");
                    Console.WriteLine($"mistake => {learnCase.Answer[0] - outNeuron.Value}\n");
                }
                ++counter;
            }
        }

        private void BackPropAdaptive(ILearnCase learnCase)
        {
            NeuralNetwork.Run(learnCase.Arguments).First();

            CalculateErrors();

            for (int i = NeuralNetwork.Layers.Count - 1; i > 0; --i)
            {
                var layer = NeuralNetwork[i];

                var learnRate = getLearnRateForLayer(layer);

                foreach (var neuron in layer)
                {
                    var delta = neuron.Error * neuron.DerivativeOfActivFunc(neuron.ValueBeforeActivation);

                    foreach (var con in neuron.Connections)
                    {
                        con.Weight -= learnRate * con.Neuron.Value * delta;
                    }

                    neuron.Threshold += learnRate * neuron.Error * neuron.DerivativeOfActivFunc(neuron.ValueBeforeActivation);
                }
            }

            void CalculateErrors()
            {
                var outLayer = NeuralNetwork.OutputLayer;
                for (var i = 0; i < learnCase.Answer.Count; ++i)
                {
                    outLayer[i].Error = outLayer[i].Value - learnCase.Answer[i];
                    CalculateErrorForCurrentNeuron(outLayer[i]);
                }

                void CalculateErrorForCurrentNeuron(INeuron neuron)
                {
                    foreach (var connection in neuron.Connections)
                    {
                        var newNeuron = connection.Neuron;
                        newNeuron.Error += connection.Weight * neuron.Error * neuron.DerivativeOfActivFunc(neuron.ValueBeforeActivation);
                        CalculateErrorForCurrentNeuron(newNeuron);
                    }
                }
            }

            static double getLearnRateForLayer(ILayer layer)
            {
                var numerator = layer.Sum(x => Math.Pow(x.Error, 2) + x.DerivativeOfActivFunc(x.ValueBeforeActivation));

                var denominator = layer[0].DerivativeOfActivFunc(0) *
                    (1 + layer.Sum(x => Math.Pow(x.Error, 2) + Math.Pow(x.DerivativeOfActivFunc(x.ValueBeforeActivation), 2)));

                var result = numerator / denominator;

                if (Math.Abs(result) > 0.2)
                {
                    if (result > 0)
                    {
                        return 0.2;
                    }
                    else
                    {
                        return -0.2;
                    }
                }
                else
                {
                    return numerator / denominator;
                }
            }
        }
    }
}