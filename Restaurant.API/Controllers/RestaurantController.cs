﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Contracts;
using Restaurant.Application.Interfaces.Services;

namespace Restaurant.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class RestaurantController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<RestaurantResponse>>> GetRestaurants()
    {
        var restaurants = await restaurantsService.GetAllRestaurants();

        var response = restaurants.Select(b => new RestaurantResponse(b.Id, b.Name, b.Description));

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RestaurantResponse>> GetRestaurantById(Guid id)
    {
        var restaurant = await restaurantsService.GetRestaurantById(id);
        
        if (restaurant == null)
            return NotFound();

        var response = new RestaurantResponse(restaurant.Id, restaurant.Name, restaurant.Description);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateRestaurant([FromBody] RestaurantRequest restaurantRequest)
    {
        var restaurantId = await restaurantsService.CreateRestaurant(restaurantRequest);

        return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurantId }, restaurantId);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateRestaurant(Guid id, [FromBody] RestaurantRequest restaurantRequest)
    {
        var restaurant = await restaurantsService.GetRestaurantById(id);
        if (restaurant == null)
            return NotFound();
        
        var restaurantId = await restaurantsService.UpdateRestaurant(id, restaurantRequest);

        return Ok(restaurantId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteRestaurant(Guid id)
    {
        var restaurant = await restaurantsService.GetRestaurantById(id);
        if (restaurant == null)
            return NotFound();
        
        var restaurantId = await restaurantsService.DeleteRestaurant(id);
        
        return Ok(restaurantId);
    }
}