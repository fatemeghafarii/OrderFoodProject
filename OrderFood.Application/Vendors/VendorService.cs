using Microsoft.EntityFrameworkCore;
using OrderFood.Application.Contract.Vendors;
using OrderFood.Domain.Vendors;
using OrderFood.Domain.Vendors.Arguments;
using OrderFood.Framework.Persistence.EF;

namespace OrderFood.Application.Vendors
{
    public class VendorService : IVendorService
    {
        private readonly IRepository<Vendor> _vendorRepository;
        public VendorService(IRepository<Vendor> vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        public async Task<int> CreateAsync(VendorCreateDto vendorCreateDto)
        {
            var vendor = vendorCreateDto.MapToArgument();
            return await _vendorRepository.CreateAsync(vendor);
        }

        public async Task<List<VendorGetDto>> GetAsync(int skip, int take)
        {
            var vendors = await _vendorRepository.GetAsNoTracking().Skip(skip).Take(take).ToListAsync();
            var vendorGetDto = new VendorGetDto();
            return vendorGetDto.MapToArgument(vendors);
        }

        public async Task<VendorGetDto?> GetByIdAsync(Guid id)
        {
            var vendor = await _vendorRepository.GetAsNoTracking().FirstAsync(o => o.Id == id) ?? throw new Exception();
            var vendorGetDto = new VendorGetDto();
            return vendorGetDto.MapToArgumentGetById(vendor);

        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var vendor = await _vendorRepository.GetAsNoTracking().FirstOrDefaultAsync(o => o.Id == id) ?? throw new Exception();
            var vendorArg = new VendorArg
            (
                 Title: vendor.Title,
                MinimumBasket: vendor.MinimumBasket,
                Address: vendor.Address,
                CreateDate: vendor.CreateDate
            );
            vendor = new Vendor(id, vendorArg);
            return await _vendorRepository.RemoveAsync(vendor);
        }

        public async Task<int> UpdateAsync(VendorUpdateDto vendorUpdateDto)
        {
            var vendor = await _vendorRepository.GetAsNoTracking().FirstAsync(o => o.Id == vendorUpdateDto.Id);
            vendor = vendorUpdateDto.MapToArgument(vendor);
            return await _vendorRepository.UpdateAsync(vendor);
        }
    }
}
