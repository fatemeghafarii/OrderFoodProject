using OrderFood.Domain.Customers.Arguments;
using OrderFood.Domain.Customers;

namespace OrderFood.Application.Contract.Customers
{
    public record CustomerGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
