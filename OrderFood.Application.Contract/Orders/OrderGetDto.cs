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
        public OrderGetDto MapToArgumentForGetById(Order order)
        {
            if (order != null)
            {
                var orderGetDto = new OrderGetDto()
                {
                    Id = order.Id,
                    VendorId = order.VendorId,
                    FinalPrice = order.FinalPrice,
                    CustomerId = order.CustomerId,
                    CreateDate = order.CreateDate,
                    OrderState = order.OrderState
                };
                return orderGetDto;
            }

            return null;
        }
    }
    public record OrderItemGetDto
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
        public string Title { get; set; } = null!;
        public int Count { get; set; }
        public long Discount { get; set; }
    }
}
