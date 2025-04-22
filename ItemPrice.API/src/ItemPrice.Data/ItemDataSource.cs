using ItemPrice.Data;
using System.Collections.Immutable;
using System.Globalization;

namespace ItemPrice.API
{
    public class ItemDataSource : IItemDataSource
    {
        private readonly Random _rand = new Random();

        private readonly ImmutableList<Item> _items;

        public ItemDataSource()
        {
            _items = Enumerable.Range(1, 10)
                               .Select(i => new Item
                               {
                                   Id = Guid.NewGuid().ToString().ToUpper(CultureInfo.CurrentCulture)[..8],
                                   Name = $"Item {i}",
                                   Price = _rand.Next(10, 100),
                                   UpdatedAt = DateTime.UtcNow
                               })
                               .ToImmutableList();
        }

        public IReadOnlyList<Item> Items => _items;
    }
}
