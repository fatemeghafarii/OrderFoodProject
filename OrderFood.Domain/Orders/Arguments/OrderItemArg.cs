namespace OrderFood.Domain.Orders.Arguments
{
    //public record OrderItemArg(Guid OrderId, int Count , string Title , long Price , long Discount, Guid FoodId);
    public record OrderItemArg
    {
        public OrderItemArg()
        {
           
        }

        public OrderItemArg(Guid orderId, int count, string title, long price, long discount, Guid foodId)
        {
            OrderId = orderId;
            Count = count;
            Title = title;
            Price = price;
            Discount = discount;
            FoodId = foodId;
        }

        public Guid OrderId { get; set; }
        public int Count { get; set; }
        public string Title { get; set; } = null!;
        public long Price { get; set; }
        public long Discount { get; set; }
        public Guid FoodId { get; set; }
    }
}
