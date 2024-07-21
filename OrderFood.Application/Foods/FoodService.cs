using Microsoft.EntityFrameworkCore;
using OrderFood.Application.Contract.Foods;
using OrderFood.Domain.Foods;
using OrderFood.Domain.Foods.Arguments;
using OrderFood.Framework.Persistence.EF;

namespace OrderFood.Application.Foods
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _repository;
        public FoodService(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(FoodCreateDto foodCreateDto)
        {
            //var foodArg = new FoodArg
            //{
            //    Title = foodCreateDto.Title,
            //    Price = foodCreateDto.Price,
            //    VendorId = foodCreateDto.VendorId,
            //};

            //var food = new Food(Guid.NewGuid(), foodArg);
            var food = foodCreateDto.MapToArgument();
            return await _repository.CreateAsync(food);
        }
        public async Task<int> UpdateAsync(FoodUpdateDto foodUpdateDto)
        {
            var food = await _repository.GetAsNoTracking().FirstOrDefaultAsync(f => f.Id == foodUpdateDto.Id);
            //var foodArg = new FoodArg
            //{
            //    Title = foodUpdateDto.Title,
            //    Price = foodUpdateDto.Price,
            //    CreateDate = foodUpdateDto.CreateDate,
            //    VendorId = foodUpdateDto.VendorId,
            //};

            //food = new Food(foodUpdateDto.Id, foodArg);
            food = foodUpdateDto.MapToArgument();
            return await _repository.UpdateAsync(food);
        }

        public async Task<FoodGetDto?> GetByIdAsync(Guid id)
        {
            var food = await _repository.GetAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (food != null)
            {
                //return new()
                //{
                //    Id = food.Id,
                //    Title = food.Title,
                //    Price = food.Price,
                //    CreateDate = food.CreateDate,
                //    VendorId = food.VendorId,
                //};
                var foodGetDto = new FoodGetDto();
                return foodGetDto.MapToArgumentForGetById(food);
            }

            return null;
        }
        public async Task<List<FoodGetDto>> GetAsync(int skip, int take)
        {
            var foods = await _repository.GetAsNoTracking().Skip(skip).Take(take).ToListAsync();
            //var result = foods.Select(f => new FoodGetDto
            //{
            //    Title = f.Title,
            //    Price = f.Price,
            //    CreateDate = f.CreateDate,
            //    VendorId = f.VendorId
            //}).ToList();

            //return result;
            var foodGetDto = new FoodGetDto();
            var result = foodGetDto.MapToArgument(foods);
            return result;
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var food = await _repository.GetAsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
            if (food != null)
            {
                var foodArg = new FoodArg
                {
                    Title = food.Title,
                    Price = food.Price,
                    CreateDate = food.CreateDate,
                    VendorId = food.VendorId,
                };
                food = new Food(id, foodArg);
                return await _repository.RemoveAsync(food);
            }

            return 0;

        }
    }
}
