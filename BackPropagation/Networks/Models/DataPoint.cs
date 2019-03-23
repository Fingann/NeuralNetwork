namespace BackPropagation.Networks.Models
{
	public class DataPoint
	{
		public float[] Values { get; }
		public float[] Targets { get; }
		
		public DataPoint(float[] values, float[] targets)
		{
			Values = values;
			Targets = targets;
		}
	}
}