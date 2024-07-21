using OrderFood.Domain.Customers;
using OrderFood.Domain.Foods;
using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Vendors;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Domain.Orders.Entities;

public class OrderItem
{
    public OrderItem(){}
    public OrderItem(OrderItemArg orderItemArg)
    { 
        SetProperties(orderItemArg);
    }
    public Guid Id { get; private set; }
    [ForeignKey("OrderId")]
    public virtual Order Order { get; private set; } = null!;
    public Guid OrderId { get; private set; }
    public long Price { get; private set; }
    public string Title { get; private set; } = null!;
    public int Count { get; private set; }
    public long Discount { get; private set; } 
    [ForeignKey("FoodId")]
    public virtual Food Food { get; private set; } = null!;
    public Guid FoodId { get; private set; }
    private void SetProperties(OrderItemArg orderItemArg)
    {
        OrderId = orderItemArg.OrderId;
        Title = orderItemArg.Title;
        Count = orderItemArg.Count;
        Price = orderItemArg.Price;
        Discount = orderItemArg.Discount;
        FoodId = orderItemArg.FoodId;   
    }
}
