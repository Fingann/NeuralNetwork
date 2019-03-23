using System;
using System.Collections.Generic;
using System.Linq;
using BackPropagation.Abstractions;
using BackPropagation.ActivationFunctions;

namespace BackPropagation.Networks.Models
{
	public class Neuron : NeuronBase
	{
		
		public List<Synapse> InputSynapses { get; set; }
		public List<Synapse> OutputSynapses { get; set; }
		
		public Neuron(ActivationType activationType): base(activationType)
		{
			InputSynapses = new List<Synapse>();
			OutputSynapses = new List<Synapse>();
		}
		
		public Neuron(IEnumerable<Neuron> inputNeurons, ActivationType activationType) : this(activationType)
		{
			foreach (var inputNeuron in inputNeurons)
			{
				var synapse = new Synapse(inputNeuron, this);
				inputNeuron.OutputSynapses.Add(synapse);
				InputSynapses.Add(synapse);
			}
		}
		
		public Neuron(Guid id, float bias, float biasDelta, float gradient, float value, ActivationType activation): base(id, bias,biasDelta,gradient,value,activation)
		{
			InputSynapses = new List<Synapse>();
			OutputSynapses = new List<Synapse>();
		}

		

		

		public virtual void CalculateValue()
		{
			Value = ActivationFunc.Activation(InputSynapses.Sum(a => a.Weight * a.InputNeuron.Value) + Bias);
			//return Value = Sigmoid.Output(InputSynapses.Sum(a => a.Weight * a.InputNeuron.Value) + Bias);
		}

		public float CalculateError(float target)
		{
			return target - Value;
		}

		public void CalculateGradient(float? target = null)
		{
			if (target == null)
			{
				Gradient = OutputSynapses.Sum(a => a.OutputNeuron.Gradient * a.Weight) *
				           ActivationFunc.ActivationPrime(Value);
				return;
			}

			Gradient = CalculateError(target.Value) * ActivationFunc.ActivationPrime(Value);
			//return Gradient = CalculateError(target.Value) * Sigmoid.Derivative(Value);
		}

		public void UpdateWeights(float learnRate, float momentum)
		{
			var prevDelta = BiasDelta;
			BiasDelta = learnRate * Gradient;
			Bias += BiasDelta + momentum * prevDelta;

			foreach (var synapse in InputSynapses)
			{
				prevDelta = synapse.WeightDelta;
				synapse.WeightDelta = learnRate * Gradient * synapse.InputNeuron.Value;
				synapse.Weight += synapse.WeightDelta + momentum * prevDelta;
			}
		}
	}
}