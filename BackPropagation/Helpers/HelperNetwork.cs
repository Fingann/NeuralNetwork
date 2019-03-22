using System;
using System.Collections.Generic;
using BackPropagation.Abstractions;

namespace BackPropagation.Helpers
{
	internal class HelperNetwork: Network<HelperNeuron>
	{
		
		public List<HelperSynapse> Synapses { get; set; }

		public HelperNetwork()
		{
			InputLayer = new List<HelperNeuron>();
			HiddenLayers = new List<List<HelperNeuron>>();
			OutputLayer = new List<HelperNeuron>();
			Synapses = new List<HelperSynapse>();
		}
	}

	public class HelperNeuron
	{
		public HelperNeuron(Guid id, double bias, double biasDelta, double gradient, double value)
		{
			Id = id;
			Bias = bias;
			BiasDelta = biasDelta;
			Gradient = gradient;
			Value = value;
		}
		public Guid Id { get; set; }
		public double Bias { get; set; }
		public double BiasDelta { get; set; }
		public double Gradient { get; set; }
		public double Value { get; set; }
		
	}

	public class HelperSynapse
	{
		public Guid Id { get; set; }
		public Guid OutputNeuronId { get; set; }
		public Guid InputNeuronId { get; set; }
		public double Weight { get; set; }
		public double WeightDelta { get; set; }
	}
}
