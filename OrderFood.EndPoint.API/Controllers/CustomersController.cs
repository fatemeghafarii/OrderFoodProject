using Microsoft.AspNetCore.Mvc;
using OrderFood.Application.Contract.Customers;

namespace OrderFood.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{skip}/{take}")]
        public async Task<IActionResult> GetAsync(int skip, int take)
        {
            var customers = await _customerService.GetAsync(skip, take);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerCreateDto customerCreateDto)
        {
            await _customerService.CreateAsync(customerCreateDto);
            return Ok(customerCreateDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var rowAffected = await _customerService.UpdateAsync(customerUpdateDto);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerService.RemoveAsync(id);
            return Ok();
        }
    }
}
