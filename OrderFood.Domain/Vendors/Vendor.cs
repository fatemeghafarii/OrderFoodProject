using OrderFood.Domain.Customers.Arguments;
using OrderFood.Domain.Customers.Entities;
using OrderFood.Domain.Foods;
using OrderFood.Domain.Foods.Arguments;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Orders.Entities;
using OrderFood.Domain.Vendors.Arguments;

namespace OrderFood.Domain.Vendors;

public class Vendor
{
    public Vendor() { }
    public Vendor(Guid id, VendorArg vendorArg)
    {
        Id = id;
        SetProperties(vendorArg);
        Validate(vendorArg);
    }
    public Guid Id { get; private set; } 

    public string Title { get; private set; } = null!;

    public long MinimumBasket { get; private set; }

    public string Address { get; private set; } = null!;

    public DateTime CreateDate { get; private set; }

    public ICollection<Order>? Orders { get; private set; } = new List<Order>();
    public ICollection<CustomerVendor> CustomerVendors { get; private set; } = new HashSet<CustomerVendor>();
    public ICollection<Food>? Foods { get; private set; } = new HashSet<Food>();
    private void SetProperties(VendorArg vendorArg)
    {
        Title = vendorArg.Title;
        MinimumBasket = vendorArg.MinimumBasket;
        Address = vendorArg.Address;
        CreateDate = DateTime.Now;
    }
    private void Validate(VendorArg vendorArg)
    {
        if (string.IsNullOrEmpty(vendorArg.Title))
            throw new Exception();
    }
}
