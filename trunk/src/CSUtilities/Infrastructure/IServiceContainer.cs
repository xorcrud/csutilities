namespace CSUtilities.Infrastructure
{
    public interface IServiceContainer
    {
        T GetService<T>() where T : class;
        bool HasService<T>();
    }
}