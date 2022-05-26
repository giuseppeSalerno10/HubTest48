using HubTest48.Behaviors;
using HubTest48.Managers;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace HubTest48.Controllers
{

    internal abstract class ControllerBase<ListenersManager, ServerManager> : IControllerBase 
        where ListenersManager : IListenersManagerBase
        where ServerManager : IServerManagerBase
    {
        protected ListenersManager LisManager { get; }
        protected ServerManager SerManager { get; }


        protected HubConnection HubConnection { get; set; }


        public ControllerBase(string url, ListenersManager behavior, ServerManager manager)
        {
            LisManager = behavior;
            SerManager = manager;

            HubConnection = new HubConnectionBuilder()
                   .WithUrl(url, option =>
                   {
                       //option.AccessTokenProvider = () => GenerateToken();
                   })
                   .WithAutomaticReconnect()
                   .Build();

            HubConnection.On("HandleErrorAsync", LisManager.HandleErrorAsync);

            SerManager.Setup(HubConnection);
        }

        public Task InitializeConnection()
        {
            return SerManager.InitializeConnection();
        }
        public Task CloseConnection()
        {
            return SerManager.CloseConnection();
        }

    }
}
