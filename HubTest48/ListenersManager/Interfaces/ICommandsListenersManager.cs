namespace HubTest48.Behaviors
{
    public interface ICommandsListenersManager : IListenersManagerBase
    {
        void StartBot();
        void StopBot();
    }
}