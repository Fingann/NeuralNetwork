using System.Collections.Generic;
using System.IO;
using BackPropagation.Networks.Models;
using Newtonsoft.Json;

namespace BackPropagation.Helpers.Loaders
{
    public class DataSetLoader : ILoader<IEnumerable<DataPoint>>
    {
        public IEnumerable<DataPoint> Load(string path)
        {
                var text = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<IEnumerable<DataPoint>>(text);
        }
    }
}