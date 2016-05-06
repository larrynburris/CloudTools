namespace CloudTools.Domain.CQRS.Queries
{
    /// <summary>
    /// Represents a generic query handler in a CQRS environment
    /// </summary>
    /// <typeparam name="TQuery">A contravariant query type</typeparam>
    /// <typeparam name="TResult">A covariant query result type</typeparam>
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}
