using OrderFood.Domain.Customers.Arguments;

namespace OrderFood.Application.Contract.Customers
{
    public record CustomerCreateDto
    {
        public string Name { get; set; } = null!;
        public CustomerArg MapToArgument() => new(Name);
    }
}
