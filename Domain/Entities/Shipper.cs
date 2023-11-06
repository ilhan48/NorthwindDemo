using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public  class Shipper: Entity<Guid>
{
    

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
