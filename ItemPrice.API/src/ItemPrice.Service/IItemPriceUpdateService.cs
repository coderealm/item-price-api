namespace ItemPrice.API
{
    public interface IItemPriceUpdateService
    {
        Task<List<Item>> GetItems();
    }
}
