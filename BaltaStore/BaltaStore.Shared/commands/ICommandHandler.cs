namespace BaltaStore.Shared.commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
        ICommandResult Handler(T command);
    }
}