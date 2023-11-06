using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CompanyName).HasColumnName("CompanyName");
        builder.Property(c => c.ContactName).HasColumnName("ContactName");
        builder.Property(c => c.ContactTitle).HasColumnName("ContactTitle");
        builder.Property(c => c.Address).HasColumnName("Address");
        builder.Property(c => c.City).HasColumnName("City");
        builder.Property(c => c.Region).HasColumnName("Region");
        builder.Property(c => c.PostalCode).HasColumnName("PostalCode");
        builder.Property(c => c.Country).HasColumnName("Country");
        builder.Property(c => c.Phone).HasColumnName("Phone");
        builder.Property(c => c.Fax).HasColumnName("Fax");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}