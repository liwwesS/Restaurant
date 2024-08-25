using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Contracts;
using Restaurant.Application.Interfaces.Services;

namespace Restaurant.API.Controllers;

[Authorize]
[ApiController]
[Route("/Restaurant/{restaurantId:guid}/menu-items")]
public class MenuItemController(IMenuItemsService menuItemsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<MenuItemResponse>>> GetMenuItems(Guid restaurantId)
    {
        var menuItems = await menuItemsService.GetAllMenuItems();
        
        var response = menuItems
            .Where(m => m.RestaurantId == restaurantId)
            .Select(m => new MenuItemResponse(m.Id, m.RestaurantId, m.Price, m.Name, m.Category))
            .ToList();

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MenuItemResponse>> GetMenuItemById(Guid restaurantId, Guid id)
    {
        var menuItem = await menuItemsService.GetMenuItemById(id);

        if (menuItem == null || menuItem.RestaurantId != restaurantId)
        {
            return NotFound();
        }

        var response = new MenuItemResponse(menuItem.Id, menuItem.RestaurantId, menuItem.Price, menuItem.Name, menuItem.Category);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateMenuItem(Guid restaurantId, [FromBody] MenuItemRequest request)
    {
        if (request.RestaurantId != restaurantId)
        {
            return BadRequest("Restaurant ID in the request body does not match the URL.");
        }
        
        var menuItemId = await menuItemsService.CreateMenuItem(request);
        
        return Ok(menuItemId);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateMenuItem(Guid restaurantId, Guid id, [FromBody] MenuItemRequest request)
    {
        var existingMenuItem = await menuItemsService.GetMenuItemById(id);
        if (existingMenuItem == null || existingMenuItem.RestaurantId != restaurantId)
        {
            return NotFound();
        }

        if (request.RestaurantId != restaurantId)
        {
            return BadRequest("Restaurant ID in the request body does not match the URL.");
        }
        
        var menuItemId = await menuItemsService.UpdateMenuItem(id, request);
        return Ok(menuItemId);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteMenuItem(Guid restaurantId, Guid id)
    {
        var existingMenuItem = await menuItemsService.GetMenuItemById(id);
        if (existingMenuItem == null || existingMenuItem.RestaurantId != restaurantId)
        {
            return NotFound();
        }

        var menuItemId = await menuItemsService.DeleteMenuItem(id);
        return Ok(menuItemId);
    }
}