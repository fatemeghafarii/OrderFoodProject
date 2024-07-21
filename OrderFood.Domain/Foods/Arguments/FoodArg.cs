using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Orders.Entities;

namespace OrderFood.Domain.Foods.Arguments
{
    //public record FoodArg(long Price, DateTime CreateDate, Guid VendorId, string Title = null!);
    public record FoodArg
    {
        public string Title { get; set; } = null!;
        public long Price { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid VendorId { get; set; }
        public long Discount { get; set; }
    }
}
