namespace ItemPrice.Hub
{
    public interface IItemPriceHub
    {
        Task Subscribe();
        Task Unsubscribe();
        IReadOnlyCollection<string> GetSubscribers();
    }
}
