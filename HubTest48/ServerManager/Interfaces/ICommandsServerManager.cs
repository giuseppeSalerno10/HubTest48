using System.Threading.Tasks;

namespace HubTest48.Managers
{
    public interface ICommandsServerManager : IServerManagerBase
    {
        Task SendInfoToApp();
    }
}