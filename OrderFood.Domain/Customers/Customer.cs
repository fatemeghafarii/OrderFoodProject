using OrderFood.Domain.Customers.Arguments;
using OrderFood.Domain.Customers.Entities;
using OrderFood.Domain.Foods.Arguments;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Orders.Entities;

namespace OrderFood.Domain.Customers
{
    public class Customer
    {
        public Customer(){}
        public Customer(Guid id, CustomerArg customerArg)
        {
            Id = id;
            Name = customerArg.Name;
            Validate(customerArg);
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public ICollection<Order>? Orders { get; private set; } = new HashSet<Order>();
        //chikar konim?
        public ICollection<CustomerVendor> VendorCustomers { get; private set; } = new HashSet<CustomerVendor>();
        private void Validate(CustomerArg customerArg)
        {
            if (string.IsNullOrEmpty(customerArg.Name))
                throw new Exception();
        }
    }
}
