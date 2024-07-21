using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderFood.Domain.Customers.Entities;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Vendors;
using System.Data;

namespace OrderFood.Persistence.EF.Vendors.EntityTypeConfigurations
{
    public class VendorEntityTypeConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable(nameof(Vendor));
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id).ValueGeneratedNever();

            builder.Property(v => v.Title)
                .HasMaxLength(256)
                .HasColumnType<string>(nameof(SqlDbType.NVarChar));

            builder.Property(v => v.Address)
                .HasMaxLength(4000)
                .HasColumnType<string>(nameof(SqlDbType.NVarChar));

            builder.Property(v => v.MinimumBasket)
                .HasColumnType<long>(nameof(SqlDbType.BigInt));

            ConfigOrder(builder);
            ConfigCustomerVendor(builder);
            ConfigVendorFood(builder);
        }

        private static void ConfigOrder(EntityTypeBuilder<Vendor> builder)
        {
            builder.OwnsMany(v => v.Orders, p =>
            {
                p.ToTable(nameof(Order));
                p.HasKey(o => o.Id);
                p.Property(o => o.Id);
                p.WithOwner().HasForeignKey(o => o.VendorId);
            });
        }
        private static void ConfigCustomerVendor(EntityTypeBuilder<Vendor> builder)
        {
            builder.OwnsMany(v => v.CustomerVendors, p =>
            {
                p.ToTable(nameof(CustomerVendor));
                p.HasKey(c => c.Id);
                p.Property(c => c.Id);
                p.WithOwner().HasForeignKey(c => c.VendorId);
            });
        }
        private static void ConfigVendorFood(EntityTypeBuilder<Vendor> builder)
        {
            builder.OwnsMany(o => o.Foods, p =>
            {
                p.ToTable(nameof(Foods));
                p.HasKey(f => f.Id);
                p.Property(f => f.Id);
                p.WithOwner().HasForeignKey(f => f.VendorId);
            });
        }
    }
}
