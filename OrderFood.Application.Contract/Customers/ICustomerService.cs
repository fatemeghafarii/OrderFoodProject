namespace OrderFood.Application.Contract.Customers
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(CustomerCreateDto customerCreateDto);
        Task<int> UpdateAsync(CustomerUpdateDto customerUpdateDto);
        Task<CustomerGetDto?> GetByIdAsync(Guid id);
        Task<List<CustomerGetDto>> GetAsync(int skip, int take);
        Task<int> RemoveAsync(Guid id);
    }
}
