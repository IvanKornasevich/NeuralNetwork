namespace NeuralNetwork
{
    internal class InputNeuron : Neuron
    {
        internal override void Calculate()
        {
            Value = NeuralNetwork.ActivationFunction(Value);
        }

        internal void SetValue(double val)
        {
            Value = val;
        }
    }
}