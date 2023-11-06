using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.LastName).HasColumnName("LastName");
        builder.Property(e => e.FirstName).HasColumnName("FirstName");
        builder.Property(e => e.Title).HasColumnName("Title");
        builder.Property(e => e.TitleOfCourtesy).HasColumnName("TitleOfCourtesy");
        builder.Property(e => e.BirthDate).HasColumnName("BirthDate");
        builder.Property(e => e.HireDate).HasColumnName("HireDate");
        builder.Property(e => e.Address).HasColumnName("Address");
        builder.Property(e => e.City).HasColumnName("City");
        builder.Property(e => e.Region).HasColumnName("Region");
        builder.Property(e => e.PostalCode).HasColumnName("PostalCode");
        builder.Property(e => e.Country).HasColumnName("Country");
        builder.Property(e => e.HomePhone).HasColumnName("HomePhone");
        builder.Property(e => e.Extension).HasColumnName("Extension");
        builder.Property(e => e.Notes).HasColumnName("Notes");
        builder.Property(e => e.ReportsTo).HasColumnName("ReportsTo");
        builder.Property(e => e.PhotoPath).HasColumnName("PhotoPath");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}