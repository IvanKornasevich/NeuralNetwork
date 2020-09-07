namespace NeuralNetwork
{
    internal class InputNeuron : Neuron
    {
        internal override void Calculate()
        {
            Value = Sigmoid(Value);
        }

        internal void SetValue(double val)
        {
            Value = val;
        }
    }
}