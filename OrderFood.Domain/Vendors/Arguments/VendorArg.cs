using OrderFood.Domain.Foods.Arguments;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Arguments;

namespace OrderFood.Domain.Vendors.Arguments
{
    public record VendorArg(string Title, long MinimumBasket, string Address, DateTime CreateDate = default);
}
