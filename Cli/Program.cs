using System;
using BackPropagation.Helpers;
using BackPropagation.Networks;

namespace Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var datasetHelper = new DataSetHelper();
            var trainingData = datasetHelper.Importer.Load(
                "..\\..\\..\\..\\BackPropagation\\DataExamples\\Datasets\\RockPaperScissor_Dataset.json");

            var network = new NeuralNetwork(6, new[] {10}, 2, 0.05F, 0.9F);

            Console.WriteLine("Training");
            network.Train(trainingData, 0.05);
            Console.WriteLine("Training Complete");

            var networkHelper = new NeuralNetworkHelper();
            Console.WriteLine("Exporting");
            networkHelper.Exporter.Export(network, "SuperNetwork.json");
            Console.WriteLine("Exporting Complete");

            Console.WriteLine("Importing");
            var net2 = networkHelper.Importer.Load("SuperNetwork.json");
            Console.WriteLine("Importing Complete");


            while (true)
            {
                Console.WriteLine("Input test values: ");
                var input = Console.ReadLine();
                var inputs = input.Split(' ');
                var inputDouble = new float[6];
                for (var i = 0; i < inputs.Length; i++) inputDouble[i] = int.Parse(inputs[i]);

                var output = net2.Compute(inputDouble);
                foreach (var e in output) Console.WriteLine(e);
            }
        }
    }
}