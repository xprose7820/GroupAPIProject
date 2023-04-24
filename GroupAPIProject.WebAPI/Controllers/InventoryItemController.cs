﻿using GroupAPIProject.Models.InventoryItem;
using GroupAPIProject.Models.Product;
using GroupAPIProject.Services.InventoryItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupAPIProject.WebAPI.Controllers
{
    [Authorize(Policy = "CustomRetailerEntity")]
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
        public async Task<IActionResult> CreateInventoryItem([FromBody] InventoryItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _inventoryItemService.CreateInventoryItemAsync(model))
            {
                return Ok("Inventory Item Was Created");
            }
            return BadRequest("Inventory Item Creation Failed");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteInventoryItemById([FromBody] InventoryItemDelete model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _inventoryItemService.DeleteInventoryItemByIdAsync(model))
            {
                return Ok("Inventory Item Was Deleted");
            }
            return BadRequest("Inventory Item Deletion Failed");
        }
    }
}
