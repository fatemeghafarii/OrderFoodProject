using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderFood.Domain.Contract.Enums;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Contracts;
using OrderFood.Domain.Orders.Entities;
using System.Data;

namespace OrderFood.Persistence.EF.Orders.EntityTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.Property(o => o.OrderState).HasDefaultValue(OrderStateEnum.Submitted).IsRequired();

            builder.Property(o => o.FinalPrice)
                .HasColumnType<long>(nameof(SqlDbType.BigInt));

            builder
              .HasOne(o => o.Vendor)
              .WithMany()
              .HasForeignKey(o => o.VendorId)
              .OnDelete(DeleteBehavior.NoAction);

            builder
              .HasOne(o => o.Customer)
              .WithMany()
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.NoAction);



            ConfigOrderItem(builder);
        }
        private static void ConfigOrderItem(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsMany(o => o.OrderItems, p =>
            {
                p.ToTable(nameof(OrderItem));
                p.HasKey(i => i.Id);
                p.Property(i => i.Id);
                p.WithOwner().HasForeignKey(i => i.OrderId);

            });
        }
    
    }
}
