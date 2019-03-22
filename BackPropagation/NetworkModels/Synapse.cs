using System;
using BackPropagation.Helpers;

namespace BackPropagation.NetworkModels
{
	public class Synapse
	{
		public Guid Id { get; set; }
		public Neuron InputNeuron { get; set; }
		public Neuron OutputNeuron { get; set; }
		public double Weight { get; set; }
		public double WeightDelta { get; set; }

		public Synapse()
		{
			Id = Guid.NewGuid();
			Weight = Util.GetRandom();
		}

		public Synapse(Neuron inputNeuron, Neuron outputNeuron) : this()
		{
			InputNeuron = inputNeuron;
			OutputNeuron = outputNeuron;
		}
	}
}