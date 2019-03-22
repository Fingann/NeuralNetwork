using System.Collections.Generic;
using System.IO;
using BackPropagation.NetworkModels;
using Newtonsoft.Json;

namespace BackPropagation.Helpers
{
	public static class ExportHelper
	{
		public static void ExportNetwork(NeuralNetwork neuralNetwork)
		{
			var dn = GetHelperNetwork(neuralNetwork);

			
			
				using (var file = File.CreateText("NetworkExported.json"))
				{
					var serializer = new JsonSerializer { Formatting = Formatting.Indented };
					serializer.Serialize(file, dn);
				}
			
		}

		public static void ExportDatasets(List<DataPoint> datasets)
		{
				using (var file = File.CreateText("OUTPUT.TXT"))
				{
					var serializer = new JsonSerializer { Formatting = Formatting.Indented };
					serializer.Serialize(file, datasets);
				}
			
		}

		private static HelperNetworkBase GetHelperNetwork(NeuralNetwork neuralNetwork)
		{
			var hn = new HelperNetworkBase
			{
				LearnRate = neuralNetwork.LearnRate,
				Momentum = neuralNetwork.Momentum
			};

			//Input Layer
			foreach (var n in neuralNetwork.InputLayer)
			{
				var neuron = new HelperNeuron(n.Id, n.Bias, n.BiasDelta, n.Gradient, n.Value, n.ActivationType);
				
				hn.InputLayer.Add(neuron);

				foreach (var synapse in n.OutputSynapses)
				{
					var syn = new HelperSynapse
					{
						Id = synapse.Id,
						OutputNeuronId = synapse.OutputNeuron.Id,
						InputNeuronId = synapse.InputNeuron.Id,
						Weight = synapse.Weight,
						WeightDelta = synapse.WeightDelta
					};

					hn.Synapses.Add(syn);
				}
			}

			//Hidden Layer
			foreach (var l in neuralNetwork.HiddenLayers)
			{
				var layer = new List<HelperNeuron>();

				foreach (var n in l)
				{
					var neuron = new HelperNeuron(n.Id, n.Bias, n.BiasDelta, n.Gradient, n.Value, n.ActivationType);


					layer.Add(neuron);

					foreach (var synapse in n.OutputSynapses)
					{
						var syn = new HelperSynapse
						{
							Id = synapse.Id,
							OutputNeuronId = synapse.OutputNeuron.Id,
							InputNeuronId = synapse.InputNeuron.Id,
							Weight = synapse.Weight,
							WeightDelta = synapse.WeightDelta
						};

						hn.Synapses.Add(syn);
					}
				}

				hn.HiddenLayers.Add(layer);
			}

			//Output Layer
			foreach (var n in neuralNetwork.OutputLayer)
			{
				var neuron = new HelperNeuron(n.Id, n.Bias, n.BiasDelta, n.Gradient, n.Value, n.ActivationType);


				hn.OutputLayer.Add(neuron);

				foreach (var synapse in n.OutputSynapses)
				{
					var syn = new HelperSynapse
					{
						Id = synapse.Id,
						OutputNeuronId = synapse.OutputNeuron.Id,
						InputNeuronId = synapse.InputNeuron.Id,
						Weight = synapse.Weight,
						WeightDelta = synapse.WeightDelta
					};

					hn.Synapses.Add(syn);
				}
			}

			return hn;
		}
	}
}