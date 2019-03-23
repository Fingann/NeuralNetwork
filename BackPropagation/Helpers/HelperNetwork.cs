using System;
using System.Collections.Generic;
using BackPropagation.Abstractions;
using BackPropagation.ActivationFunctions;

namespace BackPropagation.Helpers
{
    internal class HelperNetwork : NetworkBase<HelperNeuron>
    {
        public HelperNetwork()
        {
            Synapses = new List<HelperSynapse>();
        }

        public List<HelperSynapse> Synapses { get; set; }
    }

    internal class HelperNeuron : NeuronBase
    {
        public HelperNeuron(Guid id, float bias, float biasDelta, float gradient, float value, ActivationType type) :
            base(id, bias, biasDelta, gradient, value, type)
        {
        }
    }

    internal class HelperSynapse : SynapseBase
    {
        public HelperSynapse(Guid id, float weight, float weightDelta, Guid outputNeuronId, Guid inputNeuronId) : base(
            id, weight, weightDelta)
        {
            OutputNeuronId = outputNeuronId;
            InputNeuronId = inputNeuronId;
        }

        public Guid OutputNeuronId { get; set; }
        public Guid InputNeuronId { get; set; }
    }
}