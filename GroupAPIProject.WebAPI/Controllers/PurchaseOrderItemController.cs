using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupAPIProject.Models.PurchaseOrderItem;
using GroupAPIProject.Services.PurchaseOrderItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupAPIProject.WebAPI.Controllers
{
    [Authorize(Policy = "CustomRetailerEntity")]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderItemController : ControllerBase
    {
        private readonly IPurchaseOrderItemService _purchaseOrderItemService;
        public PurchaseOrderItemController(IPurchaseOrderItemService purchaseOrderItemService)
        {
            _purchaseOrderItemService = purchaseOrderItemService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrderItem(PurchaseOrderItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _purchaseOrderItemService.CreatePurchaseOrderItemAsync(model))
            {
                return Ok("ProductOrderItem added to Retailer");
            }
            return BadRequest("ProductOrderItem not added to Retailer");
        }
        [HttpGet("purchaseOrderItemId:int")]
        public async Task<IActionResult> GetPurchaseOrderItemById([FromRoute] int purchaseOrderItemId){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            PurchaseOrderItemDetail detail = await _purchaseOrderItemService.GetPurchaseOrderItemByIdAsync(purchaseOrderItemId);
            if (detail is null){
                return NotFound();
            }
            return Ok(detail);
        }
         [HttpGet]
        public async Task<IActionResult> GetAllPurchaseOrderItemFromAllPurchaseOrder(){
            IEnumerable<PurchaseOrderItemListItem> details = await _purchaseOrderItemService.GetAllPurchaseOrderItemFromAllPurchaseOrderAsync();
            if(details is null){
                return BadRequest();
            }
            return Ok(details);
        }


    }
}