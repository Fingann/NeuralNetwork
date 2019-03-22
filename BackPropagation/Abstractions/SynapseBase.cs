using System;

namespace BackPropagation.Abstractions
{
    public abstract class SynapseBase
    {
        public Guid Id { get; set; }
        public float Weight { get; set; }
        public float WeightDelta { get; set; }
    }
}