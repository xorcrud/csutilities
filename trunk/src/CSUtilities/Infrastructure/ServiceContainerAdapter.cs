using Microsoft.Commerce.Common.ObjectBuilder;

namespace CSUtilities.Infrastructure
{
    public class ServiceContainerAdapter : IServiceContainer
    {
        public T GetService<T>() where T : class
        {
            return ServiceContainer.Instance.GetService<T>();
        }

        public bool HasService<T>()
        {
            return ServiceContainer.Instance.HasService<T>();
        }
    }
}