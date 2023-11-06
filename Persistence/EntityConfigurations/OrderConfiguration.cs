using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.CustomerId).HasColumnName("CustomerId");
        builder.Property(o => o.EmployeeId).HasColumnName("EmployeeId");
        builder.Property(o => o.OrderDate).HasColumnName("OrderDate");
        builder.Property(o => o.RequiredDate).HasColumnName("RequiredDate");
        builder.Property(o => o.ShippedDate).HasColumnName("ShippedDate");
        builder.Property(o => o.ShipVia).HasColumnName("ShipVia");
        builder.Property(o => o.Freight).HasColumnName("Freight");
        builder.Property(o => o.ShipName).HasColumnName("ShipName");
        builder.Property(o => o.ShipAddress).HasColumnName("ShipAddress");
        builder.Property(o => o.ShipCity).HasColumnName("ShipCity");
        builder.Property(o => o.ShipRegion).HasColumnName("ShipRegion");
        builder.Property(o => o.ShipPostalCode).HasColumnName("ShipPostalCode");
        builder.Property(o => o.ShipCountry).HasColumnName("ShipCountry");
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}