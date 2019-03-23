using BackPropagation.Helpers.Exporters;
using BackPropagation.Helpers.Loaders;

namespace BackPropagation.Helpers
{
     interface IHelper<T>
    {
         ILoader<T> Importer { get; set; } 
         IExporter<T> Exporter { get; set; }

    }
}