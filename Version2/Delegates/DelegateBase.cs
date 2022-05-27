using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace Version2.Delegates
{
    public class DelegateBase
    {
        public string Url { get; set; }


        private readonly HubConnection _hubConnection;

        public DelegateBase()
        {

            _hubConnection = new HubConnectionBuilder()
                   .WithUrl(url, option =>
                   {
                       //option.AccessTokenProvider = () => GenerateToken();
                   })
                   .WithAutomaticReconnect()
                   .Build();

            _hubConnection.On("HandleErrorAsync", HandleErrorAsync);
        }

        public void HandleErrorAsync()
        {
            Console.WriteLine("BOT - ERROR");
        }
    }
}
