using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UsStateConfiguration : IEntityTypeConfiguration<UsState>
{
    public void Configure(EntityTypeBuilder<UsState> builder)
    {
        builder.ToTable("UsStates").HasKey(us => us.Id);

        builder.Property(us => us.Id).HasColumnName("Id").IsRequired();
        builder.Property(us => us.StateName).HasColumnName("StateName");
        builder.Property(us => us.StateAbbr).HasColumnName("StateAbbr");
        builder.Property(us => us.StateRegion).HasColumnName("StateRegion");
        builder.Property(us => us.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(us => us.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(us => us.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(us => !us.DeletedDate.HasValue);
    }
}