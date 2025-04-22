using ItemPrice.API;

namespace ItemPrice.Data
{
    public interface IItemDataSource
    {
        IReadOnlyList<Item> Items { get; }
    }
}
