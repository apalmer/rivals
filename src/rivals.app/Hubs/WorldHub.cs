using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.app.Hubs
{
    public class WorldHub : Hub
    {
        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }

        public override Task OnConnectedAsync()
         {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            UserConnected(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            UserDisconnected(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public Task UserConnected(string user)
        {
            return Clients.All.SendAsync("UserConnected", user);
        }

        public Task UserDisconnected(string user)
        {
            return Clients.All.SendAsync("UserDisconnected", user);
        }
    }
}
