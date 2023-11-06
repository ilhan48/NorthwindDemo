using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.CompanyName).HasColumnName("CompanyName");
        builder.Property(s => s.ContactName).HasColumnName("ContactName");
        builder.Property(s => s.ContactTitle).HasColumnName("ContactTitle");
        builder.Property(s => s.Address).HasColumnName("Address");
        builder.Property(s => s.City).HasColumnName("City");
        builder.Property(s => s.Region).HasColumnName("Region");
        builder.Property(s => s.PostalCode).HasColumnName("PostalCode");
        builder.Property(s => s.Country).HasColumnName("Country");
        builder.Property(s => s.Phone).HasColumnName("Phone");
        builder.Property(s => s.Fax).HasColumnName("Fax");
        builder.Property(s => s.Homepage).HasColumnName("Homepage");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}