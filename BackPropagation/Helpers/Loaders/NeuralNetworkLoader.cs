using System.Collections.Generic;
using System.IO;
using System.Linq;
using BackPropagation.Networks;
using BackPropagation.Networks.Models;
using Newtonsoft.Json;

namespace BackPropagation.Helpers.Loaders
{
    class NeuralNetworkLoader : ILoader<NeuralNetwork>
    {
        public  NeuralNetwork Load(string path)
        {
            var dn = GetHelperNetwork(path);
            if (dn == null) return null;

            var network = new NeuralNetwork();
            var allNeurons = new List<Neuron>();

            network.LearnRate = dn.LearnRate;
            network.Momentum = dn.Momentum;

            //Input Layer
            foreach (var n in dn.InputLayer)
            {
                var neuron = new Neuron(n.Id, n.Bias,n.BiasDelta,n.Gradient,n.Value, n.ActivationType);
				
                network.InputLayer.Add(neuron);
                allNeurons.Add(neuron);
            }

            //Hidden Layers
            foreach (var layer in dn.HiddenLayers)
            {
                var neurons = new List<Neuron>();
                foreach (var n in layer)
                {
                    var neuron = new Neuron(n.Id, n.Bias,n.BiasDelta,n.Gradient,n.Value, n.ActivationType);
                    neurons.Add(neuron);
                    allNeurons.Add(neuron);
                }

                network.HiddenLayers.Add(neurons);
            }

            //Export Layer
            foreach (var n in dn.OutputLayer)
            {
                var neuron = new Neuron(n.Id, n.Bias, n.BiasDelta, n.Gradient, n.Value, n.ActivationType);
                network.OutputLayer.Add(neuron);
                allNeurons.Add(neuron);
            }

            //Synapses
            foreach (var syn in dn.Synapses)
            {
                var inputNeuron = allNeurons.First(x => x.Id == syn.InputNeuronId);
                var outputNeuron = allNeurons.First(x => x.Id == syn.OutputNeuronId);
				
                var synapse = new Synapse(syn.Id, syn.Weight,syn.WeightDelta,inputNeuron,outputNeuron);
				
                inputNeuron.OutputSynapses.Add(synapse);
                outputNeuron.InputSynapses.Add(synapse);
            }

            return network;
        }
        
        private static HelperNetwork GetHelperNetwork(string path)
        {
            var text = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<HelperNetwork>(text);
        }
    }
}