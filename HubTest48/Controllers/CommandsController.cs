using HubTest48.Behaviors;
using HubTest48.Managers;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace HubTest48.Controllers
{

    internal class CommandsController : ControllerBase<ICommandsListenersManager, ICommandsServerManager>, ICommandsController
    {

        public CommandsController(
            IConfiguration configuration, 
            ICommandsListenersManager commandsBehavior, 
            ICommandsServerManager commandsManager) : base(configuration[""], commandsBehavior, commandsManager)
        {
            HubConnection.On("StartBot", LisManager.StartBot);
            HubConnection.On("StopBot", LisManager.StopBot);
        }

        public Task SendInfoToApp()
        {
            return SerManager.SendInfoToApp();
        }
    }
}
