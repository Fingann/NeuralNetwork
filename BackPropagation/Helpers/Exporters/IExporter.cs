namespace BackPropagation.Helpers.Exporters
{
    public interface IExporter<T>
    {
        void Export(T entety, string path);
    }
}