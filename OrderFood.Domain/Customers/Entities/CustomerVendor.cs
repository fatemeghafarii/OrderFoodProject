using OrderFood.Domain.Vendors;

namespace OrderFood.Domain.Customers.Entities
{
    public class CustomerVendor
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer? Customer { get; private set; }
        public Guid VendorId { get; private set; }
        public Vendor? Vendor { get; private set; }
    }
}
