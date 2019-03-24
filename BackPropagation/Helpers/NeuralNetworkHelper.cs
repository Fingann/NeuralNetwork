using BackPropagation.Helpers.Exporters;
using BackPropagation.Helpers.Loaders;
using BackPropagation.Networks;

namespace BackPropagation.Helpers
{
    public class NeuralNetworkHelper : IHelper<NeuralNetwork>
    {
        public NeuralNetworkHelper()
        {
            Importer = new NeuralNetworkLoader();
            Exporter =new NeuralNetworkExporter();
        }

        public ILoader<NeuralNetwork> Importer { get; set; }
        public IExporter<NeuralNetwork> Exporter { get; set; }
    }
}