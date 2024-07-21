using OrderFood.Domain.Foods;
using OrderFood.Domain.Orders.Entities;

namespace OrderFood.Application.Contract.Foods
{
    public record FoodGetDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public long Price { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid VendorId { get; set; }
        public FoodGetDto MapToArgumentForGetById(Food food)
        {
            return new()
            {
                Id = food.Id,
                Title = food.Title,
                Price = food.Price,
                CreateDate = food.CreateDate,
                VendorId = food.VendorId,
            };
            //return result;
        }
        public List<FoodGetDto> MapToArgument(List<Food> foods)
        {
            var result = foods.Select(f => new FoodGetDto
            {
                Title = f.Title,
                Price = f.Price,
                CreateDate = f.CreateDate,
                VendorId = f.VendorId
            }).ToList();

            return result;
        }
    }
}
