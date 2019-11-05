namespace CleanArchitectureExample.Application.CQRS
{
    public interface IQuery
    {

    }

    public interface IQuery<TOutput> : IQuery
    {

    }
}
