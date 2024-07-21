using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Contracts;
using OrderFood.Framework.Persistence.EF;
using OrderFood.Persistence.EF.Contexts;

namespace OrderFood.Persistence.EF.Orders
{
    public class OrderRepository : BaseRepository<Order>/*, IOrderRepository*/
    {
        public OrderRepository(OrderFoodContext orderFoodContext) : base(orderFoodContext)
        {
        }
    }
}
