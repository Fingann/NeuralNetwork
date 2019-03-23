using System;
using System.Collections.Generic;
using System.Linq;
using BackPropagation.Abstractions;
using BackPropagation.ActivationFunctions;
using BackPropagation.Networks.Models;

namespace BackPropagation.Networks
{
	public class NeuralNetwork : NetworkBase<Neuron>
	{
		public NeuralNetwork()
		{
			
		}

		public NeuralNetwork(int inputSize, int[] hiddenSizes, int outputSize,  float learnRate = 0.4F, float momentum = 0.9F,ActivationType activationType = ActivationType.Sigmoid): base(learnRate, momentum, activationType)
		{
			//create input layer
			for (var i = 0; i < inputSize; i++)
				InputLayer.Add(new Neuron(activationType));

			
			var firstHiddenLayer = new List<Neuron>();
			for (var i = 0; i < hiddenSizes[0]; i++)
				firstHiddenLayer.Add(new Neuron(InputLayer, activationType));

			HiddenLayers.Add(firstHiddenLayer);

			
			for (var i = 1; i < hiddenSizes.Length; i++)
			{
				var hiddenLayer = new List<Neuron>();
				for (var j = 0; j < hiddenSizes[i]; j++)
					hiddenLayer.Add(new Neuron(HiddenLayers[i - 1],activationType));
				HiddenLayers.Add(hiddenLayer);
			}

			for (var i = 0; i < outputSize; i++)
				OutputLayer.Add(new Neuron(HiddenLayers.Last(),activationType));
		}

		public void Train(IReadOnlyList<DataPoint> dataSets, int numEpochs)
		{
			for (var i = 0; i < numEpochs; i++)
			{
				foreach (var dataSet in dataSets)
				{
					ForwardPropagate(dataSet.Values);
					BackPropagate(dataSet.Targets);
				}
			}
		}

		public void Train(IReadOnlyList<DataPoint> dataSets, double minimumError)
		{
			var error = 1.0;
			var numEpochs = 0;

			while (error > minimumError && numEpochs < int.MaxValue)
			{
				var errors = new List<double>();
				foreach (var dataSet in dataSets)
				{
					ForwardPropagate(dataSet.Values);
					BackPropagate(dataSet.Targets);
					errors.Add(CalculateError(dataSet.Targets));
				}
				error = errors.Average();
				Console.WriteLine("Error: " + error);
				numEpochs++;
			}
		}

		private void ForwardPropagate(params float[] inputs)
		{
			var i = 0;
			InputLayer.ForEach(a => a.Value = inputs[i++]);
			HiddenLayers.ForEach(a => a.ForEach(b => b.CalculateValue()));
			OutputLayer.ForEach(a => a.CalculateValue());
		}

		private void BackPropagate(params float[] targets)
		{
			var i = 0;
			OutputLayer.ForEach(a => a.CalculateGradient(targets[i++]));
			HiddenLayers.Reverse();
			HiddenLayers.ForEach(a => a.ForEach(b => b.CalculateGradient()));
			HiddenLayers.ForEach(a => a.ForEach(b => b.UpdateWeights(LearnRate, Momentum)));
			HiddenLayers.Reverse();
			OutputLayer.ForEach(a => a.UpdateWeights(LearnRate, Momentum));
		}

		public float[] Compute(params float[] inputs)
		{
			ForwardPropagate(inputs);
			return OutputLayer.Select(a => a.Value).ToArray();
		}

		private double CalculateError(params float[] targets)
		{
			var i = 0;
			return OutputLayer.Sum(a => Math.Abs(a.CalculateError(targets[i++])));
		}

		
	}

	
}