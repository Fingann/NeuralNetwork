using System;
using System.Dynamic;

namespace BackPropagation.Helpers
{
    public static class Util
    {
        private static readonly Random Random = new Random();
        
        public static double GetRandom()
        {
            return 2 * Random.NextDouble() - 1;
        }
    }
}