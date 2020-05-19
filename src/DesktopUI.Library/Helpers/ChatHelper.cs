﻿using DesktopUI.Library.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Configuration;
using System.Threading.Tasks;
using DesktopUI.Library.Models.DbModels;

namespace DesktopUI.Library.Helpers
{
    public class ChatHelper : IChatHelper
    {
        private readonly IAuthenticatedUser _user;
        public HubConnection Connection { get; private set; }
        public event EventHandler<Comment> GetReceive;

        public ChatHelper(IAuthenticatedUser user)
        {
            _user = user;
        }

        public async Task CreateHubConnection(string photoId)
        {
            string api = ConfigurationManager.AppSettings["Chat"];

            Connection = new HubConnectionBuilder()
              .WithUrl(api, options =>
              {
                  options.AccessTokenProvider = () => Task.FromResult(_user.Token);
              })
              .WithAutomaticReconnect()
              .ConfigureLogging(logging => { logging.AddConsole(); })
              .Build();

            Connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await Connection.StartAsync();
            };

            Connection.On<Comment>("ReceiveComment", (comment) =>
            {
                GetReceive?.Invoke(this, comment);
            });

            await Connection.StartAsync();

            if (Connection.State == HubConnectionState.Connected)
            {
                await Connection.InvokeAsync("AddToGroup", photoId);
            }
        }

        public async Task StopHubConnection(string photoId)
        {
            await Connection.InvokeAsync("RemoveFromGroup", photoId);

            await Connection.StopAsync();
        }
    }
}
