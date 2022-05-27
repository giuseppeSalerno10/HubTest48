using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version2.Services;

namespace Version2.Connector
{

    public abstract class ConnectorBase
    {
        protected HubConnection HubConnection { get; private set; }
        protected ITokenServices _tokenServices;
        protected IConfiguration _configuration;


        public ConnectorBase(ITokenServices tokenServices, IConfiguration configuration)
        {
            _tokenServices = tokenServices;

            var connectorName = GetType()
                .Name;

            var url = _configuration[$"Hubs:Urls::{connectorName}"];

            HubConnection = new HubConnectionBuilder()
                .WithUrl(url, options =>
                {
                    options.AccessTokenProvider = _tokenServices.ProvideAccessToken;
                })
                .WithAutomaticReconnect()
                .Build();

            InitializeConnectionAsync()
                .Wait();
            _configuration = configuration;
        }
        ~ConnectorBase()
        {
            TerminateConnectionAsync()
                .Wait();
        }



        protected async Task InitializeConnectionAsync()
        {
            await HubConnection.StartAsync();
            await HubConnection.SendAsync("InitializeConnectionAsync");
        }
        protected async Task TerminateConnectionAsync()
        {
            await HubConnection.SendAsync("TerminateConnectionAsync");
            await HubConnection.StopAsync();
        }
    }
}
