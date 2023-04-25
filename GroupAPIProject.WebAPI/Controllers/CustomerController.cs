using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupAPIProject.Models.Customer;
using GroupAPIProject.Services.Customer;
using GroupAPIProject.Services.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GroupAPIProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        private readonly ICustomerService _customerService;

        public CustomerController(ITokenService tokenService, ICustomerService customerService)
        {
            _tokenService = tokenService;
            _customerService = customerService;
        }

        // [HttpDelete]
        // public async Task<IActionResult> RemoveCustomer([FromBody] int customerId)
        // {
        //     return await _customerService.RemoveCustomerAsync(customerId)
        //         ? Ok("Customer was deleted successfully.")
        //         : BadRequest("Customer could not be deleted.");
        // }
        
        [Authorize(Policy = "CustomAdminEntity")]
        [HttpPost]
        public async Task<IActionResult> InputCustomer([FromBody] CustomerRegister newCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _customerService.CreateCustomerAsync(newCustomer))
                return Ok("Customer was added successfully.");

            return BadRequest("Customer could not be added.");
        }

        [Authorize(Policy = "CustomAdminEntity")]
        [HttpPut("{customerId:int}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute]int customerId,[FromBody]CustomerUpdate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _customerService.UpdateCustomerAsync(customerId,update)
                ? Ok("Customer was updated successfully.")
                : BadRequest("Customer was unable to be updated.");
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var customer = await _customerService.GetCustomerListsAsync();
            return Ok(customer);
        }
    }
}