using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Products
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Delete" });
        
        #endregion
        
        
        #region OrderDetails
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderDetails.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderDetails.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderDetails.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderDetails.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderDetails.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderDetails.Delete" });
        
        #endregion
        
        
        #region Orders
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Delete" });
        
        #endregion
        
        
        #region Customers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Delete" });
        
        #endregion
        
        
        #region Categories
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        
        #endregion
        
        
        #region CustomerDemographics
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerDemographics.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerDemographics.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerDemographics.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerDemographics.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerDemographics.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerDemographics.Delete" });
        
        #endregion
        
        
        #region Employees
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Delete" });
        
        #endregion
        
        
        #region Regions
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Delete" });
        
        #endregion
        
        
        #region Shippers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippers.Delete" });
        
        #endregion
        
        
        #region Suppliers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Suppliers.Delete" });
        
        #endregion
        
        
        #region Territories
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Territories.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Territories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Territories.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Territories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Territories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Territories.Delete" });
        
        #endregion
        
        
        #region UsStates
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UsStates.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UsStates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UsStates.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UsStates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UsStates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UsStates.Delete" });
        
        #endregion
        
        return seeds;
    }
}
