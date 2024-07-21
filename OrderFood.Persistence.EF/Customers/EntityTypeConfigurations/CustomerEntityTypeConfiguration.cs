using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderFood.Domain.Customers;
using OrderFood.Domain.Customers.Entities;
using OrderFood.Domain.Orders;
using System.Data;

namespace OrderFood.Persistence.EF.Customers.EntityTypeConfigurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasMaxLength(256)
                .HasColumnType<string>(nameof(SqlDbType.NVarChar));

            ConfigOrderItem(builder);
            ConfigCustomerVendor(builder);
        }
        private static void ConfigOrderItem(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsMany(c => c.Orders, p =>
            {
                p.ToTable(nameof(Order));
                p.HasKey(o => o.Id);
                p.Property(o => o.Id);
                p.WithOwner().HasForeignKey(o => o.CustomerId);
            });
        }
        private static void ConfigCustomerVendor(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsMany(c => c.VendorCustomers, p =>
            {
                p.ToTable(nameof(CustomerVendor));
                p.HasKey(v => v.Id);
                p.Property(v => v.Id);
                //p.WithOwner().HasForeignKey(v => v.CustomerId);
            });
        }
    }
}
