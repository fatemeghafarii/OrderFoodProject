using OrderFood.Domain.Contract.Enums;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Contracts;

namespace OrderFood.Application.Contract.Orders
{
    public record OrderGetDto
    {
        public Guid Id { get; set; }
        public Guid VendorId { get; set; }
        public long FinalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStateEnum OrderState { get; set; }
        public List<OrderItemGetDto> Items { get; set; } = new List<OrderItemGetDto>();
    }
}
