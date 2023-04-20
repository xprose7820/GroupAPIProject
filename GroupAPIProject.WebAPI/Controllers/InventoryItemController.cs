﻿using GroupAPIProject.Services.InventoryItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupAPIProject.WebAPI.Controllers
{
    [Authorize("Roles=RetailerEntity")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemService _inventoryItemService;

        public InventoryItemController(IInventoryItemService inventoryItemService)
        {
            _inventoryItemService = inventoryItemService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateInventoryItem([FromBody] InventoryItemService model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            if (await _inventoryItemService.CreateInventoryItemAsync(model))
            {
                return Ok("Inventory Item Was Created");
            }
            return BadRequest("Inventory Item Creation Faield");
        }
    }
}
