using System.Collections.Generic;
using BackPropagation.Helpers.Exporters;
using BackPropagation.Helpers.Loaders;
using BackPropagation.Networks.Models;

namespace BackPropagation.Helpers
{
    public class DataSetHelper : IHelper<IEnumerable<DataPoint>>
    {
        public DataSetHelper()
        {
            Importer = new DataSetLoader();
            Exporter = new DatasetExporter();
        }
        public ILoader<IEnumerable<DataPoint>> Importer { get; set; }
        public IExporter<IEnumerable<DataPoint>> Exporter { get; set; }
    }
}