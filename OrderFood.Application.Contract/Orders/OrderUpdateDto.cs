using OrderFood.Domain.Contract.Enums;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Orders.Contracts;
using System.Net.Sockets;

namespace OrderFood.Application.Contract.Orders
{
    public record OrderUpdateDto
    {
        public Guid Id { get; set; }
        public Guid VendorId { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStateEnum OrderState { get; set; }
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
    public record OrderItemDto
    {
        public Guid FoodId { get; set; }
        public int Count { get; set; }
    }
}
