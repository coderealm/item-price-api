using Microsoft.AspNetCore.Mvc;

namespace ItemPrice.API.Controllers
{
    [ApiController]
    [Route("item")]
    public class ItemPriceController(IItemPriceUpdateService itemPriceUpdateService) : ControllerBase
    {
        private readonly IItemPriceUpdateService _itemPriceUpdateService = itemPriceUpdateService;

        [HttpGet("prices")]
        public async Task<IActionResult> Get()
        {
            var prices = await _itemPriceUpdateService.GetItems();
            return Ok(prices);
        }
    }
}
