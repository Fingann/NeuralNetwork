using System.Collections.Generic;
using System.IO;
using BackPropagation.Networks.Models;
using Newtonsoft.Json;

namespace BackPropagation.Helpers.Loaders
{
    public class DataSetLoader : ILoader<IReadOnlyList<DataPoint>>
    {
        public IReadOnlyList<DataPoint> Load(string path)
        {
                var text = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<IReadOnlyList<DataPoint>>(text);
        }
    }
}