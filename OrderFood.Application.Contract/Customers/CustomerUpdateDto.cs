using OrderFood.Domain.Customers;
using OrderFood.Domain.Customers.Arguments;

namespace OrderFood.Application.Contract.Customers
{
    public record CustomerUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public CustomerArg MapToArgument(Customer customer) => new(Name);
    }
}
