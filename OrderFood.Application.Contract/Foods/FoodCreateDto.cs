using OrderFood.Domain.Customers.Arguments;
using OrderFood.Domain.Foods;
using OrderFood.Domain.Foods.Arguments;
using System.Xml.Linq;

namespace OrderFood.Application.Contract.Foods
{
    public record FoodCreateDto
    {
        public string Title { get; set; } = null!;
        public long Price { get; set; }
        public Guid VendorId { get; set; }
        public Food MapToArgument()
        {
            var foodArg = new FoodArg
            {
                Title = Title,
                Price = Price,
                VendorId = VendorId,
            };

            var food = new Food(Guid.NewGuid(), foodArg);
            return food;    
        }
    }
}
