using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace HubTest48.Managers
{
    public interface IServerManagerBase
    {
        Task CloseConnection();
        Task InitializeConnection();
        void Setup(HubConnection hubConnection);
    }
}