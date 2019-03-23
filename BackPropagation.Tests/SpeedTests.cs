using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BackPropagation.ActivationFunctions;
using BackPropagation.Helpers;
using BackPropagation.Networks;
using Xunit;

namespace BackPropagation.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            
            var trainingData = new NeuralNetworkHelper();
            trainingData.Importer.;

            var network = new NeuralNetwork(6, new []{10,10,10}, 2);
            Stopwatch sw = new Stopwatch();
            List<TimeSpan> times = new List<TimeSpan>();
            for (int i = 0; i < 10; i++)
            {
                sw.Start();
                network.Train(trainingData, 10000);
                sw.Stop();
                times.Add(sw.Elapsed);
                sw.Reset();
            }
            var timeElapsed = times.Aggregate((a,b) => a.Add(b)).Divide(times.Count);
            Console.WriteLine(sw.Elapsed);
        }

    }
}