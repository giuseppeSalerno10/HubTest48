using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version2.Services;

namespace Version2.Handlers
{

    public class CommandsHandler : HandlerBase, ICommandsHandler
    {

        public CommandsHandler(ITokenServices tokenServices, IConfiguration configuration) : base(tokenServices, configuration)
        {
            HubConnection.On("TestAction", TestAction);
        }

        public void TestAction()
        {
            throw new NotImplementedException();
        }
    }
}
