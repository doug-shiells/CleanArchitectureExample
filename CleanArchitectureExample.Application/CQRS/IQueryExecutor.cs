namespace CleanArchitectureExample.Application.CQRS
{
    internal interface IQueryExecutor<TInput, TOutput> 
    {
        TOutput ExecuteQuery(TInput contract);
    }
}