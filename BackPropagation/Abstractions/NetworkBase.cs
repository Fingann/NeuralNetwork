using System.Collections.Generic;
using BackPropagation.ActivationFunctions;

namespace BackPropagation.Abstractions
{
    public abstract class NetworkBase<T>
    {
        protected NetworkBase() : this(0.05F,0.7F, ActivationType.Sigmoid)
        {
  
        }

        protected NetworkBase(float learnRate, float momentum, ActivationType activationType)
        {
            LearnRate = learnRate;
            Momentum = momentum;
            ActivationActivationType = activationType;
            InputLayer = new List<T>();
            HiddenLayers = new List<List<T>>();
            OutputLayer = new List<T>();

        }
        
        public float LearnRate { get; set; }
        public float Momentum { get; set; }
        public List<T> InputLayer { get; set; }
        public List<List<T>> HiddenLayers { get; set; }
        public List<T> OutputLayer { get; set; }
        public ActivationType ActivationActivationType  { get; set; }
    }
}