using System;

namespace CleanArchitectureExample.Application.Persistence
{
    public static class QuerableExtensionsFactory
    {
        public static IQueryableExtensions QueryableExtensions { get; private set; }

        public static void InitFactory(IQueryableExtensions queryableExtensions)
        {
            if (QueryableExtensions != null)
            {
                throw new Exception($"Attempted to initialise {nameof(QuerableExtensionsFactory)} multiple times");
            }

            QueryableExtensions = queryableExtensions ?? throw new ArgumentNullException(nameof(queryableExtensions));
        }
    }
}
