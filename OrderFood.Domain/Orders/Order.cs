using OrderFood.Domain.Contract.Enums;
using OrderFood.Domain.Customers;
using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Orders.Entities;
using OrderFood.Domain.Vendors;
using System.Linq;

namespace OrderFood.Domain.Orders;

public class Order
{
    public Order() {
    }
    public Order(Guid id, OrderArg orderArg)
    {
        Id = id;
        SetProperties(orderArg);
    }
    public Guid Id { get; private set; }
    public Guid VendorId { get; private set; }
    public Vendor? Vendor { get; private set; }
    public long FinalPrice { get; private set; }
    public Guid CustomerId { get; private set; }
    public Customer? Customer { get; private set; }
    public DateTime CreateDate { get; private set; }
    public OrderStateEnum OrderState { get; private set; }
    public ICollection<OrderItem> OrderItems { get; private set; }
    public void Update(Guid vendorId, Guid customerId, OrderStateEnum orderState, List<OrderItem> orderItems)
    {
        VendorId = vendorId;
        CustomerId = customerId;
        OrderState = orderState;
        OrderItems.Clear();
        OrderItems = orderItems;
        SetFinalPrice();
    }
    private void SetProperties(OrderArg orderArg/*, List<OrderItem> orderItems*/)
    {
        VendorId = orderArg.VendorId;
        CustomerId = orderArg.CustomerId;
        CreateDate = DateTime.Now;
        OrderState = orderArg.OrderState;
        OrderItems = orderArg.OrderItems.ToList();
        SetFinalPrice();
    }
    private void SetFinalPrice()
    {
        FinalPrice =  OrderItems.Select(i => (i.Price - i.Discount) * i.Count).Sum();
    }
}
