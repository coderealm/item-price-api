namespace ItemPrice.API
{
    using ItemPrice.Hub;
    using Microsoft.AspNetCore.SignalR;

    public class ItemPriceHub: Hub, IItemPriceHub
    {
        private static readonly HashSet<string> Subscribers = new();

        public async Task Subscribe()
        {
            Subscribers.Add(Context.ConnectionId);
            await Clients.Caller.SendAsync("Subscribed", true);
        }

        public async Task Unsubscribe()
        {
            Subscribers.Remove(Context.ConnectionId);
            await Clients.Caller.SendAsync("Subscribed", false);
        }

        public IReadOnlyCollection<string> GetSubscribers() => Subscribers;

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Subscribers.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
