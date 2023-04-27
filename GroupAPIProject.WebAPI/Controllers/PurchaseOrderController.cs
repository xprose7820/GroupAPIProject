using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupAPIProject.Models.PurchaseOrder;
using GroupAPIProject.Services.PurchaseOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupAPIProject.WebAPI.Controllers
{
    [Authorize(Policy = "CustomRetailerEntity")]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder(PurchaseOrderCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _purchaseOrderService.CreatePurchaseOrderAsync(model))
            {
                return Ok("ProductOrder added to Retailer");
            }
            return BadRequest("ProductOrder not added to Retailer");

        }
        [HttpGet("purchaseOrderId:int")] 
        public async Task<IActionResult> GetPurchaseOrderById([FromRoute] int purchaseOrderId){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            PurchaseOrderDetail detail = await _purchaseOrderService.GetPurchaseOrderByIdAsync(purchaseOrderId);
            if (detail is null){
                return NotFound();
            }
            return Ok(detail);
        }
          [HttpGet("~/BySupplier/{supplierId:int}")]
        public async Task<IActionResult> DoesPurchaseOrderExistBySupplierId([FromRoute] int supplierId){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            PurchaseOrderDetail detail = await _purchaseOrderService.DoesPurchaseOrderExistBySupplierIdAsync(supplierId);
            if(detail is null){
                return BadRequest("purchaseOrder does not exist");
                

            }
            return Ok(detail);
        }
        // whats happending is that we 
        [HttpGet("~/PurchaseOrderItemId/{purchaseOrderItemId:int}")] 
        public async Task<IActionResult> GetPurchaseOrderByPurchaseOrderItemId([FromRoute] int purchaseOrderItemId){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            PurchaseOrderDetail detail = await _purchaseOrderService.GetPurchaseOrderByIdAsync(purchaseOrderItemId);
            if (detail is null){
                return BadRequest();
            }
            return Ok(detail);
        }

    }
}