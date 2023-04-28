using GroupAPIProject.Models.InventoryItem;
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
            else
            {
                return BadRequest("Inventory Item Creation Failed");
            }
        }
        [HttpGet("{inventoryItemId:int}")]
        public async Task<IActionResult> GetInventoryItemById([FromRoute] int inventoryItemId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            InventoryItemDetail inventoryItemDetail = await _inventoryItemService.GetInventoryItemByIdAsync(inventoryItemId);
            if (inventoryItemDetail == null)
            {
                return NotFound();
            }
            return Ok(inventoryItemDetail);
        }
        //[HttpGet("{locationId:int}")]
        //public async Task<IActionResult> GetInventoryItemListByLocationId([FromRoute] int locationId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var inventoryItemToDisplay = await _inventoryItemService.GetInventoryItemListByLocationIdAsync(locationId);
        //    return Ok(inventoryItemToDisplay);
        //}
        [HttpPut]
        public async Task<IActionResult> UpdateInventoryById([FromBody] InventoryItemUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _inventoryItemService.UpdateInventoryItemAsync(model)
                ? Ok("Inventory Item was updated successfully")
                : BadRequest("Inventory Item failed to be updated");
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
