using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderFood.Domain.Foods;
using OrderFood.Domain.Orders.Entities;
using System.Data;

namespace OrderFood.Persistence.EF.Foods.EntityTypeConfigurations
{
    public class FoodEntityTypeConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable(nameof(Food));
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedNever();

            builder.Property(f => f.Title)
                .HasMaxLength(256)
                .HasColumnType<string>(nameof(SqlDbType.NVarChar));

            builder.Property(f => f.Price)
                .HasColumnType<long>(nameof(SqlDbType.BigInt));

            builder
             .HasOne(f => f.Vendor)
             .WithMany()
             .HasForeignKey(f => f.VendorId)
             .OnDelete(DeleteBehavior.NoAction);

            ConfigOrderItem(builder);
        }
        private static void ConfigOrderItem(EntityTypeBuilder<Food> builder)
        {
            builder.OwnsMany(o => o.OrderItems, p =>
            {
                p.ToTable(nameof(OrderItem));
                p.HasKey(i => i.Id);
                p.Property(i => i.Id);
                p.WithOwner().HasForeignKey(i => i.FoodId);
            });
        }
    }
}
