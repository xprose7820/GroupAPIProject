using GroupAPIProject.Data.Entities;
using GroupAPIProject.Models.Product;
using GroupAPIProject.Models.User;
using GroupAPIProject.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GroupAPIProject.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Policy = "CustomAdminEntity")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _productService.CreateProductAsync(model))
            {
                return Ok("Product Was Created");
            }
            else
            {
                return BadRequest("Product Creation Failed");
            }
        }
        [Authorize(Policy = "CustomRetailerEntity")]
        [Authorize(Policy = "CustomAdminEntity")]
        [HttpGet("{supplierId:int}/{productId:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int supplierId,[FromRoute] int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ProductDetail productDetail = await _productService.GetProductByIdAsync(supplierId, productId);
            if (productDetail == null) 
            {
                return NotFound();
            }
            return Ok(productDetail);
        }
        [Authorize(Policy = "CustomAdminEntity")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductById([FromBody] ProductUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _productService.UpdateProductAsync(model)
                ? Ok("Product was updated successfully")
                : BadRequest("Product failed to be updated");
        }
        [Authorize(Policy = "CustomAdminEntity")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductById([FromBody] ProductDelete model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _productService.DeleteProductByIdAsync(model))
            {
                return Ok("Product Was Deleted");
            }
            else
            {
                return BadRequest("Product Deletion Failed");
            }
        }
    }
}
