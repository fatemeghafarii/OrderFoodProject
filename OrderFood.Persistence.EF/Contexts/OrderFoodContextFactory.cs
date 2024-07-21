using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderFood.Persistence.EF.Contexts
{
    public class OrderFoodContextFactory : IDesignTimeDbContextFactory<OrderFoodContext>
    {
        public OrderFoodContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OrderFoodContext>();
            builder.UseSqlServer("data source =.; initial catalog = OrderFoodMyDB; integrated security=sspi;TrustServerCertificate=True;");
            return new OrderFoodContext(builder.Options);
        }
    }
}
