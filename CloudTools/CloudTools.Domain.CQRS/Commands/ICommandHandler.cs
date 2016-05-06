namespace CloudTools.Domain.CQRS.Commands
{
    /// <summary>
    /// Represents a generic command handler in a CQRS environment where the command parameter is contravariant
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
