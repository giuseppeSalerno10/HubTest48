using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Version2.Connector;
using Version2.Services;

namespace Version2.Connectors
{
    internal class CommandsConnector : ConnectorBase, ICommandsConnector
    {
        public CommandsConnector(ITokenServices tokenServices, IConfiguration configuration) : base(tokenServices, configuration)
        {
        }

        public Task TestMethod()
        {
            return HubConnection.SendAsync("TestMethod");
        }
    }
}
