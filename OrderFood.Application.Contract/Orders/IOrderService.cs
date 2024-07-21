namespace OrderFood.Application.Contract.Orders
{
    public interface IOrderService
    {
        Task<int> CreateAsync(OrderCreateDto orderCreateDto);
        Task<int> UpdateAsync(OrderUpdateDto orderUpdateDto);
        Task<OrderGetDto?> GetByIdAsync(Guid id);
        Task<List<OrderGetDto>> GetAsync(int skip, int take);
        Task<int> RemoveAsync(Guid id);
    }
}
