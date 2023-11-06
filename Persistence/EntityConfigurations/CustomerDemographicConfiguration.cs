using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerDemographicConfiguration : IEntityTypeConfiguration<CustomerDemographic>
{
    public void Configure(EntityTypeBuilder<CustomerDemographic> builder)
    {
        builder.ToTable("CustomerDemographics").HasKey(cd => cd.Id);

        builder.Property(cd => cd.Id).HasColumnName("Id").IsRequired();
        builder.Property(cd => cd.CustomerTypeId).HasColumnName("CustomerTypeId");
        builder.Property(cd => cd.CustomerDesc).HasColumnName("CustomerDesc");
        builder.Property(cd => cd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cd => cd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cd => cd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cd => !cd.DeletedDate.HasValue);
    }
}