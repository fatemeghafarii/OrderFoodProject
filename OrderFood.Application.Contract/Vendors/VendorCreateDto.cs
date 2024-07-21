using OrderFood.Domain.Orders;
using OrderFood.Domain.Vendors.Arguments;
using OrderFood.Domain.Vendors;

namespace OrderFood.Application.Contract.Vendors
{
    public class VendorCreateDto
    {
        public string Title { get; set; } = null!;

        public long MinimumBasket { get; set; }

        public string Address { get; set; } = null!;

        public DateTime CreateDate { get; set; }
        public Vendor MapToArgument()
        {
            var vendorArg = new VendorArg(
                Title: Title,
                MinimumBasket: MinimumBasket,
                Address: Address
            );

            var vendor = new Vendor(Guid.NewGuid(), vendorArg);
            return vendor;
        }
    }
}
