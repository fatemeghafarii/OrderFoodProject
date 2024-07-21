using OrderFood.Domain.Foods.Arguments;
using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Orders.Entities;
using OrderFood.Domain.Vendors;

namespace OrderFood.Domain.Foods;

public partial class Food
{
    public Food() {}
    public Food(string Title) 
    {
        this.Title = Title;
    }
    public Food(Guid id, FoodArg foodArg)
    {
        Id = id;
        Title = foodArg.Title;
        Price = foodArg.Price;
        CreateDate = DateTime.Now;
        VendorId = foodArg.VendorId;
        Discount = foodArg.Discount;
        Validate(foodArg);
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public long Price { get; private set; }
    public DateTime CreateDate { get; private set; }
    public long Discount { get; private set; }
    public Guid VendorId { get; private set; }
    public Vendor? Vendor { get; private set; }
    public ICollection<OrderItem>? OrderItems { get; private set; } = new HashSet<OrderItem>();
    private void Validate(FoodArg foodArg)
    {
        if (string.IsNullOrEmpty(foodArg.Title))
            throw new Exception();
    }
}
