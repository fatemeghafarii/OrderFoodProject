namespace OrderFood.Application.Contract.Orders
{
    public record OrderItemDto
    {
        public Guid FoodId { get; set; }
        public int Count { get; set; }
    }
}
