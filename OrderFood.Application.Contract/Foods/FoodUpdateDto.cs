using OrderFood.Domain.Foods;
using OrderFood.Domain.Foods.Arguments;
using OrderFood.Domain.Orders.Entities;

namespace OrderFood.Application.Contract.Foods
{
    public record FoodUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public long Price { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid VendorId { get; set; }
        public Food MapToArgument()
        {
            var foodArg = new FoodArg
            {
                Title = Title,
                Price = Price,
                CreateDate = CreateDate,
                VendorId = VendorId,
            };

            var food = new Food(Id, foodArg);
            return food;    
        }
    }    
}
