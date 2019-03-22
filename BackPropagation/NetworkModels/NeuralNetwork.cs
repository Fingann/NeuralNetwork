using System;
using System.Collections.Generic;
using System.Linq;
using BackPropagation.Abstractions;

namespace BackPropagation.NetworkModels
{
	public class NeuralNetwork : Network<Neuron>
	{
		
		
		
		public NeuralNetwork()
		{
			LearnRate = 0;
			Momentum = 0;
			InputLayer = new List<Neuron>();
			HiddenLayers = new List<List<Neuron>>();
			OutputLayer = new List<Neuron>();
		}

		public NeuralNetwork(int inputSize, int[] hiddenSizes, int outputSize, double learnRate = .4, double momentum = .9)
		{
			LearnRate = learnRate;
			Momentum = momentum;
			InputLayer = new List<Neuron>();
			HiddenLayers = new List<List<Neuron>>();
			OutputLayer = new List<Neuron>();

			//create input layer
			for (var i = 0; i < inputSize; i++)
				InputLayer.Add(new Neuron());

			
			var firstHiddenLayer = new List<Neuron>();
			for (var i = 0; i < hiddenSizes[0]; i++)
				firstHiddenLayer.Add(new Neuron(InputLayer));

			HiddenLayers.Add(firstHiddenLayer);

			
			for (var i = 1; i < hiddenSizes.Length; i++)
			{
				var hiddenLayer = new List<Neuron>();
				for (var j = 0; j < hiddenSizes[i]; j++)
					hiddenLayer.Add(new Neuron(HiddenLayers[i - 1]));
				HiddenLayers.Add(hiddenLayer);
			}

			for (var i = 0; i < outputSize; i++)
				OutputLayer.Add(new Neuron(HiddenLayers.Last()));
		}

		public void Train(List<DataPoint> dataSets, int numEpochs)
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

		public void Train(List<DataPoint> dataSets, double minimumError)
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
				numEpochs++;
			}
		}

		private void ForwardPropagate(params double[] inputs)
		{
			var i = 0;
			InputLayer.ForEach(a => a.Value = inputs[i++]);
			HiddenLayers.ForEach(a => a.ForEach(b => b.CalculateValue()));
			OutputLayer.ForEach(a => a.CalculateValue());
		}

		private void BackPropagate(params double[] targets)
		{
			var i = 0;
			OutputLayer.ForEach(a => a.CalculateGradient(targets[i++]));
			HiddenLayers.Reverse();
			HiddenLayers.ForEach(a => a.ForEach(b => b.CalculateGradient()));
			HiddenLayers.ForEach(a => a.ForEach(b => b.UpdateWeights(LearnRate, Momentum)));
			HiddenLayers.Reverse();
			OutputLayer.ForEach(a => a.UpdateWeights(LearnRate, Momentum));
		}

		public double[] Compute(params double[] inputs)
		{
			ForwardPropagate(inputs);
			return OutputLayer.Select(a => a.Value).ToArray();
		}

		private double CalculateError(params double[] targets)
		{
			var i = 0;
			return OutputLayer.Sum(a => Math.Abs(a.CalculateError(targets[i++])));
		}

		
	}

	
}