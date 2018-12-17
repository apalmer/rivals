using Microsoft.AspNetCore.SignalR;
using rivals.domain.Game;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace rivals.app.Hubs
{
    public class WorldHub : Hub
    {
        private logic.Game.DuelManager _duelManager;

        public static class UserHandler
        {
            public static ConcurrentDictionary<string,Player> ConnectedUsers = new ConcurrentDictionary<string, Player>();
        }

        public override Task OnConnectedAsync()
         {
            var user = new Player(Context.User.Identity.Name, Context.ConnectionId);
            UserHandler.ConnectedUsers.AddOrUpdate(user.UserName, user, (k, v) => user);
            UserConnected(user);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = new Player(Context.User.Identity.Name, Context.ConnectionId);
            Player old;
            UserHandler.ConnectedUsers.TryRemove(user.UserName, out old);
            UserDisconnected(user);
            return base.OnDisconnectedAsync(exception);
        }

        public Task UserConnected(Player user)
        {
            return Clients.All.SendAsync("UserConnected", user);
        }

        public Task UserDisconnected(Player user)
        {
            return Clients.All.SendAsync("UserDisconnected", user);
        }

        public ChannelReader<Player> StreamUsers(int count, int delay)
        {
            var channel = Channel.CreateUnbounded<Player>();

            // We don't want to await WriteItemsAsync, otherwise we'd end up waiting 
            // for all the items to be written before returning the channel back to
            // the client.
            _ = WriteUsersAsync(channel.Writer, count, delay);

            return channel.Reader;
        }

        private async Task WriteUsersAsync(
           ChannelWriter<Player> writer,
           int count,
           int delay)
        {
            var isolated = UserHandler.ConnectedUsers.Values.ToArray();

            for (var i = 0; i < isolated.Length; i++)
            {
                if (i != 0 && i % count == 0)
                {
                    await Task.Delay(delay);
                }

                await writer.WriteAsync(isolated[i]);
            }

            writer.TryComplete();
        }

        public Task IssueChallenge(Player challenged)
        {
            var challenger = new Player(Context.User.Identity.Name, Context.ConnectionId);
            return Clients.Client(challenged.ConnectionID).SendAsync("ChallengeIssued", challenger);
        }

        public async void AcceptChallenge(Player challenger)
        {
            var challenged = new Player(Context.User.Identity.Name, Context.ConnectionId);
            StartDuel(challenger, challenged);
        }

        public async void DeclineChallenge(Player challenger)
        {
            var challenged = new Player(Context.User.Identity.Name, Context.ConnectionId);
        }

        private async void StartDuel(Player challenger, Player challenged)
        {
            var duel = await _duelManager.RegisterDuel(challenger, challenged);

            var duelGroupName = $"DUEL-{duel.ID}";
            await Groups.AddToGroupAsync(challenger.ConnectionID, duelGroupName);
            await Groups.AddToGroupAsync(challenged.ConnectionID, duelGroupName);

            await Clients.Groups(duelGroupName).SendAsync("StartDuel", duel);
        }

        public WorldHub(logic.Game.DuelManager duelManager)
        {
            _duelManager = duelManager;
        }
    }
}
 