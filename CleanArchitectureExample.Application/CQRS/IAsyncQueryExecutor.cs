using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.CQRS
{
    internal interface IAsyncQueryExecutor<TInput, TOutput>
    {
        Task<TOutput> ExecuteQueryAsync(TInput contract);
    }
}