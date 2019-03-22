namespace BackPropagation.NetworkModels
{
	public class DataPoint
	{
		public double[] Values { get; }
		public double[] Targets { get; }
		
		public DataPoint(double[] values, double[] targets)
		{
			Values = values;
			Targets = targets;
		}
	}
}