﻿namespace Restaurant.Application.Contracts;

public class MenuItemRequest
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Category { get; set; } = default!;
}