using System.Collections.Generic;
using BackPropagation.Helpers.Exporters;
using BackPropagation.Helpers.Loaders;
using BackPropagation.Networks.Models;

namespace BackPropagation.Helpers
{
    public class DataSetHelper : IHelper<IReadOnlyList<DataPoint>>
    {
        public DataSetHelper()
        {
            Importer = new DataSetLoader();
            Exporter = new DatasetExporter();
        }
        public ILoader<IReadOnlyList<DataPoint>> Importer { get; set; }
        public IExporter<IReadOnlyList<DataPoint>> Exporter { get; set; }
    }
}