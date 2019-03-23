using System;
using System.Collections.Generic;
using System.Xml;
using BackPropagation.Abstractions;
using BackPropagation.ActivationFunctions;
using BackPropagation.ActivationFunctions.Delegates;

namespace BackPropagation.Helpers
{
	internal class HelperNetwork: NetworkBase<HelperNeuron>
	{
		public List<HelperSynapse> Synapses { get; set; }

		public HelperNetwork() 
		{
			Synapses = new List<HelperSynapse>();
		}
	}

	internal class HelperNeuron : NeuronBase
	{
		public HelperNeuron(Guid id, float bias, float biasDelta, float gradient, float value, ActivationType type): base(id,bias,biasDelta,gradient,value,type)
		{
		}
	}

	internal class HelperSynapse:SynapseBase
	{
		public Guid OutputNeuronId { get; set; }
		public Guid InputNeuronId { get; set; }
	
		public HelperSynapse(Guid id, float weight, float weightDelta,Guid outputNeuronId, Guid inputNeuronId): base(id,weight,weightDelta)
		{
			OutputNeuronId = outputNeuronId;
			InputNeuronId = inputNeuronId;
		}
	}
}
