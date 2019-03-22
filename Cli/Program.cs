using System;
using BackPropagation.Helpers;
using BackPropagation.NetworkModels;

namespace Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainingData = ImportHelper.ImportDatasets(
                "/Users/fingann/Documents/GitHub/NeuralNetwork/NeuralNetwork/BackPropagation/DataExamples/Datasets/RockPaperScissor_Dataset.json");

            var network = new NeuralNetwork(6, new []{10}, 2);
            
            network.Train(trainingData, 0.5);
            
            while (true)
            { 
                Console.WriteLine("Input test values: ");
                var input =  Console.ReadLine();
                var inputs = input.Split(' ');
                double[] inputDouble = new double[6];
                for (int i = 0; i < inputs.Length; i++)
                {
                    inputDouble[i] = int.Parse(inputs[i]);
                }

                var output = network.Compute(inputDouble);
                foreach (var e in output)
                {
                    Console.WriteLine(e);
                }
            }        }
    }
}