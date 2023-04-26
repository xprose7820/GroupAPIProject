using GroupAPIProject.Data.Entities;
using GroupAPIProject.Models.Product;
using GroupAPIProject.Models.User;
using GroupAPIProject.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GroupAPIProject.WebAPI.Controllers
{
    [Authorize(Policy = "CustomAdminEntity")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }
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
            return BadRequest("Product Creation Failed");
        }
        [HttpGet]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ProductDetail productDetail = await _productService.GetProductByIdAsync(productId);
            if (productDetail != null)
            {
                return Ok("Get Product Worked");
            }
            return BadRequest("Get Method Failed");
        }
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
            return BadRequest("Product Deletion Failed");
        }
    }
}
