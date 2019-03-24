namespace BackPropagation.Helpers.Loaders
{
    public interface ILoader<T>
    {
         T  Load(string path);
    }
}