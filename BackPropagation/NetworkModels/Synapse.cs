using System;
using BackPropagation.Abstractions;
using BackPropagation.Helpers;

namespace BackPropagation.NetworkModels
{
	public class Synapse: SynapseBase
	{
		public Neuron InputNeuron { get; set; }
		public Neuron OutputNeuron { get; set; }



		public Synapse()
		{
			InputNeuron = new Neuron();
			OutputNeuron = new Neuron();
		}

		public Synapse(Neuron inputNeuron, Neuron outputNeuron) : this()
		{
			InputNeuron = inputNeuron;
			OutputNeuron = outputNeuron;
		}
	}
}