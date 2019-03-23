using System.Collections.Generic;
using System.IO;
using BackPropagation.Networks;
using Newtonsoft.Json;

namespace BackPropagation.Helpers.Exporters
{
     class NeuralNetworkExporter : IExporter<NeuralNetwork>
    {
        public void Export(NeuralNetwork entety, string path)
        {
            var dn = GetHelperNetwork(entety);
            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer {Formatting = Formatting.Indented};
                serializer.Serialize(file, dn);
            }
        }


        private HelperNetwork GetHelperNetwork(NeuralNetwork neuralNetwork)
            {
                var hn = new HelperNetwork
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
                        var syn = new HelperSynapse(synapse.Id, synapse.Weight, synapse.WeightDelta,
                            synapse.OutputNeuron.Id, synapse.InputNeuron.Id);

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
                            var syn = new HelperSynapse(synapse.Id, synapse.Weight, synapse.WeightDelta,
                                synapse.OutputNeuron.Id, synapse.InputNeuron.Id);


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
                        var syn = new HelperSynapse(synapse.Id, synapse.Weight, synapse.WeightDelta,
                            synapse.OutputNeuron.Id, synapse.InputNeuron.Id);

                        hn.Synapses.Add(syn);
                    }
                }

                return hn;
            }
        }
    }
