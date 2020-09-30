using BackPropagation.Helpers;
using System;

namespace BackPropagation.Abstractions
{
    public abstract class SynapseBase
    {
        public Guid Id { get; set; }
        public float Weight { get; set; }
        public float WeightDelta { get; set; }

        protected SynapseBase() : this(Guid.NewGuid(), (float)Util.GetRandom(), 0)
        {
        }

        protected SynapseBase(Guid id, float weight, float weightDelta)
        {
            Id = id;
            Weight = weight;
            WeightDelta = weightDelta;
        }
    }
}