namespace CloudTools.Domain.CQRS.Queries
{
    /// <summary>
    /// Represents a query with generic result in a CQRS environment
    /// <para>Query results types are verified at compile time when they are defined in the query.</para>
    /// </summary>
    /// <typeparam name="TResult">Query result type</typeparam>
    public interface IQuery<TResult>
    {
    }
}
