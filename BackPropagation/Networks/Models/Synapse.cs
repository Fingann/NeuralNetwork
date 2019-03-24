using System;
using BackPropagation.Abstractions;

namespace BackPropagation.Networks.Models
{
	public class Synapse: SynapseBase
	{
		public Neuron InputNeuron { get; set; }
		public Neuron OutputNeuron { get; set; }

		public Synapse(Neuron inputNeuron, Neuron outputNeuron)
		{
			InputNeuron = inputNeuron;
			OutputNeuron = outputNeuron;
		}

		public Synapse(Guid id, float weight, float weightDelta,Neuron inputNeuron, Neuron outputNeuron): base(id,weight,weightDelta)
		{
			InputNeuron = inputNeuron;
			OutputNeuron = outputNeuron;
		}
	}
}