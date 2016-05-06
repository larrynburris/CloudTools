namespace CloudTools.Domain.CQRS.Queries
{
    /// <summary>
    /// Represents a generic query dispatcher in a CQRS environment
    /// </summary>
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
