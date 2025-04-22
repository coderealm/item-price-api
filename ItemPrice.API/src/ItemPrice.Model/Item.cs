﻿namespace ItemPrice.API
{
    public class Item
    {
        public required string Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
