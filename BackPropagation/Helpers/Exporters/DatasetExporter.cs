using System.Collections.Generic;
using System.IO;
using BackPropagation.Networks.Models;
using Newtonsoft.Json;

namespace BackPropagation.Helpers.Exporters
{
    public class DatasetExporter: IExporter<IEnumerable<DataPoint>>
    {
        public void Export(IEnumerable<DataPoint> entety, string path)
        {
            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer {Formatting = Formatting.Indented};
                serializer.Serialize(file, entety);
            }
        }
    }
}