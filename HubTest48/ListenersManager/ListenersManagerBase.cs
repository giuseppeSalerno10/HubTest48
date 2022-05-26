using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubTest48.Behaviors
{
    public abstract class ListenersManagerBase : IListenersManagerBase
    {
        public void HandleErrorAsync()
        {
            Console.WriteLine("BOT - ERROR");
        }
    }
}
