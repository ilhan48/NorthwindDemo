using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class CustomerDemographic:Entity<Guid>
{
    public string CustomerTypeId { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
