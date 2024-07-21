using OrderFood.Domain.Foods;

namespace OrderFood.Application.Contract.Foods
{
    public interface IFoodService
    {
        Task<int> CreateAsync(FoodCreateDto foodCreateDto);
        Task<int> UpdateAsync(FoodUpdateDto foodUpdateDto);
        Task<FoodGetDto?> GetByIdAsync(Guid id);
        Task<List<FoodGetDto>> GetAsync(int skip, int take);
        Task<int> RemoveAsync(Guid id);
        
    }
}
