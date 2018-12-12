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
            UserConnected(Context.User.Identity.Name, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            UserDisconnected(Context.User.Identity.Name, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public Task UserConnected(string userName, string connectionId)
        {
            return Clients.All.SendAsync("UserConnected", userName, connectionId);
        }

        public Task UserDisconnected(string userName, string connectionId)
        {
            return Clients.All.SendAsync("UserDisconnected", userName, connectionId);
        }
    }
}
