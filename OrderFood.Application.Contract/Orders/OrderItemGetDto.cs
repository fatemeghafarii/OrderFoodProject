namespace OrderFood.Application.Contract.Orders
{
    public record OrderItemGetDto
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
        public string Title { get; set; } = null!;
        public int Count { get; set; }
        public long Discount { get; set; }
    }
}
