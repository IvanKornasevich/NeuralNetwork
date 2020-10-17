using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork.Model.Learning.Teacher
{
    internal interface ITeacher
    {
        void CreateLearnSet(double start, double step, Func<double, double> func, int count = 10000);

        void Learn(double learnRate);

        void Learn();
    }
}