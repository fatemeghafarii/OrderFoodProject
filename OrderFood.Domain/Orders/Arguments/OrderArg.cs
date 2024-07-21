using OrderFood.Domain.Contract.Enums;
using OrderFood.Domain.Orders.Contracts;
using OrderFood.Domain.Orders.Entities;

namespace OrderFood.Domain.Orders.Arguments
{
    //public record OrderArg(Guid VendorId , Guid CustomerId , OrderStateEnum OrderState, List<OrderItem> OrderItems );
    public record OrderArg
    {
        public Guid VendorId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStateEnum OrderState { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();       
    }
}
