using Microsoft.AspNetCore.Mvc;
using OrderFood.Application.Contract.Foods;

namespace OrderFood.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("{skip}/{take}")]
        public async Task<IActionResult> GetAsync(int skip, int take)
        {
            var foods = await _foodService.GetAsync(skip, take);
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var food = await _foodService.GetByIdAsync(id);
            return Ok(food);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FoodCreateDto foodCreate)
        {
            await _foodService.CreateAsync(foodCreate);
            return Ok(foodCreate);
        }

        [HttpPut]
        public async Task<IActionResult> Update(FoodUpdateDto foodUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var rowAffected = await _foodService.UpdateAsync(foodUpdateDto);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _foodService.RemoveAsync(id);
            return Ok();    
        }
    }
}
    