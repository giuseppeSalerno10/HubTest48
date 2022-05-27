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

    public abstract class HandlerBase
    {
        protected string Url { get; private set; }
        protected HubConnection HubConnection { get; private set; }
        protected ITokenServices _tokenServices;
        protected IConfiguration _configuration;

        public HandlerBase(ITokenServices tokenServices, IConfiguration configuration)
        {
            _tokenServices = tokenServices;

            var handlerName = GetType()
                    .Name
                    .Replace("Handler", "");

            var url = _configuration[$"Hubs:Urls:{handlerName}"];

            HubConnection.On("ReceiveErrorAsync", ReceiveErrorAsync);

            HubConnection = new HubConnectionBuilder()
                .WithUrl(Url, options =>
                {
                    options.AccessTokenProvider = _tokenServices.ProvideAccessToken;
                })
                .WithAutomaticReconnect()
                .Build();

            InitializeConnectionAsync()
                .Wait();
            _configuration = configuration;
        }

        ~HandlerBase()
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

        #region Actions
        protected void ReceiveErrorAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
