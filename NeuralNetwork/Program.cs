namespace NeuralNetwork
{
    internal class Program
    {
        public static void Main()
        {
            var network = new NeuralNetwork(2, 2);
            System.Console.WriteLine(network.Run(-10, 3));
        }
    }
}