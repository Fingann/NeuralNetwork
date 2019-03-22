using System.Collections.Generic;

namespace BackPropagation.Abstractions
{
    public abstract class Network<T>
    {
        public double LearnRate { get; set; }
        public double Momentum { get; set; }
        public List<T> InputLayer { get; set; }
        public List<List<T>> HiddenLayers { get; set; }
        public List<T> OutputLayer { get; set; }
    }
}