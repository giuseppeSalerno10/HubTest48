using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubTest48.Managers
{
    public class ServerManagerBase : IServerManagerBase
    {
        private HubConnection _hubConnection;
        public void Setup(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }

        public async Task InitializeConnection()
        {
            await _hubConnection.StartAsync();
            await _hubConnection.SendAsync("InitializeConnection");
        }
        public async Task CloseConnection()
        {
            await _hubConnection.SendAsync("CloseConnection");
            await _hubConnection.StopAsync();
        }
    }
}
