using OrderFood.Domain.Vendors;
using System.Numerics;

namespace OrderFood.Application.Contract.Vendors
{
    public class VendorGetDto : VendorUpdateDto
    {
        public List<VendorGetDto> MapToArgument(List<Vendor> vendors)
        {
            var result = vendors.Select(v => new VendorGetDto
            {
                Title = v.Title,
                MinimumBasket = v.MinimumBasket,
                Address = v.Address,
                CreateDate = v.CreateDate
            }).ToList();

            return result;
        }
        public VendorGetDto MapToArgumentGetById(Vendor vendor)
        {
            var vendorGetDto = new VendorGetDto()
            {
                Id = vendor.Id,
                Title = vendor.Title,
                MinimumBasket = vendor.MinimumBasket,
                Address = vendor.Address,
                CreateDate = vendor.CreateDate,
            };
            return vendorGetDto;
        }
    }
}
