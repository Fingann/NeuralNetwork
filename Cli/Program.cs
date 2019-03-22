using System;
using BackPropagation.ActivationFunctions;
using BackPropagation.ActivationFunctions.Delegates;
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

            var network = new NeuralNetwork(6, new []{10}, 2,0.05F,0.9F);

            Console.WriteLine("Training");
            network.Train(trainingData, 0.05);
            Console.WriteLine("Training Complete");

            Console.WriteLine("Exporting");
            ExportHelper.ExportNetwork(network);
            Console.WriteLine("Exporting Complete");
            
            Console.WriteLine("Importing");
            var net2 = ImportHelper.ImportNetwork("NetworkExported.json");
            Console.WriteLine("Importing Complete");
            

            while (true)
            { 
                Console.WriteLine("Input test values: ");
                var input =  Console.ReadLine();
                var inputs = input.Split(' ');
                float[] inputDouble = new float[6];
                for (int i = 0; i < inputs.Length; i++)
                {
                    inputDouble[i] = int.Parse(inputs[i]);
                }

                var output = net2.Compute(inputDouble);
                foreach (var e in output)
                {
                    Console.WriteLine(e);
                }
            }        }
    }
}