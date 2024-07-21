using OrderFood.Domain.Customers;
using OrderFood.Framework.Persistence.EF;
using OrderFood.Persistence.EF.Contexts;

namespace OrderFood.Persistence.EF.Customers
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(OrderFoodContext orderFoodContext) : base(orderFoodContext)
        {
        }
    }
}
