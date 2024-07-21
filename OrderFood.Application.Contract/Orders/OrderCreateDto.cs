using OrderFood.Domain.Contract.Enums;
using OrderFood.Domain.Foods;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Orders.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFood.Application.Contract.Orders
{
    public record OrderCreateDto
    {
        public Guid VendorId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStateEnum OrderState { get; set; }
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
        public OrderArg MapToArgument()
        {
            return new()
            {
                VendorId = VendorId,
                CustomerId = CustomerId,
                OrderState = OrderState
            };
        }
    }
    public record OrderItemCreateDto
    {
        public long Price { get; set; }
        public string Title { get; set; } = null!;
        public int Count { get; set; }
        public long Discount { get; set; }
        public Guid FoodId { get; set; }
    }
}
