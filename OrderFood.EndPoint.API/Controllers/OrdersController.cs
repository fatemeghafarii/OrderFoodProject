using Microsoft.AspNetCore.Mvc;
using OrderFood.Application.Contract.Foods;
using OrderFood.Application.Contract.Orders;

namespace OrderFood.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{skip}/{take}")]
        public async Task<IActionResult> GetAsync(int skip, int take)
        {
            var orders = await _orderService.GetAsync(skip, take);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderCreateDto orderCreate)
        {
            await _orderService.CreateAsync(orderCreate);
            return Ok(orderCreate);
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderUpdateDto orderUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var rowAffected = await _orderService.UpdateAsync(orderUpdateDto);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderService.RemoveAsync(id);
            return Ok();
        }
    }
}
