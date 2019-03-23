using System;
using BackPropagation.ActivationFunctions;
using BackPropagation.ActivationFunctions.Delegates;
using BackPropagation.Helpers;

namespace BackPropagation.Abstractions
{
    public abstract class NeuronBase
    {
        
        protected NeuronBase(ActivationType activationType): this(Guid.NewGuid(),(float)Util.GetRandom(), 0,0,0, activationType )
        {
        }
        
        protected NeuronBase(Guid id, float bias, float biasDelta, float gradient, float value, ActivationType activationType)
        {
            Id = id;
            Bias = bias;
            BiasDelta = biasDelta;
            Gradient = gradient;
            Value = value;
            ActivationType = activationType;
            ActivationFunc = ActivationFunctionProvider.GetActivations(activationType);
        }

        
        
        public Guid Id { get; set; }
        public float Bias { get; set; }
        public float BiasDelta { get; set; }
        public float Gradient { get; set; }
        public float Value { get; set; }
	
        public ActivationType ActivationType { get; }
        protected readonly (ActivationFunction Activation, ActivationFunction ActivationPrime) ActivationFunc;
    }
}