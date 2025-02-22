namespace WPM.Management.API.Application
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}
