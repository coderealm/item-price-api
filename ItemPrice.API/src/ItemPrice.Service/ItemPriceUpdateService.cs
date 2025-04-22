using ItemPrice.Data;
using ItemPrice.Hub;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ItemPrice.API
{
    public class ItemPriceUpdateService(IHubContext<ItemPriceHub> hubContext, 
        IItemPriceHub itemPriceHub,
        IItemDataSource itemDataSource,
        ILogger<ItemPriceUpdateService> logger)
        : BackgroundService, IItemPriceUpdateService
    {
        private readonly IHubContext<ItemPriceHub> _hubContext = hubContext;
        private readonly ILogger<ItemPriceUpdateService> _logger = logger;
        private readonly IItemPriceHub _itemPriceHub = itemPriceHub;
        private readonly IItemDataSource _itemDataSource = itemDataSource;
        private static readonly Random _rand = new();

        public async Task<List<Item>> GetItems()
        {
            return await Task.FromResult(_itemDataSource.Items.ToList());
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var items = await GetItems();

                foreach (var item in items)
                {
                    int change = _rand.Next(-5, 6);
                    item.Price = Math.Max(1, item.Price + change);
                    item.UpdatedAt = DateTime.UtcNow;
                }

                var subscribers = _itemPriceHub.GetSubscribers();
                if (subscribers.Count != 0)
                {
                    await _hubContext.Clients.Clients([.. subscribers])
                        .SendAsync("PriceUpdate", items, cancellationToken: stoppingToken);
                }

                _logger.LogInformation("Sent update to clients");

                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}
