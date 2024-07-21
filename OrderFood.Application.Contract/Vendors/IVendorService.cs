namespace OrderFood.Application.Contract.Vendors
{
    public interface IVendorService
    {
        Task<int> CreateAsync(VendorCreateDto VendorCreateDto);
        Task<int> UpdateAsync(VendorUpdateDto VendorUpdateDto);
        Task<VendorGetDto?> GetByIdAsync(Guid id);
        Task<List<VendorGetDto>> GetAsync(int skip, int take);
        Task<int> RemoveAsync(Guid id);
    }
}
