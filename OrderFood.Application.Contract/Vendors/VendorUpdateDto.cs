using OrderFood.Domain.Vendors;
using OrderFood.Domain.Vendors.Arguments;

namespace OrderFood.Application.Contract.Vendors
{
    public class VendorUpdateDto : VendorCreateDto
    {
        public Guid Id { get; set; }
        public Vendor MapToArgument(Vendor vendor)
        {
            var vendorArg = new VendorArg
            (
                Title: Title,
                MinimumBasket: MinimumBasket,
                Address: Address,
                CreateDate: CreateDate
            );

            vendor = new Vendor(Id, vendorArg);
            return vendor;  
        }
    }
}
