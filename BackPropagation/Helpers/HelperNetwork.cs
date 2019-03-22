using System;
using System.Collections.Generic;
using System.Xml;
using BackPropagation.Abstractions;
using BackPropagation.ActivationFunctions;
using BackPropagation.ActivationFunctions.Delegates;

namespace BackPropagation.Helpers
{
	internal class HelperNetworkBase: NetworkBase<HelperNeuron>
	{
		
		public List<HelperSynapse> Synapses { get; set; }

		public HelperNetworkBase() 
		{
			
			Synapses = new List<HelperSynapse>();
		}
	}

	public class HelperNeuron : NeuronBase
	{
		public HelperNeuron(Guid id, float bias, float biasDelta, float gradient, float value, ActivationType type): base(id,bias,biasDelta,gradient,value,type)
		{
		}
	}

	public class HelperSynapse:SynapseBase
	{
		public Guid OutputNeuronId { get; set; }
		public Guid InputNeuronId { get; set; }
	
	}
}
