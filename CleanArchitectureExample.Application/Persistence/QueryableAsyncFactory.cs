using System;

namespace CleanArchitectureExample.Application.Persistence
{
    public static class QueryableAsyncFactory
    {
        public static IQueryableAsync QueryableAsync { get; private set; }

        public static void InitFactory(IQueryableAsync queryableAsync)
        {
            if (QueryableAsync != null)
            {
                throw new Exception($"Attempted to initialise {nameof(QueryableAsyncFactory)} multiple times");
            }

            QueryableAsync = queryableAsync ?? throw new ArgumentNullException(nameof(queryableAsync));
        }
    }
}
