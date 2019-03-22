using System.Collections.Generic;
using BackPropagation.ActivationFunctions;
using BackPropagation.NetworkModels;

namespace BackPropagation.Abstractions
{
    public abstract class NetworkBase<T>
    {
        protected NetworkBase() : this(0,0, ActivationType.Sigmoid)
        {
  
        }

        protected NetworkBase(float learnRate, float momentum, ActivationType activationType): this(learnRate, momentum, new List<T>(), new List<List<T>>(), new List<T>(), activationType)
        {
        }

        protected NetworkBase(float learnRate, float momentum, List<T> inputLayer, List<List<T>> hiddenLayers, List<T> outputLayer, ActivationType activationType)
        {
            LearnRate = learnRate;
            Momentum = momentum;
            InputLayer = inputLayer;
            HiddenLayers = hiddenLayers;
            OutputLayer = outputLayer;
            ActivationActivationType = activationType;
        }
        
        public float LearnRate { get; set; }
        public float Momentum { get; set; }
        public List<T> InputLayer { get; set; }
        public List<List<T>> HiddenLayers { get; set; }
        public List<T> OutputLayer { get; set; }
        public ActivationType ActivationActivationType  { get; set; }
    }
}