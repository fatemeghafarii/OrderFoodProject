using Microsoft.EntityFrameworkCore;
using OrderFood.Domain.Customers;
using OrderFood.Domain.Customers.Entities;
using OrderFood.Domain.Foods;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Entities;
using OrderFood.Domain.Vendors;

namespace OrderFood.Persistence.EF.Contexts
{
    public class OrderFoodContext : DbContext
    {
        public OrderFoodContext(DbContextOptions<OrderFoodContext> options) : base(options)
        {
        }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().ToTable(nameof(Food));
            modelBuilder.Entity<Order>().ToTable(nameof(Order));
            modelBuilder.Entity<OrderItem>().ToTable(nameof(OrderItem));
            modelBuilder.Entity<Vendor>().ToTable(nameof(Vendor));
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
            modelBuilder.Entity<CustomerVendor>().ToTable(nameof(CustomerVendor));

            base.OnModelCreating(modelBuilder);
        }
    }
}
