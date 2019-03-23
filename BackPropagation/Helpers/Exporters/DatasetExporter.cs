using System.Collections.Generic;
using System.IO;
using BackPropagation.Networks.Models;
using Newtonsoft.Json;

namespace BackPropagation.Helpers.Exporters
{
    public class DatasetExporter: IExporter<IReadOnlyList<DataPoint>>
    {
        public void Export(IReadOnlyList<DataPoint> entety, string path)
        {
            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer {Formatting = Formatting.Indented};
                serializer.Serialize(file, entety);
            }
        }
    }
}