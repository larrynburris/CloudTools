namespace CloudTools.Domain.CQRS.Commands
{
    /// <summary>
    /// Represents a generic command dispatcher in a CQRS environment
    /// </summary>
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
