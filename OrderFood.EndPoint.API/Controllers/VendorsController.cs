using Microsoft.AspNetCore.Mvc;
using OrderFood.Application.Contract.Customers;
using OrderFood.Application.Contract.Vendors;

namespace OrderFood.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet("{skip}/{take}")]
        public async Task<IActionResult> GetAsync(int skip, int take)
        {
            var vendors = await _vendorService.GetAsync(skip, take);
            return Ok(vendors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vendor = await _vendorService.GetByIdAsync(id);
            return Ok(vendor);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VendorCreateDto vendorCreateDto)
        {
            await _vendorService.CreateAsync(vendorCreateDto);
            return Ok(vendorCreateDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(VendorUpdateDto vendorUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var rowAffected = await _vendorService.UpdateAsync(vendorUpdateDto);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _vendorService.RemoveAsync(id);
            return Ok();
        }
    }
}
