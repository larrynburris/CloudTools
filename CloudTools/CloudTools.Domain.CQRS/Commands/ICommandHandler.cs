namespace CloudTools.Domain.CQRS.Commands
{
    /// <summary>
    /// Represents a generic command handler in a CQRS environment
    /// </summary>
    /// <typeparam name="TCommand">A contravariant command type</typeparam>
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
